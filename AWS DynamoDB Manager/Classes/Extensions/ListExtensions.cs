using System;
using System.Collections.Generic;
using System.Text;

namespace AWS_DynamoDB_Manager.Classes.Extensions
{
    public static class ListExtensions
    {
        public static List<string> PrefixAll(this List<string> list, string prefix)
        {
            for(int i = 0; i < list.Count; i++)
            {
                list[i] = prefix + list[i];
            }
            return list;
        }
    }
}
