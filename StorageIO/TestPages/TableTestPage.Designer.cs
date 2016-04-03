namespace StorageIO
{
    partial class TableTestPage
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
            this.tableTest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tableTest)).BeginInit();
            this.SuspendLayout();
            // 
            // tableTest
            // 
            this.tableTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTest.Location = new System.Drawing.Point(12, 12);
            this.tableTest.Name = "tableTest";
            this.tableTest.RowTemplate.Height = 23;
            this.tableTest.Size = new System.Drawing.Size(748, 550);
            this.tableTest.TabIndex = 0;
            // 
            // TableTestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 574);
            this.Controls.Add(this.tableTest);
            this.Name = "TableTestPage";
            this.Text = "TableTestPage";
            ((System.ComponentModel.ISupportInitialize)(this.tableTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tableTest;
    }
}