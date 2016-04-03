namespace StorageIO
{
    partial class FliterSettingPage
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
            this.fliterTypeBox = new System.Windows.Forms.ComboBox();
            this.fliterInputBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fliterTypeBox
            // 
            this.fliterTypeBox.FormattingEnabled = true;
            this.fliterTypeBox.Items.AddRange(new object[] {
            "=",
            ">",
            "<"});
            this.fliterTypeBox.Location = new System.Drawing.Point(12, 12);
            this.fliterTypeBox.Name = "fliterTypeBox";
            this.fliterTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fliterTypeBox.Size = new System.Drawing.Size(31, 20);
            this.fliterTypeBox.TabIndex = 0;
            this.fliterTypeBox.Text = "=";
            // 
            // fliterInputBox
            // 
            this.fliterInputBox.Location = new System.Drawing.Point(49, 11);
            this.fliterInputBox.Name = "fliterInputBox";
            this.fliterInputBox.Size = new System.Drawing.Size(376, 21);
            this.fliterInputBox.TabIndex = 1;
            this.fliterInputBox.Text = "请输入要查找的文字，所有包含这串文字的项目都会被显示出来。";
            this.fliterInputBox.Enter += new System.EventHandler(this.fliterInputBox_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定并关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "清空输入框可以取消该列的条件限制。";
            // 
            // FliterSettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 73);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fliterInputBox);
            this.Controls.Add(this.fliterTypeBox);
            this.Name = "FliterSettingPage";
            this.Text = "设置过滤器 - ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fliterTypeBox;
        private System.Windows.Forms.TextBox fliterInputBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}