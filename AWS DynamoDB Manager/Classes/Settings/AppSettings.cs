using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class AppSettings
    {
        public string profileName { get; set; }
        public string profileSource { get; set; }

        internal void Save()
        {
            App.Default["profileName"] = profileName;
            App.Default["profileSource"] = profileSource;
            App.Default.Save();
        }

        internal void Load()
        {
            profileName = App.Default.profileName;
            profileSource = App.Default.profileSource;
        }

        public string PrefixedProfileName => getPrefixedName();

        private string getPrefixedName()
        {
            if (profileSource.Equals("private")) return "🔒 " + profileName;
            return profileName;
        }
    }
}
