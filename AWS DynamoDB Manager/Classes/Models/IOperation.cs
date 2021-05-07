using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public interface IOperation
    {
        public string Effect { get; }
        public string Change { get; }

        public Dictionary<string, Condition> GetConditions();
    }
}
