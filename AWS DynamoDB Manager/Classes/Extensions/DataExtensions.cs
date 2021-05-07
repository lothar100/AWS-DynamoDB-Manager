using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes.Extensions
{
    public static class DataExtensions
    {
        public static DataTable ColumnsAddRange(this DataTable table, DataColumn[] columns)
        {
            table.Columns.AddRange(columns);
            return table;
        }

        public static DataSet Fill(this DataSet dataSet, DataTable table)
        {
            dataSet.Tables.Add(table);
            return dataSet;
        }

        public static DataTable Fill(this DataTable table, IAmazonResponse response)
        {
            response.Items.ForEach(item =>
            {
                table.Rows.Add(
                    table.NewRow().Fill(item)
                );
            });
            return table;
        }

        public static DataRow Fill(this DataRow dataRow, Dictionary<string, AttributeValue> rowValues)
        {
            var pair = rowValues.GetEnumerator();
            while (pair.MoveNext())
            {
                dataRow[pair.Current.Key] = ConvertUtils.ToObject(pair.Current.Value);
            }
            return dataRow;
        }
    }
}
