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
            this.SuspendLayout();
            // 
            // RequestBox
            // 
            this.RequestBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestBox.Location = new System.Drawing.Point(12, 12);
            this.RequestBox.Multiline = true;
            this.RequestBox.Name = "RequestBox";
            this.RequestBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RequestBox.Size = new System.Drawing.Size(444, 231);
            this.RequestBox.TabIndex = 0;
            // 
            // ResponseBox
            // 
            this.ResponseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseBox.Location = new System.Drawing.Point(12, 275);
            this.ResponseBox.Multiline = true;
            this.ResponseBox.Name = "ResponseBox";
            this.ResponseBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResponseBox.Size = new System.Drawing.Size(445, 239);
            this.ResponseBox.TabIndex = 1;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(41, 530);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(106, 55);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SkipBtn
            // 
            this.SkipBtn.Location = new System.Drawing.Point(153, 530);
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
            this.FileCheckBox.Location = new System.Drawing.Point(271, 541);
            this.FileCheckBox.Name = "FileCheckBox";
            this.FileCheckBox.Size = new System.Drawing.Size(185, 17);
            this.FileCheckBox.TabIndex = 4;
            this.FileCheckBox.Text = "Automatically send images/scripts";
            this.FileCheckBox.UseVisualStyleBackColor = true;
            this.FileCheckBox.CheckedChanged += new System.EventHandler(this.FileCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 610);
            this.Controls.Add(this.FileCheckBox);
            this.Controls.Add(this.SkipBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ResponseBox);
            this.Controls.Add(this.RequestBox);
            this.Name = "Form1";
            this.Text = "HTTProxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RequestBox;
        private System.Windows.Forms.TextBox ResponseBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button SkipBtn;
        private System.Windows.Forms.CheckBox FileCheckBox;
    }
}

