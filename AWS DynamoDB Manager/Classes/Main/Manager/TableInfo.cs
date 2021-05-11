using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using AWS_DynamoDB_Manager.Classes.Extensions;
using AWS_DynamoDB_Manager.Classes.Utils;

namespace AWS_DynamoDB_Manager.Classes
{
    public class TableInfo
    {
        private string _tableName;

        public TableInfo(string tableName)
        {
            _tableName = tableName;
        }

        public static implicit operator TableInfo(string tableName)
        {
            return new TableInfo(tableName);
        }

        public string Name => _tableName;

        private DescribeTableResponse _description => Manager.Client.DescribeTableAsync(Name).Result;
        public ScanResponse Scan => Manager.Client.ScanAsync(Name, new Dictionary<string, Condition>()).Result;

        public List<string> Keys => _description.Table.KeySchema.ConvertAll(schema => schema.AttributeName);

        public DataTable DataTable
        {
            get
            {
                var columns = ConvertUtils.ToDataColumnList(Scan);
                return new DataTable()
                    .ColumnsAddRange(columns.ToArray())
                    .SortColumns(Keys);
            }
        }
    }
}
