using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class SchemaOp : IOperation
    {
        public string Effect => "Schema";
        public string Change => $"'{SourceField}' → '{DestinationField}'";

        public SchemaOp(string sourceField, string destinationField)
        {
            SourceField = sourceField;
            DestinationField = destinationField;
        }

        public string SourceField { get; }
        public string DestinationField { get; }
        public AttributeValue SourceAttribute { get; }

        public Dictionary<string, Condition> GetConditions()
        {
            throw new NotImplementedException();
        }
    }
}
