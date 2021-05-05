using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Classes
{
    public class StatusLabel
    {
        private Label _statusLabel { get; set; }

        public StatusLabel(Label statusLabel)
        {
            _statusLabel = statusLabel;
        }

        public void Set(string text, Color color, bool visible = true)
        {
            _statusLabel.Text = text;
            _statusLabel.ForeColor = color;
            _statusLabel.Visible = visible;
        }
    }
}
