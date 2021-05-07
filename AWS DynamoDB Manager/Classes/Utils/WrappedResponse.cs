using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public class WrappedResponse : IAmazonResponse
    {
        public List<Dictionary<string, AttributeValue>> Items { get; set; }

        public WrappedResponse(QueryResponse response)
        {
            Items = response.Items;
        }

        public WrappedResponse(ScanResponse response)
        {
            Items = response.Items;
        }
    }
}
