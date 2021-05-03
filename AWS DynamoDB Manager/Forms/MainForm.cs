using AWS_DynamoDB_Manager.Classes.Utils;
using AWS_DynamoDB_Manager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager
{
    public partial class MainForm : Form
    {
        private Settings _settings = new Settings();
        public MainForm()
        {
            InitializeComponent();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            _settings.Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
