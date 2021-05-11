using AWS_DynamoDB_Manager.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AWS_DynamoDB_Manager.Forms
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Manager.OpRunner.RunPreview();
            sourcePreview.DataSource = Manager.OpRunner.SourceView;
            sourcePreview.ClearSelection();
            destinationPreview.DataSource = Manager.OpRunner.DestinationView;
            destinationPreview.ClearSelection();

            // coloring
            var operation = Manager.OpRunner.Operations[Manager.OpRunner.OpIndex];
            if(operation.Effect == OperationType.Schema)
            {
                SchemaOp schemaOp = (SchemaOp)operation;
                if (sourcePreview.Columns.Contains(schemaOp.SourceField))
                {
                    sourcePreview.Columns[schemaOp.SourceField].HeaderCell.Style.BackColor = Color.OrangeRed;
                }
                if (destinationPreview.Columns.Contains(schemaOp.DestinationField))
                {
                    destinationPreview.Columns[schemaOp.DestinationField].HeaderCell.Style.BackColor = Color.LimeGreen;
                }
            }

            base.OnLoad(e);
        }
    }
}
