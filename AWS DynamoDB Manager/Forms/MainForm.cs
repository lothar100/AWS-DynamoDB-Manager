using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes;
using AWS_DynamoDB_Manager.Classes.Extensions;
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
        private ClientStatus _clientStatus;
        private SettingsForm _settings => new SettingsForm();
        
        private string _sourceTable => (string)sourceTableCombo.SelectedValue;
        private string _destinationTable => (string)destinationTableCombo.SelectedValue;

        private List<string> _tableNames => Manager.Client.ListTablesAsync().Result.TableNames;
        private ScanResponse _sourceScan => Manager.Client.ScanAsync(_sourceTable, new Dictionary<string, Condition>()).Result;
        private ScanResponse _destinationScan => Manager.Client.ScanAsync(_destinationTable, new Dictionary<string, Condition>()).Result;

        private List<Operation> _opList = new List<Operation>();

        public MainForm()
        {
            InitializeComponent();
            _clientStatus = new ClientStatus(clientStatusMarker);
            sourceTableCombo.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => UpdateEffectInputs());
            destinationTableCombo.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => UpdateEffectInputs());
            col_preview.UseColumnTextForButtonValue = true;
            col_up.UseColumnTextForButtonValue = true;
            col_down.UseColumnTextForButtonValue = true;
            col_delete.UseColumnTextForButtonValue = true;
            foreach (DataGridViewColumn col in operations_dgv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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

                var tableNames = _tableNames;
                sourceTableCombo.DataSource = new List<string>(tableNames);
                destinationTableCombo.DataSource = new List<string>(tableNames);

                sourceTableCombo.TrySelectingValue(Manager.Settings.defaultSourceTable);
                destinationTableCombo.TrySelectingValue(Manager.Settings.defaultDestinationTable);

                UpdateEffectInputs();

                _clientStatus.SetSuccess();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Client Inactive");

                sourceTableCombo.DataSource = null;
                destinationTableCombo.DataSource = null;
                _clientStatus.SetFailure();
            }
        }

        private void UpdateEffectInputs()
        {
            var sourceSchemaList = ConvertUtils.ToStringList(_sourceScan);
            sourceSchema_cb1.DataSource = new List<string>(sourceSchemaList);
            sourceSchema_cb2.DataSource = new List<string>(sourceSchemaList);
            sourceSchema_cb3.DataSource = new List<string>(sourceSchemaList);

            var destinationSchemaList = ConvertUtils.ToStringList(_destinationScan);
            destinationSchema_cb1.DataSource = new List<string>(destinationSchemaList);
            destinationSchema_cb2.DataSource = new List<string>(destinationSchemaList);
            destinationSchema_cb3.DataSource = new List<string>(destinationSchemaList);
        }

        private void showBtn_Click(object sender, EventArgs e)
        {

            Manager.Settings.defaultSourceTable = _sourceTable;
            Manager.Settings.defaultDestinationTable = _destinationTable;
            Manager.Settings.Save();

            var describe = Manager.Client.DescribeTableAsync(_sourceTable).Result;
            var scan = Manager.Client.ScanAsync(_sourceTable, new Dictionary<string, Condition>()).Result;
            var attributes = new Dictionary<string, AttributeValue>()
            {
                { "pk", new AttributeValue { S = "100" } },
                { "sk", new AttributeValue { S = "User" } }
            };
            var item = Manager.Client.GetItemAsync(_sourceTable, attributes).Result;

            var stop = 0;
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ShowDialog(this);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void schema_btn_Click(object sender, EventArgs e)
        {
            var sourceField = (string)sourceSchema_cb1.SelectedValue;
            var destinationField = (string)destinationSchema_cb1.SelectedValue;

            _opList.Add(new Operation() { Effect = "Schema", Change = $"'{sourceField}' → '{destinationField}'" });

            UpdateOpsTable();
        }

        private void operations_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if(e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.ColumnIndex == col_preview.Index) Preview(e.RowIndex);
                if (e.ColumnIndex == col_up.Index) MoveUp(e.RowIndex);
                if (e.ColumnIndex == col_down.Index) MoveDown(e.RowIndex);
                if (e.ColumnIndex == col_delete.Index) Delete(e.RowIndex);
            }
        }

        private void UpdateOpsTable() => operations_dgv.DataSource = ConvertUtils.ToDataSource(_opList);

        private void Preview(int rowIndex)
        {

        }

        private void MoveUp(int rowIndex)
        {
            _opList.MoveUpAt(rowIndex);
            UpdateOpsTable();
        }

        private void MoveDown(int rowIndex)
        {
            _opList.MoveDownAt(rowIndex);
            UpdateOpsTable();
        }

        private void Delete(int rowIndex)
        {
            _opList.RemoveAt(rowIndex);
            UpdateOpsTable();
        }


    }
}
