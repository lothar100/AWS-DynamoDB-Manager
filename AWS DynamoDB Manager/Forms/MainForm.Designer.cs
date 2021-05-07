
namespace AWS_DynamoDB_Manager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.source_label = new System.Windows.Forms.Label();
            this.showBtn = new System.Windows.Forms.Button();
            this.sourceTableCombo = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.profile_label = new System.Windows.Forms.Label();
            this.clientStatusMarker = new System.Windows.Forms.Label();
            this.clientStatusLabel = new System.Windows.Forms.Label();
            this.destinationTableCombo = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.dest_label = new System.Windows.Forms.Label();
            this.operations_dgv = new System.Windows.Forms.DataGridView();
            this.col_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_effect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_preview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_down = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sourceSchema_cb = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.destinationSchema_cb = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.schema_btn = new System.Windows.Forms.Button();
            this.value_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceValue_tb = new System.Windows.Forms.TextBox();
            this.destinationValue_tb = new System.Windows.Forms.TextBox();
            this.sourceValue_cb = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.type_btn = new System.Windows.Forms.Button();
            this.sourceType_cb1 = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.destinationType_cb = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.statusGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operations_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(624, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "main menu";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsMenuItem.Text = "Settings...";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // source_label
            // 
            this.source_label.AutoSize = true;
            this.source_label.Location = new System.Drawing.Point(12, 53);
            this.source_label.Name = "source_label";
            this.source_label.Size = new System.Drawing.Size(73, 15);
            this.source_label.TabIndex = 1;
            this.source_label.Text = "Source Table";
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(7, 59);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(75, 23);
            this.showBtn.TabIndex = 3;
            this.showBtn.Text = "Test";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // sourceTableCombo
            // 
            this.sourceTableCombo.FormattingEnabled = true;
            this.sourceTableCombo.Location = new System.Drawing.Point(12, 72);
            this.sourceTableCombo.Name = "sourceTableCombo";
            this.sourceTableCombo.Size = new System.Drawing.Size(300, 23);
            this.sourceTableCombo.TabIndex = 5;
            this.sourceTableCombo.SelectionChangeCommitted += new System.EventHandler(this.sourceTableCombo_SelectionChangeCommitted);
            // 
            // statusGroup
            // 
            this.statusGroup.Controls.Add(this.profile_label);
            this.statusGroup.Controls.Add(this.clientStatusMarker);
            this.statusGroup.Controls.Add(this.clientStatusLabel);
            this.statusGroup.Controls.Add(this.showBtn);
            this.statusGroup.Location = new System.Drawing.Point(386, 39);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(200, 100);
            this.statusGroup.TabIndex = 6;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Status";
            // 
            // profile_label
            // 
            this.profile_label.AutoSize = true;
            this.profile_label.Location = new System.Drawing.Point(7, 23);
            this.profile_label.Name = "profile_label";
            this.profile_label.Size = new System.Drawing.Size(71, 15);
            this.profile_label.TabIndex = 2;
            this.profile_label.Text = "AWS Profile:";
            // 
            // clientStatusMarker
            // 
            this.clientStatusMarker.AutoSize = true;
            this.clientStatusMarker.Location = new System.Drawing.Point(95, 38);
            this.clientStatusMarker.Name = "clientStatusMarker";
            this.clientStatusMarker.Size = new System.Drawing.Size(16, 15);
            this.clientStatusMarker.TabIndex = 1;
            this.clientStatusMarker.Text = "...";
            // 
            // clientStatusLabel
            // 
            this.clientStatusLabel.AutoSize = true;
            this.clientStatusLabel.Location = new System.Drawing.Point(7, 38);
            this.clientStatusLabel.Name = "clientStatusLabel";
            this.clientStatusLabel.Size = new System.Drawing.Size(91, 15);
            this.clientStatusLabel.TabIndex = 0;
            this.clientStatusLabel.Text = "Client Initialized";
            // 
            // destinationTableCombo
            // 
            this.destinationTableCombo.FormattingEnabled = true;
            this.destinationTableCombo.Location = new System.Drawing.Point(12, 116);
            this.destinationTableCombo.Name = "destinationTableCombo";
            this.destinationTableCombo.Size = new System.Drawing.Size(300, 23);
            this.destinationTableCombo.TabIndex = 7;
            this.destinationTableCombo.SelectionChangeCommitted += new System.EventHandler(this.destinationTableCombo_SelectionChangeCommitted);
            // 
            // dest_label
            // 
            this.dest_label.AutoSize = true;
            this.dest_label.Location = new System.Drawing.Point(12, 98);
            this.dest_label.Name = "dest_label";
            this.dest_label.Size = new System.Drawing.Size(97, 15);
            this.dest_label.TabIndex = 8;
            this.dest_label.Text = "Destination Table";
            // 
            // operations_dgv
            // 
            this.operations_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.operations_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operations_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_order,
            this.col_effect,
            this.col_change,
            this.col_preview,
            this.col_up,
            this.col_down,
            this.col_delete});
            this.operations_dgv.Location = new System.Drawing.Point(12, 162);
            this.operations_dgv.MultiSelect = false;
            this.operations_dgv.Name = "operations_dgv";
            this.operations_dgv.ReadOnly = true;
            this.operations_dgv.RowHeadersVisible = false;
            this.operations_dgv.RowTemplate.Height = 25;
            this.operations_dgv.Size = new System.Drawing.Size(596, 106);
            this.operations_dgv.TabIndex = 9;
            this.operations_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.operations_dgv_CellContentClick);
            // 
            // col_order
            // 
            this.col_order.DataPropertyName = "Order";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_order.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_order.FillWeight = 3.5F;
            this.col_order.HeaderText = "Order";
            this.col_order.MinimumWidth = 45;
            this.col_order.Name = "col_order";
            this.col_order.ReadOnly = true;
            // 
            // col_effect
            // 
            this.col_effect.DataPropertyName = "Effect";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_effect.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_effect.FillWeight = 10F;
            this.col_effect.HeaderText = "Effect";
            this.col_effect.MinimumWidth = 100;
            this.col_effect.Name = "col_effect";
            this.col_effect.ReadOnly = true;
            // 
            // col_change
            // 
            this.col_change.DataPropertyName = "Change";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_change.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_change.FillWeight = 10F;
            this.col_change.HeaderText = "Change";
            this.col_change.MinimumWidth = 100;
            this.col_change.Name = "col_change";
            this.col_change.ReadOnly = true;
            // 
            // col_preview
            // 
            this.col_preview.FillWeight = 7F;
            this.col_preview.HeaderText = "";
            this.col_preview.Name = "col_preview";
            this.col_preview.ReadOnly = true;
            this.col_preview.Text = "Preview";
            // 
            // col_up
            // 
            this.col_up.FillWeight = 2F;
            this.col_up.HeaderText = "";
            this.col_up.Name = "col_up";
            this.col_up.ReadOnly = true;
            this.col_up.Text = "↑";
            // 
            // col_down
            // 
            this.col_down.FillWeight = 2F;
            this.col_down.HeaderText = "";
            this.col_down.Name = "col_down";
            this.col_down.ReadOnly = true;
            this.col_down.Text = "↓";
            // 
            // col_delete
            // 
            this.col_delete.FillWeight = 5F;
            this.col_delete.HeaderText = "";
            this.col_delete.Name = "col_delete";
            this.col_delete.ReadOnly = true;
            this.col_delete.Text = "Delete";
            // 
            // sourceSchema_cb
            // 
            this.sourceSchema_cb.FormattingEnabled = true;
            this.sourceSchema_cb.Location = new System.Drawing.Point(163, 296);
            this.sourceSchema_cb.Name = "sourceSchema_cb";
            this.sourceSchema_cb.Size = new System.Drawing.Size(121, 23);
            this.sourceSchema_cb.TabIndex = 10;
            // 
            // destinationSchema_cb
            // 
            this.destinationSchema_cb.FormattingEnabled = true;
            this.destinationSchema_cb.Location = new System.Drawing.Point(314, 296);
            this.destinationSchema_cb.Name = "destinationSchema_cb";
            this.destinationSchema_cb.Size = new System.Drawing.Size(121, 23);
            this.destinationSchema_cb.TabIndex = 11;
            // 
            // schema_btn
            // 
            this.schema_btn.Location = new System.Drawing.Point(464, 296);
            this.schema_btn.Name = "schema_btn";
            this.schema_btn.Size = new System.Drawing.Size(144, 23);
            this.schema_btn.TabIndex = 12;
            this.schema_btn.Text = "Add Schema Effect";
            this.schema_btn.UseVisualStyleBackColor = true;
            this.schema_btn.Click += new System.EventHandler(this.schema_btn_Click);
            // 
            // value_btn
            // 
            this.value_btn.Location = new System.Drawing.Point(464, 397);
            this.value_btn.Name = "value_btn";
            this.value_btn.Size = new System.Drawing.Size(144, 23);
            this.value_btn.TabIndex = 13;
            this.value_btn.Text = "Add Value Effect";
            this.value_btn.UseVisualStyleBackColor = true;
            this.value_btn.Click += new System.EventHandler(this.value_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "to";
            // 
            // sourceValue_tb
            // 
            this.sourceValue_tb.Location = new System.Drawing.Point(163, 397);
            this.sourceValue_tb.Name = "sourceValue_tb";
            this.sourceValue_tb.Size = new System.Drawing.Size(121, 23);
            this.sourceValue_tb.TabIndex = 15;
            // 
            // destinationValue_tb
            // 
            this.destinationValue_tb.Location = new System.Drawing.Point(314, 397);
            this.destinationValue_tb.Name = "destinationValue_tb";
            this.destinationValue_tb.Size = new System.Drawing.Size(121, 23);
            this.destinationValue_tb.TabIndex = 16;
            // 
            // sourceValue_cb
            // 
            this.sourceValue_cb.FormattingEnabled = true;
            this.sourceValue_cb.Location = new System.Drawing.Point(12, 397);
            this.sourceValue_cb.Name = "sourceValue_cb";
            this.sourceValue_cb.Size = new System.Drawing.Size(121, 23);
            this.sourceValue_cb.TabIndex = 17;
            // 
            // type_btn
            // 
            this.type_btn.Location = new System.Drawing.Point(464, 345);
            this.type_btn.Name = "type_btn";
            this.type_btn.Size = new System.Drawing.Size(144, 23);
            this.type_btn.TabIndex = 19;
            this.type_btn.Text = "Add Type Effect";
            this.type_btn.UseVisualStyleBackColor = true;
            this.type_btn.Click += new System.EventHandler(this.type_btn_Click);
            // 
            // sourceType_cb1
            // 
            this.sourceType_cb1.FormattingEnabled = true;
            this.sourceType_cb1.Location = new System.Drawing.Point(163, 345);
            this.sourceType_cb1.Name = "sourceType_cb1";
            this.sourceType_cb1.Size = new System.Drawing.Size(121, 23);
            this.sourceType_cb1.TabIndex = 20;
            // 
            // destinationType_cb
            // 
            this.destinationType_cb.FormattingEnabled = true;
            this.destinationType_cb.Location = new System.Drawing.Point(314, 345);
            this.destinationType_cb.Name = "destinationType_cb";
            this.destinationType_cb.Size = new System.Drawing.Size(121, 23);
            this.destinationType_cb.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "to";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 488);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationType_cb);
            this.Controls.Add(this.sourceType_cb1);
            this.Controls.Add(this.type_btn);
            this.Controls.Add(this.sourceValue_cb);
            this.Controls.Add(this.destinationValue_tb);
            this.Controls.Add(this.sourceValue_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.value_btn);
            this.Controls.Add(this.schema_btn);
            this.Controls.Add(this.destinationSchema_cb);
            this.Controls.Add(this.sourceSchema_cb);
            this.Controls.Add(this.operations_dgv);
            this.Controls.Add(this.dest_label);
            this.Controls.Add(this.destinationTableCombo);
            this.Controls.Add(this.statusGroup);
            this.Controls.Add(this.sourceTableCombo);
            this.Controls.Add(this.source_label);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWS DynamoDB Manager";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operations_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Label source_label;
        private System.Windows.Forms.Button showBtn;
        private Classes.Controls.ImprovedComboBox sourceTableCombo;
        private System.Windows.Forms.GroupBox statusGroup;
        private System.Windows.Forms.Label clientStatusMarker;
        private System.Windows.Forms.Label clientStatusLabel;
        private Classes.Controls.ImprovedComboBox destinationTableCombo;
        private System.Windows.Forms.Label dest_label;
        private System.Windows.Forms.Label profile_label;
        private System.Windows.Forms.DataGridView operations_dgv;
        private Classes.Controls.ImprovedComboBox sourceSchema_cb;
        private Classes.Controls.ImprovedComboBox destinationSchema_cb;
        private System.Windows.Forms.Button schema_btn;
        private System.Windows.Forms.Button value_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sourceValue_tb;
        private System.Windows.Forms.TextBox destinationValue_tb;
        private Classes.Controls.ImprovedComboBox sourceValue_cb;
        private System.Windows.Forms.Button type_btn;
        private Classes.Controls.ImprovedComboBox sourceType_cb1;
        private Classes.Controls.ImprovedComboBox destinationType_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_effect;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_change;
        private System.Windows.Forms.DataGridViewButtonColumn col_preview;
        private System.Windows.Forms.DataGridViewButtonColumn col_up;
        private System.Windows.Forms.DataGridViewButtonColumn col_down;
        private System.Windows.Forms.DataGridViewButtonColumn col_delete;
    }
}

