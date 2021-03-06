using Amazon.Runtime.CredentialManagement;
using AWS_DynamoDB_Manager.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class ProfileProps
    {
        public ProfileProps(string input)
        {
            if (input.Contains(Constants.LOCK))
            {
                profileSource = "private";
                profileName = input.Replace(Constants.LOCK_PREFIX, string.Empty);
            }
            else
            {
                profileSource = "public";
                profileName = input;
            }
        }
        public string profileName { get; set; }
        public string profileSource { get; set; }
    }
}
