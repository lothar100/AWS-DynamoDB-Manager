
namespace AWS_DynamoDB_Manager.Forms
{
    partial class PreviewForm
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
            this.sourcePreview = new System.Windows.Forms.DataGridView();
            this.destinationPreview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePreview
            // 
            this.sourcePreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sourcePreview.EnableHeadersVisualStyles = false;
            this.sourcePreview.Location = new System.Drawing.Point(12, 12);
            this.sourcePreview.MultiSelect = false;
            this.sourcePreview.Name = "sourcePreview";
            this.sourcePreview.ReadOnly = true;
            this.sourcePreview.RowHeadersVisible = false;
            this.sourcePreview.RowTemplate.Height = 25;
            this.sourcePreview.Size = new System.Drawing.Size(776, 208);
            this.sourcePreview.TabIndex = 0;
            // 
            // destinationPreview
            // 
            this.destinationPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.destinationPreview.EnableHeadersVisualStyles = false;
            this.destinationPreview.Location = new System.Drawing.Point(12, 230);
            this.destinationPreview.MultiSelect = false;
            this.destinationPreview.Name = "destinationPreview";
            this.destinationPreview.ReadOnly = true;
            this.destinationPreview.RowHeadersVisible = false;
            this.destinationPreview.RowTemplate.Height = 25;
            this.destinationPreview.Size = new System.Drawing.Size(776, 208);
            this.destinationPreview.TabIndex = 1;
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.destinationPreview);
            this.Controls.Add(this.sourcePreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PreviewForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.sourcePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sourcePreview;
        private System.Windows.Forms.DataGridView destinationPreview;
    }
}