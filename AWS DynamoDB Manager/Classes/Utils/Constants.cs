using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public static class Constants
    {
        public const string LOCK = "🔒";
        public const string LOCK_PREFIX = "🔒 ";

        public static IList<string> ATTRIBUTE_TYPES => new List<string>() { "B", "BOOL", "L", "M", "N", "NS", "NULL", "S", "SS" }.AsReadOnly();
    }
}
