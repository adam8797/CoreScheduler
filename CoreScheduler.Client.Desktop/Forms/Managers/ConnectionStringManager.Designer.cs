namespace CoreScheduler.Client.Desktop.Forms
{
    partial class ConnectionStringManager
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
            this.comboType = new System.Windows.Forms.ComboBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
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
            this.DerivedPanel.Size = new System.Drawing.Size(337, 192);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(492, 192);
            this.splitContainer1.SplitterDistance = 151;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboType);
            this.groupBox1.Controls.Add(this.btnBuild);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConnectionString);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 192);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Options";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(9, 121);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(146, 21);
            this.comboType.TabIndex = 9;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(264, 73);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(65, 23);
            this.btnBuild.TabIndex = 8;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(323, 20);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection String";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(6, 75);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(252, 20);
            this.txtConnectionString.TabIndex = 1;
            // 
            // ConnectionStringManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 192);
            this.MinimumSize = new System.Drawing.Size(425, 150);
            this.Name = "ConnectionStringManager";
            this.Text = "ConnectionStringManager";
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
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectionString;
    }
}