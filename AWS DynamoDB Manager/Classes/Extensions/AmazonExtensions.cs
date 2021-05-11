using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace AWS_DynamoDB_Manager.Classes.Extensions
{
    public static class AmazonExtensions
    {
        public static object? GetValue(this AttributeValue av)
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

        public static void UpdateValue(this AttributeValue av, string newValue)
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
        }

        public static void ClearValue(this AttributeValue av)
        {
            if (av.B != null) av.B = null;
            if (av.IsBOOLSet) { av.IsBOOLSet = false; av.BOOL = false; }
            if (av.IsLSet) { av.IsLSet = false; av.L = null; }
            if (av.IsMSet) { av.IsMSet = false; av.M = null; }
            if (av.N != null) av.N = null;
            if (av.NS.Count > 0) av.NS.Clear();
            if (av.NULL) av.NULL = false;
            if (string.IsNullOrEmpty(av.S) == false) av.S = null;
            if (av.SS.Count > 0) av.SS.Clear();
        }

        public static Type GetValueType(this AttributeValue av)
        {
            if (av.B != null) return typeof(MemoryStream);
            if (av.IsBOOLSet) return typeof(bool);
            if (av.IsLSet) return typeof(List<AttributeValue>);
            if (av.IsMSet) return typeof(Dictionary<string, AttributeValue>);
            if (av.N != null) return typeof(long);
            if (av.NS.Count > 0) return typeof(List<float>);
            if (av.NULL) return typeof(Nullable);
            if (string.IsNullOrEmpty(av.S) == false) return typeof(string);
            if (av.SS.Count > 0) return typeof(List<string>);
            throw new Exception("TypeNotFound");
        }

        public static string GetTypeString(this AttributeValue av)
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
    }
}
