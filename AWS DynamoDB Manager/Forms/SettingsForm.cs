using AWS_DynamoDB_Manager.Classes;
using AWS_DynamoDB_Manager.Classes.Extensions;
using System;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Forms
{
    public partial class SettingsForm : Form
    {
        private NewProfileForm _newProfileForm => new NewProfileForm();

        private ProfileProps _props => new ProfileProps((string)profileCombo.SelectedValue);
        private string _profileName => _props.profileName;
        private string _profileSource => _props.profileSource;

        public SettingsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            profileCombo.DataSource = Profiles.ProfileNames;

            if(profileCombo.TrySelectingValue(Manager.Settings.PrefixedProfileName) == false)
            {
                profileCombo.TrySelectingValue("default");
            }

            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            Manager.ResetClient();
            (Owner as MainForm).CheckClient();
            base.OnClosed(e);
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Apply();
            
            Close();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Apply()
        {
            Manager.Settings.profileName = _profileName;
            Manager.Settings.profileSource = _profileSource;
            Manager.Settings.Save();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if(_newProfileForm.ShowDialog(this) == DialogResult.OK)
                profileCombo.DataSource = Profiles.ProfileNames;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Profiles.deleteProfile(_profileName, _profileSource.Equals("private"));
            profileCombo.DataSource = Profiles.ProfileNames;
            if (profileCombo.TrySelectingValue(Manager.Settings.PrefixedProfileName) == false)
            {
                profileCombo.TrySelectingValue("default");
            }
        }
    }
}
