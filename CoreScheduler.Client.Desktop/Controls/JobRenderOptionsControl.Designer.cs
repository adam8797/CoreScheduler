namespace CoreScheduler.Client.Desktop.Controls
{
    partial class JobRenderOptionsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkExportConn = new System.Windows.Forms.CheckBox();
            this.chkEncConn = new System.Windows.Forms.CheckBox();
            this.chkExportCred = new System.Windows.Forms.CheckBox();
            this.chkEncCred = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSecret);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkExportConn);
            this.groupBox3.Controls.Add(this.chkEncConn);
            this.groupBox3.Controls.Add(this.chkExportCred);
            this.groupBox3.Controls.Add(this.chkEncCred);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 138);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credentials";
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(19, 110);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.PasswordChar = '•';
            this.txtSecret.Size = new System.Drawing.Size(251, 20);
            this.txtSecret.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Secret";
            // 
            // chkExportConn
            // 
            this.chkExportConn.AutoSize = true;
            this.chkExportConn.Checked = true;
            this.chkExportConn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportConn.Location = new System.Drawing.Point(6, 57);
            this.chkExportConn.Name = "chkExportConn";
            this.chkExportConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExportConn.Size = new System.Drawing.Size(148, 17);
            this.chkExportConn.TabIndex = 12;
            this.chkExportConn.Text = "Export Connection Strings";
            this.chkExportConn.UseVisualStyleBackColor = true;
            this.chkExportConn.CheckedChanged += new System.EventHandler(this.chkExportConn_CheckedChanged);
            // 
            // chkEncConn
            // 
            this.chkEncConn.AutoSize = true;
            this.chkEncConn.Location = new System.Drawing.Point(17, 74);
            this.chkEncConn.Name = "chkEncConn";
            this.chkEncConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEncConn.Size = new System.Drawing.Size(154, 17);
            this.chkEncConn.TabIndex = 13;
            this.chkEncConn.Text = "Encrypt Connection Strings";
            this.chkEncConn.UseVisualStyleBackColor = true;
            // 
            // chkExportCred
            // 
            this.chkExportCred.AutoSize = true;
            this.chkExportCred.Checked = true;
            this.chkExportCred.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportCred.Location = new System.Drawing.Point(8, 19);
            this.chkExportCred.Name = "chkExportCred";
            this.chkExportCred.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExportCred.Size = new System.Drawing.Size(111, 17);
            this.chkExportCred.TabIndex = 10;
            this.chkExportCred.Text = "Export Credentials";
            this.chkExportCred.UseVisualStyleBackColor = true;
            this.chkExportCred.CheckedChanged += new System.EventHandler(this.chkExportCred_CheckedChanged);
            // 
            // chkEncCred
            // 
            this.chkEncCred.AutoSize = true;
            this.chkEncCred.Location = new System.Drawing.Point(17, 37);
            this.chkEncCred.Name = "chkEncCred";
            this.chkEncCred.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEncCred.Size = new System.Drawing.Size(117, 17);
            this.chkEncCred.TabIndex = 11;
            this.chkEncCred.Text = "Encrypt Credentials";
            this.chkEncCred.UseVisualStyleBackColor = true;
            // 
            // JobRenderOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "JobRenderOptionsControl";
            this.Size = new System.Drawing.Size(297, 144);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkExportConn;
        private System.Windows.Forms.CheckBox chkEncConn;
        private System.Windows.Forms.CheckBox chkExportCred;
        private System.Windows.Forms.CheckBox chkEncCred;
    }
}
