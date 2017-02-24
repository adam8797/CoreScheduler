namespace CoreScheduler.Client.Desktop.Forms
{
    partial class FireControlForm
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
            this.btnFire = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStream = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFire
            // 
            this.btnFire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFire.Location = new System.Drawing.Point(411, 129);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(75, 23);
            this.btnFire.TabIndex = 0;
            this.btnFire.Text = "Fire";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(330, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStream);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.chkEmail);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkStream
            // 
            this.chkStream.AutoSize = true;
            this.chkStream.Location = new System.Drawing.Point(16, 78);
            this.chkStream.Name = "chkStream";
            this.chkStream.Size = new System.Drawing.Size(135, 17);
            this.chkStream.TabIndex = 2;
            this.chkStream.Text = "Stream Console Output";
            this.chkStream.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(40, 42);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(428, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(16, 19);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(183, 17);
            this.chkEmail.TabIndex = 0;
            this.chkEmail.Text = "Send Email Upon Job Completion";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // FireControlForm
            // 
            this.AcceptButton = this.btnFire;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(498, 164);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFire);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FireControlForm";
            this.Text = "Fire Control";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkStream;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkEmail;
    }
}