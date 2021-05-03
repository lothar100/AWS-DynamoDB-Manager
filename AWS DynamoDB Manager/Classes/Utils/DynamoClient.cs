using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public class DynamoClient
    {
        public static AmazonDynamoDBClient Client { get; private set; }

        static DynamoClient()
        {
            // Explicit static constructor
        }

        private DynamoClient()
        {

        }

        public static void Initialize()
        {
            Client = new AmazonDynamoDBClient();
        }

    }
}
