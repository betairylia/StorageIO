namespace StorageIO
{
    partial class socketTestPage
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
            this.requestBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.serverAddrTextBox = new System.Windows.Forms.TextBox();
            this.requestIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverAddrLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // requestBtn
            // 
            this.requestBtn.Location = new System.Drawing.Point(197, 12);
            this.requestBtn.Name = "requestBtn";
            this.requestBtn.Size = new System.Drawing.Size(75, 23);
            this.requestBtn.TabIndex = 0;
            this.requestBtn.Text = "Request";
            this.requestBtn.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(197, 226);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // serverAddrTextBox
            // 
            this.serverAddrTextBox.Location = new System.Drawing.Point(12, 228);
            this.serverAddrTextBox.Name = "serverAddrTextBox";
            this.serverAddrTextBox.Size = new System.Drawing.Size(179, 20);
            this.serverAddrTextBox.TabIndex = 2;
            // 
            // requestIDTextBox
            // 
            this.requestIDTextBox.Location = new System.Drawing.Point(76, 12);
            this.requestIDTextBox.Name = "requestIDTextBox";
            this.requestIDTextBox.Size = new System.Drawing.Size(115, 20);
            this.requestIDTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "RequestID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Response:";
            // 
            // resLabel
            // 
            this.resLabel.AutoSize = true;
            this.resLabel.Location = new System.Drawing.Point(156, 50);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(35, 13);
            this.resLabel.TabIndex = 6;
            this.resLabel.Text = "label3";
            this.resLabel.Click += new System.EventHandler(this.resLabel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server Address:";
            // 
            // serverAddrLabel
            // 
            this.serverAddrLabel.AutoSize = true;
            this.serverAddrLabel.Location = new System.Drawing.Point(100, 187);
            this.serverAddrLabel.Name = "serverAddrLabel";
            this.serverAddrLabel.Size = new System.Drawing.Size(35, 13);
            this.serverAddrLabel.TabIndex = 8;
            this.serverAddrLabel.Text = "label4";
            // 
            // socketTestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.serverAddrLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.requestIDTextBox);
            this.Controls.Add(this.serverAddrTextBox);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.requestBtn);
            this.Name = "socketTestPage";
            this.Text = "socketTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox serverAddrTextBox;
        private System.Windows.Forms.TextBox requestIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label serverAddrLabel;
    }
}

