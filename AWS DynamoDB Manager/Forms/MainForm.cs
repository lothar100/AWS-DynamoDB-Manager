using AWS_DynamoDB_Manager.Classes;
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
        private SettingsForm _settings => new SettingsForm();
        private ClientStatus _clientStatus;

        public MainForm()
        {
            InitializeComponent();
            _clientStatus = new ClientStatus(clientStatusMarker);
        }

        protected override void OnLoad(EventArgs e)
        {
            CheckClient();
            base.OnLoad(e);
        }

        public void CheckClient()
        {
            Manager.Settings.Load();

            profile_label.Text = $"AWS Profile: {Profiles.Current.Profile?.Name}";

            if (Manager.Client.Initialized)
            {
                System.Diagnostics.Debug.WriteLine("Client Initialized");

                var request = Manager.Client.ListTablesAsync();
                sourceTableCombo.DataSource = request.Result.TableNames;
                destinationCombo.DataSource = request.Result.TableNames;

                _clientStatus.SetSuccess();
            }
            else
            {
                sourceTableCombo.DataSource = null;
                destinationCombo.DataSource = null;
                _clientStatus.SetFailure();
            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ShowDialog(this);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
