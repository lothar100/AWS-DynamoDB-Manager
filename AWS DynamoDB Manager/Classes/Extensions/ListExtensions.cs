using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<T> AddRangeAndReturn<T>(this List<T> list, IEnumerable<T> collection)
        {
            list.AddRange(collection);
            return list;
        }

        public static List<T> MoveUpAt<T>(this List<T> list, int index)
        {
            if (index > list.Count || index < 1) return list;

            T temp = list[index - 1];
            list[index - 1] = list[index];
            list[index] = temp;

            return list;
        }

        public static List<T> MoveDownAt<T>(this List<T> list, int index)
        {
            if (index >= list.Count - 1 || index < 0) return list;

            T temp = list[index + 1];
            list[index + 1] = list[index];
            list[index] = temp;

            return list;
        }

        public static Dictionary<T, U> UniquePairs<T, U>(this List<Dictionary<T, U>> Items)
        {
            var unique_pairs = new Dictionary<T, U>();
            Items.ForEach((item) =>
            {
                var pairs = item.Where((pair) => unique_pairs.ContainsKey(pair.Key) == false).GetEnumerator();
                while (pairs.MoveNext()) unique_pairs.Add(pairs.Current.Key, pairs.Current.Value);
            });
            return unique_pairs;
        }
    }
}
