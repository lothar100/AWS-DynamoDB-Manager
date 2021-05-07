using AWS_DynamoDB_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            Manager.Preview.GenerateViews();
            sourcePreview.DataSource = Manager.Preview.SourceView;
            sourcePreview.ClearSelection();
            destinationPreview.DataSource = Manager.Preview.DestinationView;
            destinationPreview.ClearSelection();
            base.OnLoad(e);
        }
    }
}
