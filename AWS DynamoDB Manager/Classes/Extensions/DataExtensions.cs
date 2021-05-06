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
    }
}
