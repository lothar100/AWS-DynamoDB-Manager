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
        public static T ToActualValue<T>(AttributeValue av)
        {
            object obj = new object() { };
            return (T)obj;
        }
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
        
        public static DataTable ToDataTable(IAmazonResponse response) => new DataTable().ColumnsAddRange(ToDataColumnList(response).ToArray());
        public static DataTable ToDataTable(List<DataColumn> colList) => new DataTable().ColumnsAddRange(colList.ToArray());


        public static List<string> ToKeyList(IAmazonResponse response)
        {
            var list = new List<string>();
            var pairs = getUniquePairs(response).GetEnumerator();
            while (pairs.MoveNext()) list.Add(pairs.Current.Key);
            return list;
        }

        public static List<string> ToAttributeList(IAmazonResponse response)
        {
            var list = new List<string>();
            var pairs = getUniquePairs(response).GetEnumerator();
            while (pairs.MoveNext()) list.Add(ToTypeString(pairs.Current.Value));
            return list;
        }

        public static List<DataColumn> ToDataColumnList(IAmazonResponse response)
        {
            var list = new List<DataColumn>();
            var pairs = getUniquePairs(response).GetEnumerator();
            while (pairs.MoveNext()) list.Add(ToDataColumn(pairs.Current));
            return list;
        }

        public static Dictionary<string, string> ToAttributeDictionary(IAmazonResponse response)
        {
            var unique_pairs = new Dictionary<string, string>();
            response.Items.ForEach((item) =>
            {
                var pairs = item.Where((pair) => unique_pairs.ContainsKey(pair.Key) == false).GetEnumerator();
                while (pairs.MoveNext()) unique_pairs.Add(pairs.Current.Key, ToTypeString(pairs.Current.Value));
            });
            return unique_pairs;
        }

        public static Dictionary<string, AttributeValue> getUniquePairs(IAmazonResponse response)
        {
            var unique_pairs = new Dictionary<string, AttributeValue>();
            response.Items.ForEach((item) =>
            {
                var pairs = item.Where((pair) => unique_pairs.ContainsKey(pair.Key) == false).GetEnumerator();
                while (pairs.MoveNext()) unique_pairs.Add(pairs.Current.Key, pairs.Current.Value);
            });
            return unique_pairs;
        }

        public static DataColumn ToDataColumn(KeyValuePair<string, AttributeValue> item)
        {
            return new DataColumn()
            {
                ColumnName = item.Key,
                DataType = ToType(item.Value)
            };
        }

        public static string ToTypeString(AttributeValue av)
        {
            if (av.B != null) return "B";
            if (av.IsBOOLSet) return "BOOL";
            if (av.IsLSet) return "L";
            if (av.IsMSet) return "M";
            if (av.N != null) return "N";
            if (av.NS.Count > 0) return "NS";
            if (av.NULL) return "NULL";
            if (string.IsNullOrEmpty(av.S) == false) return "S";
            if (av.SS.Count > 0) return "SS";
            throw new Exception("TypeNotFound");
        }

        public static Type ToType(string typeName)
        {
            if (typeName.Equals("B")) return typeof(MemoryStream);
            if (typeName.Equals("BOOL")) return typeof(bool);
            if (typeName.Equals("L")) return typeof(List<AttributeValue>);
            if (typeName.Equals("M")) return typeof(Dictionary<string, AttributeValue>);
            if (typeName.Equals("N")) return typeof(int);
            if (typeName.Equals("NS")) return typeof(List<float>);
            if (typeName.Equals("NULL")) return typeof(Nullable);
            if (typeName.Equals("S")) return typeof(string);
            if (typeName.Equals("SS")) return typeof(List<string>);
            throw new Exception("TypeNotFound");
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

        public static object? ToObject(AttributeValue av)
        {
            if (av.B != null) return av.B;
            if (av.IsBOOLSet) return av.BOOL;
            if (av.IsLSet) return av.L;
            if (av.IsMSet) return av.M;
            if (av.N != null) return av.N;
            if (av.NS.Count > 0) return av.NS;
            if (av.NULL) return null;
            if (string.IsNullOrEmpty(av.S) == false) return av.S;
            if (av.SS.Count > 0) return av.SS;
            throw new Exception("TypeNotFound");
        }

        public static AttributeValue UpdateValue(AttributeValue av, string newValue)
        {
            if (av.B != null) throw new NotImplementedException();
            if (av.IsBOOLSet) av.BOOL = Convert.ToBoolean(newValue);
            if (av.IsLSet) throw new NotImplementedException();
            if (av.IsMSet) throw new NotImplementedException();
            if (av.N != null) av.N = newValue;
            if (av.NS.Count > 0) throw new NotImplementedException();
            if (av.NULL) throw new NotImplementedException();
            if (string.IsNullOrEmpty(av.S) == false) av.S = newValue;
            if (av.SS.Count > 0) throw new NotImplementedException();
            return av;
        }

        //TODO : Remove these if not used
        [Obsolete]
        public static DataSet ToDataSet(IAmazonResponse response) => new DataSet().Fill(ToDataTable(ToDataColumnList(response)));
        [Obsolete]
        public static DataSet ToDataSet(List<DataColumn> colList) => new DataSet().Fill(ToDataTable(colList));
    }
}
