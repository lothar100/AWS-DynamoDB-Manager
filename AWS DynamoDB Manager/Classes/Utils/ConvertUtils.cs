using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System.Collections.Generic;
using System.Data;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public static class ConvertUtils
    {
        public static List<object> ToDataSource(List<IOperation> opList)
        {
            var objList = new List<object>();

            if(opList.Count == 0) // needed to keep the table from entering a weird empty state
            {
                objList.Add(new { Order = string.Empty, Effect = string.Empty, Change = string.Empty });
                return objList;
            }

            for(int i = 0; i < opList.Count; i++)
            {
                objList.Add(new { Order = i + 1, Effect = opList[i].Effect, Change = opList[i].Change });
            }

            return objList;
        }

        public static DataTable ToDataTable(ScanResponse response) => ToDataTable(response.Items);
        public static DataTable ToDataTable(List<Dictionary<string, AttributeValue>> Items) => new DataTable().ColumnsAddRange(ToDataColumnList(Items).ToArray());
        public static DataTable ToDataTable(List<DataColumn> colList) => new DataTable().ColumnsAddRange(colList.ToArray());
        
        public static List<string> ToKeyList(ScanResponse response) => ToKeyList(response.Items);
        public static List<string> ToKeyList(List<Dictionary<string, AttributeValue>> Items)
        {
            var list = new List<string>();
            var pairs = Items.UniquePairs().GetEnumerator();
            while (pairs.MoveNext()) list.Add(pairs.Current.Key);
            return list;
        }

        public static List<DataColumn> ToDataColumnList(ScanResponse response) => ToDataColumnList(response.Items);
        public static List<DataColumn> ToDataColumnList(List<Dictionary<string, AttributeValue>> Items)
        {
            var list = new List<DataColumn>();
            var pairs = Items.UniquePairs().GetEnumerator();
            while (pairs.MoveNext()) list.Add(ToDataColumn(pairs.Current));
            return list;
        }

        public static DataColumn ToDataColumn(KeyValuePair<string, AttributeValue> item)
        {
            return new DataColumn()
            {
                ColumnName = item.Key,
                DataType = item.Value.GetValueType()
            };
        }

    }
}
