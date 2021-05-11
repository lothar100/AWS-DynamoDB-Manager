using Amazon.DynamoDBv2;
using System.Threading.Tasks;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public class DynamoClient : AmazonDynamoDBClient
    {
        public DynamoClient() : base(Profiles.Current.Credentials) { }
        public bool Initialized => getConnectionStatus();
        private bool getConnectionStatus()
        {
            try
            {
                var request = ListTablesAsync();
                var result = request.Result;
                return request.Status.Equals(TaskStatus.RanToCompletion);
            }
            catch
            {
                return false;
            }
        }
    }
}
