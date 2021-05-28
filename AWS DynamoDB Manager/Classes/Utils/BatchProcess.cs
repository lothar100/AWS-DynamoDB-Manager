using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public static class BatchProcess
    {

        public static List<BatchWriteItemResponse> WriteItemsAsync(List<Dictionary<string, AttributeValue>> items)
        {
            var resultList = new List<BatchWriteItemResponse>();
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
                resultList.Add(result);
            }
            return resultList;
        }

    }
}
