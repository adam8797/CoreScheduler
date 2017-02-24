namespace CoreScheduler.Client.Desktop.Forms
{
    partial class CredentialManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCredName = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.DerivedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DerivedPanel
            // 
            this.DerivedPanel.Controls.Add(this.groupBox1);
            this.DerivedPanel.Size = new System.Drawing.Size(338, 218);
            this.DerivedPanel.UseWaitCursor = true;
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.UseWaitCursor = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.UseWaitCursor = true;
            this.splitContainer1.Size = new System.Drawing.Size(493, 218);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCredName);
            this.groupBox1.Controls.Add(this.chkShowPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 218);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            this.groupBox1.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Credential Name";
            this.label3.UseWaitCursor = true;
            // 
            // txtCredName
            // 
            this.txtCredName.Location = new System.Drawing.Point(6, 33);
            this.txtCredName.Name = "txtCredName";
            this.txtCredName.Size = new System.Drawing.Size(323, 20);
            this.txtCredName.TabIndex = 0;
            this.txtCredName.UseWaitCursor = true;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(227, 145);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowPassword.Size = new System.Drawing.Size(102, 17);
            this.chkShowPassword.TabIndex = 7;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.UseWaitCursor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            this.label2.UseWaitCursor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 162);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(323, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            this.label1.UseWaitCursor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(6, 75);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(323, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Domain";
            this.label4.UseWaitCursor = true;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(6, 119);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(323, 20);
            this.txtDomain.TabIndex = 9;
            this.txtDomain.UseWaitCursor = true;
            // 
            // CredentialManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 218);
            this.Name = "CredentialManager";
            this.Text = "CredentialManager";
            this.UseWaitCursor = true;
            this.DerivedPanel.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCredName;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDomain;
    }
}