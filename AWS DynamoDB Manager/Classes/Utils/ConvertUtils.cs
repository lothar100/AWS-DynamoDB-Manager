using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.IO;
using AWS_DynamoDB_Manager.Classes.Extensions;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public static class ConvertUtils
    {
        public static List<object> ToDataSource(List<Operation> opList)
        {
            var objList = new List<object>();

            for(int i = 0; i < opList.Count; i++)
            {
                objList.Add(new { Order = i + 1, Effect = opList[i].Effect, Change = opList[i].Change });
            }

            return objList;
        }
        public static DataSet ToDataSet(ScanResponse response) => new DataSet().Fill(ToDataTable(ToDataColumnList(response)));
        public static DataSet ToDataSet(List<DataColumn> colList) => new DataSet().Fill(ToDataTable(colList));
        public static DataTable ToDataTable(ScanResponse response) => new DataTable().ColumnsAddRange(ToDataColumnList(response).ToArray());
        public static DataTable ToDataTable(List<DataColumn> colList) => new DataTable().ColumnsAddRange(colList.ToArray());
        public static List<string> ToStringList(ScanResponse response) => new List<string>().AddRangeAndReturn(ToDataColumnList(response).Select((col) => col.ColumnName));
        public static List<DataColumn> ToDataColumnList(ScanResponse response)
        {
            var unique_pairs = new Dictionary<string, AttributeValue>();
            response.Items.ForEach((item) =>
            {
                var pairs = item.Where((pair) => unique_pairs.ContainsKey(pair.Key) == false).GetEnumerator();
                while(pairs.MoveNext()) unique_pairs.Add(pairs.Current.Key, pairs.Current.Value);
            });

            var list = new List<DataColumn>();
            var pairs = unique_pairs.GetEnumerator();
            while (pairs.MoveNext()) list.Add(ToDataColumn(pairs.Current));

            return list;
        }

        public static DataColumn ToDataColumn(KeyValuePair<string, AttributeValue> item)
        {
            return new DataColumn()
            {
                ColumnName = item.Key,
                DataType = ToType(item.Value)
            };
        }

        public static Type ToType(AttributeValue av)
        {
            if (av.B != null) return typeof(MemoryStream);
            if (av.IsBOOLSet) return typeof(bool);
            if (av.IsLSet) return typeof(List<AttributeValue>);
            if (av.IsMSet) return typeof(Dictionary<string, AttributeValue>);
            if (av.N != null) return typeof(int);
            if (av.NS.Count > 0) return typeof(List<float>);
            if (av.NULL) return typeof(Nullable);
            if (string.IsNullOrEmpty(av.S) == false) return typeof(string);
            if (av.SS.Count > 0) return typeof(List<string>);
            throw new Exception("TypeNotFound");
        }
    }
}
