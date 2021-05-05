using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Classes.Extensions
{
    public static class ComboBoxExtensions
    {
        public static bool TrySelectingValue(this ComboBox comboBox, string value)
        {
            int index = comboBox.FindString(value);
            if (index == -1)
            {
                return false;
            }
            else
            {
                comboBox.SelectedIndex = index;
                return true;
            }
        }
    }
}
