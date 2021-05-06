using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes
{
    public class AppSettings
    {
        public string profileName { get; set; }
        public string profileSource { get; set; }
        public string defaultSourceTable { get; set; }
        public string defaultDestinationTable { get; set; }

        internal void Save()
        {
            App.Default["profileName"] = profileName;
            App.Default["profileSource"] = profileSource;
            App.Default["defaultSourceTable"] = defaultSourceTable;
            App.Default["defaultDestinationTable"] = defaultDestinationTable;
            App.Default.Save();
        }

        internal void Load()
        {
            profileName = App.Default.profileName;
            profileSource = App.Default.profileSource;
            defaultSourceTable = App.Default.defaultSourceTable;
            defaultDestinationTable = App.Default.defaultDestinationTable;
        }

        public string PrefixedProfileName => getPrefixedName();

        private string getPrefixedName()
        {
            if (profileSource.Equals("private")) return "🔒 " + profileName;
            return profileName;
        }
    }
}
