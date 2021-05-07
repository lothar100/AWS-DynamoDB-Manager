using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public interface IAmazonResponse
    {
        public List<Dictionary<string, AttributeValue>> Items { get; set; }
    }
}
