using Amazon.DynamoDBv2;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public static class Manager
    {
        public static AppSettings Settings => Singleton<AppSettings>.Instance;
        public static DynamoClient Client => Singleton<DynamoClient>.Instance;
        public static void ResetClient()
        {
            Singleton<DynamoClient>.Reset();
            System.Diagnostics.Debug.WriteLine("Client Reset");
        }
    }
}
