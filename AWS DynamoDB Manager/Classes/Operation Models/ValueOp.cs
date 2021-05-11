using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public class ValueOp : IOperation
    {
        public OperationType Effect => OperationType.Value;
        public string Change => $"'{SourceField}': {OldValue} → {NewValue}";
        public List<string> Fields => new List<string>() { SourceField };

        public ValueOp(string sourceField, string oldValue, string newValue)
        {
            SourceField = sourceField;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string SourceField { get; }
        public string OldValue { get; }
        public string NewValue { get; }

        public void Process(ref List<Dictionary<string, AttributeValue>> Items)
        {
            var items = Items.Where(item => item.ContainsKey(SourceField) && item[SourceField].GetValue().ToString().Equals(OldValue));

            foreach(var item in items)
            {
                item[SourceField].UpdateValue(NewValue);
            }
        }
    }
}
