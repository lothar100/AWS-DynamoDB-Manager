using Amazon.DynamoDBv2.Model;
using AWS_DynamoDB_Manager.Classes;
using AWS_DynamoDB_Manager.Classes.Extensions;
using AWS_DynamoDB_Manager.Classes.Utils;
using AWS_DynamoDB_Manager.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager
{
    public partial class MainForm : Form
    {
        private ClientStatus _clientStatus;
        private SettingsForm _settings => new SettingsForm();
        private PreviewForm _preview => new PreviewForm();

        private string _sourceTable => (string)sourceTableCombo.SelectedValue;
        private string _destinationTable => (string)destinationTableCombo.SelectedValue;

        private List<string> _tableNames => Manager.Client.ListTablesAsync().Result.TableNames;
        private ScanResponse _sourceScan => Manager.Client.ScanAsync(_sourceTable, new Dictionary<string, Condition>()).Result;
        private ScanResponse _destinationScan => Manager.Client.ScanAsync(_destinationTable, new Dictionary<string, Condition>()).Result;

        private List<IOperation> _opList = new List<IOperation>();

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
            UpdateOpsTable();
            base.OnLoad(e);
        }

        public void CheckClient()
        {
            Manager.Settings.Load();

            profile_label.Text = $"AWS Profile: {Profiles.Current.Profile?.Name}";

            if (Manager.Client.Initialized)
            {
                System.Diagnostics.Debug.WriteLine("Client Initialized");
                UpdateTableSelection();
                UpdateEffectInputs();
                _clientStatus.SetSuccess();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Client Inactive");
                ClearInputs();
                _clientStatus.SetFailure();
            }
        }

        private void UpdateTableSelection()
        {
            var tableNames = _tableNames;
            sourceTableCombo.DataSource = new List<string>(tableNames);
            destinationTableCombo.DataSource = new List<string>(tableNames);

            sourceTableCombo.TrySelectingValue(Manager.Settings.defaultSourceTable);
            destinationTableCombo.TrySelectingValue(Manager.Settings.defaultDestinationTable);
        }

        private void ClearInputs()
        {
            sourceTableCombo.DataSource = null;
            destinationTableCombo.DataSource = null;
            sourceSchema_cb.DataSource = null;
            sourceValue_cb.DataSource = null;
            sourceType_cb1.DataSource = null;
            destinationSchema_cb.DataSource = null;
            destinationType_cb.DataSource = null;
        }

        private void UpdateEffectInputs()
        {
            var sourceScan = _sourceScan;
            var destinationScan = _destinationScan;
            var sourceKeyList = ConvertUtils.ToKeyList(sourceScan);
            var destinationKeyList = ConvertUtils.ToKeyList(destinationScan);

            sourceSchema_cb.DataSource = new List<string>(sourceKeyList);
            sourceValue_cb.DataSource = new List<string>(sourceKeyList);

            sourceType_cb1.DataSource = new FieldTypeFormat(sourceScan).BindingSource;
            sourceType_cb1.DisplayMember = "Key";
            sourceType_cb1.ValueMember = "Value";

            destinationSchema_cb.DataSource = new List<string>(destinationKeyList);

            destinationType_cb.DataSource = new List<string>(Constants.ATTRIBUTE_TYPES);
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
            var sourceField = (string)sourceSchema_cb.SelectedValue;
            var destinationField = (string)destinationSchema_cb.SelectedValue;

            _opList.Add(new SchemaOp(sourceField, destinationField));

            UpdateOpsTable();
        }

        private void value_btn_Click(object sender, EventArgs e)
        {
            var sourceField = (string)sourceValue_cb.SelectedValue;
            var oldValue = sourceValue_tb.Text;
            var newValue = destinationValue_tb.Text;

            _opList.Add(new ValueOp(sourceField, oldValue, newValue));

            UpdateOpsTable();
        }

        private void type_btn_Click(object sender, EventArgs e)
        {
            var sourceTypeSelection = (KeyValuePair<string, string>)sourceType_cb1.SelectedValue;
            var sourceField = sourceTypeSelection.Key;
            var oldType = sourceTypeSelection.Value;
            var newType = (string)destinationType_cb.SelectedValue;

            _opList.Add(new TypeOp(sourceField, oldType, newType));

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

        private void UpdateOpsTable()
        {
            Manager.SourceTable = Manager.Settings.defaultSourceTable;
            Manager.DestinationTable = Manager.Settings.defaultDestinationTable;
            operations_dgv.DataSource = ConvertUtils.ToDataSource(_opList);
            operations_dgv.ClearSelection();
            run_btn.Enabled = _opList.Count > 0;
        }

        private void Preview(int rowIndex)
        {
            if (rowIndex >= _opList.Count) return;

            Manager.OpRunner.Operations = _opList;
            Manager.OpRunner.OpIndex = rowIndex;
            Manager.OpRunner.SourceView = null;
            Manager.OpRunner.DestinationView = null;

            _preview.ShowDialog(this);
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
            if (_opList.Count == 0) return;
            _opList.RemoveAt(rowIndex);
            UpdateOpsTable();
        }

        private void sourceTableCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Manager.Settings.defaultSourceTable = _sourceTable;
            Manager.Settings.Save();
            _opList.Clear();
            UpdateOpsTable();
        }

        private void destinationTableCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Manager.Settings.defaultDestinationTable = _destinationTable;
            Manager.Settings.Save();
            _opList.Clear();
            UpdateOpsTable();
        }

        private void run_btn_Click(object sender, EventArgs e)
        {
            Manager.OpRunner.Operations = _opList;
            Manager.OpRunner.RunOperations();
            _opList.Clear();
            UpdateOpsTable();
        }
    }
}
