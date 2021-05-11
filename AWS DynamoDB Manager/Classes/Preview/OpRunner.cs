using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public class OpRunner
    {
        public List<IOperation> Operations { get; set; }
        public int OpIndex { get; set; }
        public DataTable SourceView { get; set; }
        public DataTable DestinationView { get; set; }

        public void RunPreview()
        {
            // setup source view
            var sourceScan = Manager.SourceTable.Scan;
            SourceView = Manager.SourceTable.DataTable;
            SourceView.Fill(sourceScan.Items.GetRange(0, 25));

            // process operations
            var items = new List<Dictionary<string, AttributeValue>>(sourceScan.Items);
            for (int i = 0; i <= OpIndex; i++)
            {
                Operations[i].Process(ref items);
            }

            // setup destination view
            var importantFields = Manager.DestinationTable.Keys.Union(Operations[OpIndex].Fields);
            var destinationItems = items.GetRange(0, 25).AddRangeAndReturn(Manager.DestinationTable.Scan.Items);
            DestinationView = ConvertUtils.ToDataTable(destinationItems).SortColumns(importantFields);
            DestinationView.Fill(destinationItems);
        }

        public void RunOperations()
        {
            var items = new List<Dictionary<string, AttributeValue>>(Manager.SourceTable.Scan.Items);
            Operations.ForEach(op => op.Process(ref items));

            for (int i = 0; i <= items.Count / 25; i++)
            {
                int index = i * 25;
                int count = Math.Min(25, items.Count - index);
                var batch = items.GetRange(index, count);

                System.Diagnostics.Debug.WriteLine($"Processing Items {index}-{index + count}");

                var request = new BatchWriteItemRequest();
                var writes = new List<WriteRequest>();
                foreach (var item in batch)
                {
                    writes.Add(new WriteRequest(new PutRequest() { Item = item }));
                }
                request.RequestItems.Add(Manager.DestinationTable.Name, writes);

                var result = Manager.Client.BatchWriteItemAsync(request).Result;
            }
        }
    }
}
