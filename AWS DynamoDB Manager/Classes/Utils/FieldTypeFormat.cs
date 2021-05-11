using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Classes.Utils
{
    public class FieldTypeFormat
    {
        private Dictionary<string, KeyValuePair<string, string>> AttributeDictionary;
        public BindingSource BindingSource => new BindingSource(AttributeDictionary, null);

        public FieldTypeFormat(ScanResponse response)
        {
            AttributeDictionary = formatScan(response);
        }

        private Dictionary<string, KeyValuePair<string, string>> formatScan(ScanResponse response)
        {
            return response.Items.UniquePairs()
                .ToDictionary(pair => pair.Key, pair => pair.Value.GetTypeString())
                .ToDictionary(pair => $"{pair.Key}: {{{pair.Value}}}", pair => KeyValuePair.Create(pair.Key, pair.Value));
        }
    }
}
