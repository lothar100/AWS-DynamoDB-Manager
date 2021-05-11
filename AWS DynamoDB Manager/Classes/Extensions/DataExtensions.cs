using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Data;

namespace AWS_DynamoDB_Manager.Classes.Extensions
{
    public static class DataExtensions
    {
        public static DataTable SortColumns(this DataTable table, IEnumerable<string> names, int start = 0)
        {
            int i = start;
            foreach(var name in names)
            {
                if (table.Columns.Contains(name))
                {
                    table.Columns[name].SetOrdinal(i);
                    i++;
                }
            }

            return table;
        }
        public static DataTable ColumnsAddRange(this DataTable table, DataColumn[] columns)
        {
            table.Columns.AddRange(columns);
            return table;
        }

        public static DataTable Fill(this DataTable table, List<Dictionary<string, AttributeValue>> Items)
        {
            Items.ForEach(item =>
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
                dataRow[pair.Current.Key] = pair.Current.Value.GetValue();
            }
            return dataRow;
        }
    }
}
