using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Classes
{
    public class ClientStatus : StatusLabel
    {
        public ClientStatus(Label statusLabel) : base(statusLabel) { }

        public void SetSuccess() => Set("✓", Color.Green);
        public void SetFailure() => Set("X", Color.Red);
        public void SetPending() => Set("...", Color.Black);
    }
}
