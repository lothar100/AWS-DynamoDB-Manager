using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public class TypeOp : IOperation
    {
        public OperationType Effect => OperationType.Type;
        public string Change => $"'{SourceField}': {{{OldType}}} → '{SourceField}': {{{NewType}}}";
        public List<string> Fields => new List<string>() { SourceField };

        public TypeOp(string sourceField, string oldType, string newType)
        {
            SourceField = sourceField;
            OldType = oldType;
            NewType = newType;
        }

        public string SourceField { get; }
        public string OldType { get; }
        public string NewType { get; }

        public void Process(ref List<Dictionary<string, AttributeValue>> Items)
        {
            if(_supported.Contains(NewType) == false) throw new NotImplementedException();

            var items = Items.Where(item => item.ContainsKey(SourceField));

            if (items.First()[SourceField].GetTypeString().Equals(NewType)) return;

            foreach (var item in items)
            {
                var oldValue = item[SourceField].GetValue();
                item[SourceField].ClearValue();
                if(NewType.Equals("BOOL")) {
                    item[SourceField].BOOL = Convert.ToBoolean(oldValue);
                    item[SourceField].IsBOOLSet = true;
                }
                if (NewType.Equals("NULL")) item[SourceField].NULL = true;
                if (NewType.Equals("N")) item[SourceField].N = Convert.ToInt64(oldValue).ToString();
                if (NewType.Equals("S")) item[SourceField].S = Convert.ToString(oldValue);
            }
        }

        private List<string> _supported = new List<string>() { "BOOL", "NULL", "N", "S" };

    }
}
