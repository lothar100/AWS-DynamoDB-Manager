using AWS_DynamoDB_Manager.Classes.Utils;

namespace AWS_DynamoDB_Manager.Classes
{
    public static class Manager
    {
        public static OpRunner OpRunner => Singleton<OpRunner>.Instance;
        public static AppSettings Settings => Singleton<AppSettings>.Instance;
        public static DynamoClient Client => Singleton<DynamoClient>.Instance;
        public static void ResetClient()
        {
            Singleton<DynamoClient>.Reset();
            System.Diagnostics.Debug.WriteLine("Client Reset");
        }

        public static TableInfo SourceTable { get; set; }
        public static TableInfo DestinationTable { get; set; }
    }
}
