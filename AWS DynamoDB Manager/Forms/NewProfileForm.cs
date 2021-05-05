using AWS_DynamoDB_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Forms
{
    public partial class NewProfileForm : Form
    {
        private StatusLabel _status;
        private string _name => aws_profileName_textBox.Text;
        private string _access => aws_id_textBox.Text;
        private string _secret => aws_secret_textBox.Text;
        private bool _encrypted => encrypt_checkBox.Checked;

        private bool _noStatus = true;

        public NewProfileForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            _status = new StatusLabel(status_label);
        }

        private async void create_btn_Click(object sender, EventArgs e)
        {
            Profiles.createProfile(_name, _access, _secret, _encrypted);
            cancel_btn.Enabled = false;
            create_btn.Enabled = false;
            aws_profileName_textBox.Text = string.Empty;
            aws_id_textBox.Text = string.Empty;
            aws_secret_textBox.Text = string.Empty;
            encrypt_checkBox.Checked = false;
            create_btn.Text = "Create";
            _status.Set("Success", Color.Green);
            await Task.Delay(1000);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayExisting()
        {
            if (_noStatus == false) return;

            _noStatus = true;
            if (string.IsNullOrWhiteSpace(_name)) return;

            if (Profiles.profileExists(_name, _encrypted))
            {
                _noStatus = false;
                _status.Set("Found Existing", Color.Green);
                create_btn.Text = "Update";
            }
            else
            {
                _status.Set("", Color.Green, false);
                create_btn.Text = "Create";
            }
        }

        private void UpdateCreateButtonState()
        {
            create_btn.Enabled = false;
            if (string.IsNullOrWhiteSpace(_name)) return;
            if (string.IsNullOrWhiteSpace(_access)) return;
            if (string.IsNullOrWhiteSpace(_secret)) return;
            create_btn.Enabled = true;
        }

        private void DisplayEmpty(string target)
        {
            _noStatus = true;
            _status.Set("", Color.Red, false);

            if (string.IsNullOrWhiteSpace(target)) {
                _noStatus = false;
                _status.Set("Invalid Params", Color.Red);
            }
        }

        private void aws_profileName_textBox_TextChanged(object sender, EventArgs e)
        {
            DisplayEmpty(_name);
            DisplayExisting();
            UpdateCreateButtonState();
        }

        private void aws_id_textBox_TextChanged(object sender, EventArgs e)
        {
            DisplayEmpty(_access);
            DisplayExisting();
            UpdateCreateButtonState();
        }

        private void aws_secret_textBox_TextChanged(object sender, EventArgs e)
        {
            DisplayEmpty(_secret);
            DisplayExisting();
            UpdateCreateButtonState();
        }

        private void encrypt_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            DisplayEmpty(_name);
            DisplayExisting();
            UpdateCreateButtonState();
        }
    }
}
