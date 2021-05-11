using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public class SchemaOp : IOperation
    {
        public OperationType Effect => OperationType.Schema;
        public string Change => $"'{SourceField}' → '{DestinationField}'";
        public List<string> Fields => new List<string>() { SourceField, DestinationField };

        public SchemaOp(string sourceField, string destinationField)
        {
            SourceField = sourceField;
            DestinationField = destinationField;
        }

        public string SourceField { get; }
        public string DestinationField { get; }

        public void Process(ref List<Dictionary<string, AttributeValue>> Items)
        {
            var items = Items.Where(item => item.ContainsKey(SourceField));

            foreach (var item in items)
            {
                var oldValue = item[SourceField];
                item.Remove(SourceField);

                if (item.ContainsKey(DestinationField))
                {
                    item[DestinationField] = oldValue;
                }
                else
                {
                    item.Add(DestinationField, oldValue);
                }
            }
        }
    }
}
