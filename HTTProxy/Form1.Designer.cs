namespace HTTProxy
{
    partial class Form1
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
            this.RequestBox = new System.Windows.Forms.TextBox();
            this.ResponseBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SkipBtn = new System.Windows.Forms.Button();
            this.FileCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RequestBox
            // 
            this.RequestBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestBox.Location = new System.Drawing.Point(12, 88);
            this.RequestBox.Multiline = true;
            this.RequestBox.Name = "RequestBox";
            this.RequestBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RequestBox.Size = new System.Drawing.Size(444, 231);
            this.RequestBox.TabIndex = 0;
            // 
            // ResponseBox
            // 
            this.ResponseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseBox.Location = new System.Drawing.Point(12, 351);
            this.ResponseBox.Multiline = true;
            this.ResponseBox.Name = "ResponseBox";
            this.ResponseBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResponseBox.Size = new System.Drawing.Size(445, 239);
            this.ResponseBox.TabIndex = 1;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(41, 606);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(106, 55);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SkipBtn
            // 
            this.SkipBtn.Location = new System.Drawing.Point(153, 606);
            this.SkipBtn.Name = "SkipBtn";
            this.SkipBtn.Size = new System.Drawing.Size(95, 55);
            this.SkipBtn.TabIndex = 3;
            this.SkipBtn.Text = "Skip";
            this.SkipBtn.UseVisualStyleBackColor = true;
            this.SkipBtn.Click += new System.EventHandler(this.SkipBtn_Click);
            // 
            // FileCheckBox
            // 
            this.FileCheckBox.AutoSize = true;
            this.FileCheckBox.Checked = true;
            this.FileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FileCheckBox.Location = new System.Drawing.Point(271, 617);
            this.FileCheckBox.Name = "FileCheckBox";
            this.FileCheckBox.Size = new System.Drawing.Size(197, 17);
            this.FileCheckBox.TabIndex = 4;
            this.FileCheckBox.Text = "Automatically receive images/scripts";
            this.FileCheckBox.UseVisualStyleBackColor = true;
            this.FileCheckBox.CheckedChanged += new System.EventHandler(this.FileCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proxy on port: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Request:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Response:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 678);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileCheckBox);
            this.Controls.Add(this.SkipBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ResponseBox);
            this.Controls.Add(this.RequestBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "HTTProxy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RequestBox;
        private System.Windows.Forms.TextBox ResponseBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button SkipBtn;
        private System.Windows.Forms.CheckBox FileCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

