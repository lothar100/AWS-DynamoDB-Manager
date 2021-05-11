using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public interface IOperation
    {
        public OperationType Effect { get; }
        public string Change { get; }
        public List<string> Fields { get; }

        public void Process(ref List<Dictionary<string, AttributeValue>> Items);
    }

    public enum OperationType
    {
        Schema,
        Type,
        Value
    }
}
