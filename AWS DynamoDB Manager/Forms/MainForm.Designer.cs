
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
            this.destinationCombo = new AWS_DynamoDB_Manager.Classes.Controls.ImprovedComboBox();
            this.dest_label = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.statusGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
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
            this.showBtn.Location = new System.Drawing.Point(408, 72);
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
            // 
            // statusGroup
            // 
            this.statusGroup.Controls.Add(this.profile_label);
            this.statusGroup.Controls.Add(this.clientStatusMarker);
            this.statusGroup.Controls.Add(this.clientStatusLabel);
            this.statusGroup.Location = new System.Drawing.Point(576, 41);
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
            // destinationCombo
            // 
            this.destinationCombo.FormattingEnabled = true;
            this.destinationCombo.Location = new System.Drawing.Point(12, 116);
            this.destinationCombo.Name = "destinationCombo";
            this.destinationCombo.Size = new System.Drawing.Size(300, 23);
            this.destinationCombo.TabIndex = 7;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dest_label);
            this.Controls.Add(this.destinationCombo);
            this.Controls.Add(this.statusGroup);
            this.Controls.Add(this.sourceTableCombo);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.source_label);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "AWS DynamoDB Manager";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
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
        private Classes.Controls.ImprovedComboBox destinationCombo;
        private System.Windows.Forms.Label dest_label;
        private System.Windows.Forms.Label profile_label;
    }
}

