using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWS_DynamoDB_Manager.Classes
{
    public static class ScriptedRoutines
    {
        public static void InClave_Prod_Transfer(string sourceTable, string destinationTable)
        {
            if (sourceTable != "inclave-keyfob-service-prod-KeyFobTable-R4XQKRSGX8WA") return;

            var scanResponse = Manager.Client.ScanAsync(sourceTable, new Dictionary<string, Condition>()).Result;

            var users = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Equals("KeyFob")));
            var vehicles = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && !item["sk"].S.Equals("KeyFob")));
            var keyfobs = new List<Dictionary<string, AttributeValue>>();

            foreach (var vehicle in vehicles)
            {
                vehicle.Add("pk", new AttributeValue(vehicle["keyFob"].N));
            }

            foreach (var user in users)
            {
                user["sk"].S = "User";
                user.Add("pk", new AttributeValue(user["keyFob"].N));

                var keyfob = new Dictionary<string, AttributeValue>();
                keyfob.Add("pk", new AttributeValue(user["keyFob"].N));
                keyfob.Add("keyFobID", new AttributeValue(user["keyFob"].N));
                keyfob.Add("sk", new AttributeValue($"KeyFob#{user["keyFob"].N}"));
                keyfob.Add("pk2", new AttributeValue("KeyFob"));
                keyfobs.Add(keyfob);
            }

            var items = users.AddRangeAndReturn(vehicles).AddRangeAndReturn(keyfobs);

            for (int i = 0; i <= items.Count / 25; i++)
            {
                int index = i * 25;
                int count = Math.Min(25, items.Count - index);
                var batch = items.GetRange(index, count);

                System.Diagnostics.Debug.WriteLine($"Processing Items {index}-{index + count}");

                var request = new BatchWriteItemRequest();
                var writes = new List<WriteRequest>();
                foreach (var item in batch)
                {
                    writes.Add(new WriteRequest(new PutRequest() { Item = item }));
                }
                request.RequestItems.Add(destinationTable, writes);

                var result = Manager.Client.BatchWriteItemAsync(request).Result;
            }
        }

        public static void ElCamino_Prod_Transfer(string sourceTable, string destinationTable)
        {
            if (sourceTable != "el-camino-keyfob-service-prod-KeyFobTable-8O1L874EBM5N") return;

            var scanResponse = Manager.Client.ScanAsync(sourceTable, new Dictionary<string, Condition>()).Result;

            var users = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Equals("KeyFob")));
            var zones = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Contains("Zone#")));
            var keyfobs = new List<Dictionary<string, AttributeValue>>();

            foreach (var zone in zones)
            {
                var userID = users.First(user => user.ContainsKey("keyFob") && user["keyFob"].S.Equals(zone["keyFob"].S))["usrID"];
                zone.Add("pk", userID);
            }

            foreach (var user in users)
            {
                user["sk"].S = "User";
                user.Add("pk", user["usrID"]);

                var keyfob = new Dictionary<string, AttributeValue>();
                keyfob.Add("pk", user["usrID"]);
                keyfob.Add("keyFobID", user["usrID"]);
                keyfob.Add("sk", new AttributeValue($"KeyFob#{user["usrID"].S}"));
                keyfob.Add("pk2", new AttributeValue("KeyFob"));
                keyfobs.Add(keyfob);
            }

            var items = users.ToList().AddRangeAndReturn(zones).AddRangeAndReturn(keyfobs);

            for (int i = 0; i <= items.Count / 25; i++)
            {
                int index = i * 25;
                int count = Math.Min(25, items.Count - index);
                var batch = items.GetRange(index, count);

                System.Diagnostics.Debug.WriteLine($"Processing Items {index}-{index + count}");

                var request = new BatchWriteItemRequest();
                var writes = new List<WriteRequest>();
                foreach (var item in batch)
                {
                    writes.Add(new WriteRequest(new PutRequest() { Item = item }));
                }
                request.RequestItems.Add(destinationTable, writes);

                var result = Manager.Client.BatchWriteItemAsync(request).Result;
            }
        }
    }
}
