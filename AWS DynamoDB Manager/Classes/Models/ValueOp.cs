using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class ValueOp : IOperation
    {
        public string Effect => "Value";
        public string Change => $"'{SourceField}': {OldValue} → {NewValue}";

        public ValueOp(string sourceField, string oldValue, string newValue)
        {
            SourceField = sourceField;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string SourceField { get; }
        public string OldValue { get; }
        public string NewValue { get; }
        public AttributeValue SourceAttribute { get; }

        private AttributeValue NewSourceAttribute => ConvertUtils.UpdateValue(SourceAttribute, NewValue);

        public Dictionary<string, Condition> GetConditions()
        {
            var conditions = new Dictionary<string, Condition>();
            conditions.Add(
                SourceField,
                new Condition() { 
                    AttributeValueList = new List<AttributeValue>() { NewSourceAttribute }
                }
            );
            return conditions;
        }
    }
}
