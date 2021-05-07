using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class TypeOp : IOperation
    {
        public string Effect => "Type";
        public string Change => $"'{SourceField}': {{{OldType}}} → '{SourceField}': {{{NewType}}}";

        public TypeOp(string sourceField, string oldType, string newType)
        {
            SourceField = sourceField;
            OldType = oldType;
            NewType = newType;
        }

        public string SourceField { get; }
        public string OldType { get; }
        public string NewType { get; }

        public Dictionary<string, Condition> GetConditions()
        {
            throw new NotImplementedException();
        }
    }
}
