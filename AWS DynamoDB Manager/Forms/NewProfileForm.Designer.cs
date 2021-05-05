
namespace AWS_DynamoDB_Manager.Forms
{
    partial class NewProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancel_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.aws_id_label = new System.Windows.Forms.Label();
            this.aws_secret_label = new System.Windows.Forms.Label();
            this.encrypt_checkBox = new System.Windows.Forms.CheckBox();
            this.aws_id_textBox = new System.Windows.Forms.TextBox();
            this.aws_secret_textBox = new System.Windows.Forms.TextBox();
            this.aws_profileName_textBox = new System.Windows.Forms.TextBox();
            this.aws_profileName_label = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.Location = new System.Drawing.Point(238, 187);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 0;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // create_btn
            // 
            this.create_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.create_btn.Enabled = false;
            this.create_btn.Location = new System.Drawing.Point(157, 187);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(75, 23);
            this.create_btn.TabIndex = 1;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // aws_id_label
            // 
            this.aws_id_label.AutoSize = true;
            this.aws_id_label.Location = new System.Drawing.Point(12, 61);
            this.aws_id_label.Name = "aws_id_label";
            this.aws_id_label.Size = new System.Drawing.Size(106, 15);
            this.aws_id_label.TabIndex = 2;
            this.aws_id_label.Text = "AWS Access Key ID";
            // 
            // aws_secret_label
            // 
            this.aws_secret_label.AutoSize = true;
            this.aws_secret_label.Location = new System.Drawing.Point(12, 114);
            this.aws_secret_label.Name = "aws_secret_label";
            this.aws_secret_label.Size = new System.Drawing.Size(127, 15);
            this.aws_secret_label.TabIndex = 3;
            this.aws_secret_label.Text = "AWS Secret Access Key";
            // 
            // encrypt_checkBox
            // 
            this.encrypt_checkBox.AutoSize = true;
            this.encrypt_checkBox.Location = new System.Drawing.Point(13, 166);
            this.encrypt_checkBox.Name = "encrypt_checkBox";
            this.encrypt_checkBox.Size = new System.Drawing.Size(128, 19);
            this.encrypt_checkBox.TabIndex = 4;
            this.encrypt_checkBox.Text = "Encrypt Credentials";
            this.encrypt_checkBox.UseVisualStyleBackColor = true;
            this.encrypt_checkBox.CheckedChanged += new System.EventHandler(this.encrypt_checkBox_CheckedChanged);
            // 
            // aws_id_textBox
            // 
            this.aws_id_textBox.Location = new System.Drawing.Point(12, 79);
            this.aws_id_textBox.Name = "aws_id_textBox";
            this.aws_id_textBox.Size = new System.Drawing.Size(301, 23);
            this.aws_id_textBox.TabIndex = 5;
            this.aws_id_textBox.TextChanged += new System.EventHandler(this.aws_id_textBox_TextChanged);
            // 
            // aws_secret_textBox
            // 
            this.aws_secret_textBox.Location = new System.Drawing.Point(12, 132);
            this.aws_secret_textBox.Name = "aws_secret_textBox";
            this.aws_secret_textBox.Size = new System.Drawing.Size(301, 23);
            this.aws_secret_textBox.TabIndex = 6;
            this.aws_secret_textBox.TextChanged += new System.EventHandler(this.aws_secret_textBox_TextChanged);
            // 
            // aws_profileName_textBox
            // 
            this.aws_profileName_textBox.Location = new System.Drawing.Point(11, 28);
            this.aws_profileName_textBox.Name = "aws_profileName_textBox";
            this.aws_profileName_textBox.Size = new System.Drawing.Size(301, 23);
            this.aws_profileName_textBox.TabIndex = 8;
            this.aws_profileName_textBox.TextChanged += new System.EventHandler(this.aws_profileName_textBox_TextChanged);
            // 
            // aws_profileName_label
            // 
            this.aws_profileName_label.AutoSize = true;
            this.aws_profileName_label.Location = new System.Drawing.Point(11, 10);
            this.aws_profileName_label.Name = "aws_profileName_label";
            this.aws_profileName_label.Size = new System.Drawing.Size(76, 15);
            this.aws_profileName_label.TabIndex = 7;
            this.aws_profileName_label.Text = "Profile Name";
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.ForeColor = System.Drawing.Color.Green;
            this.status_label.Location = new System.Drawing.Point(53, 191);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(48, 15);
            this.status_label.TabIndex = 9;
            this.status_label.Text = "Success";
            this.status_label.Visible = false;
            // 
            // NewProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 222);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.aws_profileName_textBox);
            this.Controls.Add(this.aws_profileName_label);
            this.Controls.Add(this.aws_secret_textBox);
            this.Controls.Add(this.aws_id_textBox);
            this.Controls.Add(this.encrypt_checkBox);
            this.Controls.Add(this.aws_secret_label);
            this.Controls.Add(this.aws_id_label);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.cancel_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProfileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AWS Profile";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Label aws_id_label;
        private System.Windows.Forms.Label aws_secret_label;
        private System.Windows.Forms.CheckBox encrypt_checkBox;
        private System.Windows.Forms.TextBox aws_id_textBox;
        private System.Windows.Forms.TextBox aws_secret_textBox;
        private System.Windows.Forms.TextBox aws_profileName_textBox;
        private System.Windows.Forms.Label aws_profileName_label;
        private System.Windows.Forms.Label status_label;
    }
}