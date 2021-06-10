using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Classes
{
    public static class ScriptedRoutines
    {
        public static void InClave_Prod_Transfer()
        {
            string sourceTable = Manager.SourceTable.Name;
            if (sourceTable != "inclave-keyfob-service-prod-KeyFobTable-R4XQKRSGX8WA") return;

            var scanResponse = Manager.Client.ScanAsync(sourceTable, new Dictionary<string, Condition>()).Result;

            var users = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Equals("KeyFob")));
            var vehicles = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && !item["sk"].S.Equals("KeyFob")));

            var newVehicles = new List<Dictionary<string, AttributeValue>>();
            var newUsers = new List<Dictionary<string, AttributeValue>>();
            var newKeyfobs = new List<Dictionary<string, AttributeValue>>();

            foreach (var vehicle in vehicles)
            {
                var newVehicle = new Dictionary<string, AttributeValue>();
                newVehicle.Add("userID", vehicle["sk"]);
                newVehicle.Add("ID", new AttributeValue($"Vehicle{vehicle["sk"].S}"));
                newVehicle.Add("tag", new AttributeValue("Vehicle"));
                newVehicle.Add("vehicleID", vehicle["sk"]);
                newVehicle.Add("color", vehicle["color"]);
                newVehicle.Add("make", vehicle["make"]);
                newVehicle.Add("model", vehicle["model"]);
                newVehicle.Add("vehicleType", vehicle["vehicleType"]);
                newVehicle.Add("year", vehicle["year"]);
                if (vehicle.ContainsKey("licensePlate")) newVehicle.Add("licensePlate", vehicle["licensePlate"]);
                if (vehicle.ContainsKey("created")) newVehicle.Add("created", vehicle["created"]);
                if (vehicle.ContainsKey("modified")) newVehicle.Add("modified", vehicle["modified"]);
                if (vehicle.ContainsKey("status")) newVehicle.Add("status", vehicle["status"]);
                newVehicles.Add(newVehicle);
            }

            foreach (var user in users)
            {
                var userID = user["keyFob"].N.ToString();
                var newUser = new Dictionary<string, AttributeValue>();
                newUser.Add("userID", new AttributeValue(userID));
                newUser.Add("ID", new AttributeValue("User"));
                newUser.Add("tag", new AttributeValue("User"));
                if (user.ContainsKey("status")) newUser.Add("status", user["status"]);
                if (user.ContainsKey("NAME")) newUser.Add("NAME", user["NAME"]);
                if (user.ContainsKey("DISPLAY NAME")) newUser.Add("DISPLAY NAME", user["DISPLAY NAME"]);
                if (user.ContainsKey("PHONE NUMBER")) newUser.Add("PHONE NUMBER", user["PHONE NUMBER"]);
                if (user.ContainsKey("UNIT NO")) newUser.Add("UNIT NO", user["UNIT NO"]);
                if (user.ContainsKey("Access Level")) newUser.Add("Access Level", user["Access Level"]);
                if (user.ContainsKey("accessLevel")) newUser.Add("accessLevel", user["accessLevel"]);
                if (user.ContainsKey("reservedStatus")) newUser.Add("reservedStatus", user["reservedStatus"]);
                if (user.ContainsKey("created")) newUser.Add("created", user["created"]);
                if (user.ContainsKey("modified")) newUser.Add("modified", user["modified"]);
                newUsers.Add(newUser);

                var newKeyfob = new Dictionary<string, AttributeValue>();
                newKeyfob.Add("userID", new AttributeValue(userID));
                newKeyfob.Add("ID", new AttributeValue($"KeyFob{userID}"));
                newKeyfob.Add("tag", new AttributeValue("KeyFob"));
                newKeyfob.Add("kfLookup", new AttributeValue(userID));
                newKeyfob.Add("kfDisplay", new AttributeValue(userID));
                newKeyfobs.Add(newKeyfob);
            }

            var items = newVehicles.AddRangeAndReturn(newUsers).AddRangeAndReturn(newKeyfobs);
            Utils.BatchProcess.WriteItemsAsync(items);
            MessageBox.Show("Done", "InClave_Prod_Transfer", MessageBoxButtons.OK);
        }

        public static void ElCamino_Prod_Transfer()
        {
            string sourceTable = Manager.SourceTable.Name;
            if (sourceTable != "el-camino-keyfob-service-prod-KeyFobTable-8O1L874EBM5N") return;

            var scanResponse = Manager.Client.ScanAsync(sourceTable, new Dictionary<string, Condition>()).Result;

            var users = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Equals("KeyFob")));
            var zones = new List<Dictionary<string, AttributeValue>>(scanResponse.Items.Where(item => item.ContainsKey("sk") && item["sk"].S.Contains("Zone#")));
            var newKeyfobs = new List<Dictionary<string, AttributeValue>>();
            var newZones = new List<Dictionary<string, AttributeValue>>();
            var newUsers = new List<Dictionary<string, AttributeValue>>();

            foreach (var zone in zones)
            {
                var userID = users.First(user => user.ContainsKey("keyFob") && user["keyFob"].S.Equals(zone["keyFob"].S))["usrID"];
                
                var newZone = new Dictionary<string, AttributeValue>();
                newZone.Add("userID", userID);
                newZone.Add("zoneID", userID);
                newZone.Add("ID", new AttributeValue($"Zone{userID.S}"));
                newZone.Add("tag", new AttributeValue("Zone"));
                newZone.Add("authedStalls", zone["authedStalls"]);
                newZone.Add("checked", zone["checked"]);
                newZone.Add("status", zone["status"]);
                newZone.Add("created", zone["created"]);
                newZone.Add("modified", zone["modified"]);
                newZones.Add(newZone);
            }

            foreach (var user in users)
            {
                var newUser = new Dictionary<string, AttributeValue>();
                var keyfob = new Dictionary<string, AttributeValue>();
                string fobID = user["keyFob"].S;

                if (user["usrID"].S.Equals("1")) continue;

                if (user["reservedStatus"].S.Equals("Assigned")) {
                    newUser.Add("userID", user["usrID"]);
                    newUser.Add("ID", new AttributeValue("User"));
                    newUser.Add("tag", new AttributeValue("User"));
                    newUser.Add("firstName", user["firstName"]);
                    newUser.Add("lastName", user["lastName"]);
                    newUser.Add("cell", user["cell"]);
                    if (user.ContainsKey("state")) newUser.Add("state", user["state"]);
                    newUser.Add("status", user["status"]);
                    newUser.Add("created", user["created"]);
                    newUser.Add("modified", user["modified"]);
                    newUsers.Add(newUser);

                    keyfob.Add("userID", user["usrID"]);
                }
                else
                {
                    keyfob.Add("userID", new AttributeValue("0"));
                }
                keyfob.Add("ID", new AttributeValue($"KeyFob{fobID}"));
                keyfob.Add("tag", new AttributeValue("KeyFob"));
                keyfob.Add("kfLookup", new AttributeValue(fobID));
                keyfob.Add("kfDisplay", new AttributeValue(fobID));
                keyfob.Add("created", user["created"]);
                keyfob.Add("modified", user["modified"]);
                keyfob.Add("reservedStatus", user["reservedStatus"]);

                newKeyfobs.Add(keyfob);
            }

            var items = newUsers.AddRangeAndReturn(newZones).AddRangeAndReturn(newKeyfobs);
            Utils.BatchProcess.WriteItemsAsync(items);
            MessageBox.Show("Done", "ElCamino_Prod_Transfer", MessageBoxButtons.OK);
        }
    }
}
