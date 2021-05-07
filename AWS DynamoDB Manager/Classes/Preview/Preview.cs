using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class Preview
    {
        public string SourceTable { get; set; }
        public string DestinationTable { get; set; }
        public IOperation Operation { get; set; }
        public DataTable SourceView { get; set; }
        public DataTable DestinationView { get; set; }

        private IAmazonResponse _sourceScan => new WrappedResponse(Manager.Client.ScanAsync(SourceTable, new Dictionary<string, Condition>()).Result);
        private IAmazonResponse _destinationScan => new WrappedResponse(Manager.Client.ScanAsync(DestinationTable, new Dictionary<string, Condition>()).Result);
        public void GenerateViews()
        {
            SourceView = ConvertUtils.ToDataTable(_sourceScan);

            var conditions = new Dictionary<string, Condition>()
            {
                {"pk", new Condition(){
                    AttributeValueList = new List<AttributeValue>(){ }
                } }
            };

            var request = new QueryRequest(SourceTable)
            {
                Limit = 25,
                KeyConditions = null
            };

            var response = new WrappedResponse(Manager.Client.QueryAsync(request).Result);

            SourceView.Fill(response);


            DestinationView = ConvertUtils.ToDataTable(_destinationScan);
        }
    }
}
