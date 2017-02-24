namespace CoreScheduler.Client.Desktop.Controls
{
    partial class ContextOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextOptions));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listSql = new EditableList();
            this.listCredentials = new EditableList();
            this.chkIncludeCredentials = new System.Windows.Forms.CheckBox();
            this.chkIncludeJobEvents = new System.Windows.Forms.CheckBox();
            this.chkIncludeLogger = new System.Windows.Forms.CheckBox();
            this.chkSqlEnable = new System.Windows.Forms.CheckBox();
            this.chkContextEnable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listSql);
            this.groupBox2.Controls.Add(this.listCredentials);
            this.groupBox2.Controls.Add(this.chkIncludeCredentials);
            this.groupBox2.Controls.Add(this.chkIncludeJobEvents);
            this.groupBox2.Controls.Add(this.chkIncludeLogger);
            this.groupBox2.Controls.Add(this.chkSqlEnable);
            this.groupBox2.Controls.Add(this.chkContextEnable);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 322);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Context Options";
            // 
            // listSql
            // 
            this.listSql.AllowSort = false;
            this.listSql.Enabled = false;
            this.listSql.Location = new System.Drawing.Point(160, 120);
            this.listSql.Mode = ListMode.DropDown;
            this.listSql.Name = "listSql";
            this.listSql.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("listSql.Options")));
            this.listSql.Size = new System.Drawing.Size(185, 82);
            this.listSql.TabIndex = 14;
            // 
            // listCredentials
            // 
            this.listCredentials.AllowSort = false;
            this.listCredentials.Enabled = false;
            this.listCredentials.Location = new System.Drawing.Point(160, 215);
            this.listCredentials.Mode = ListMode.DropDown;
            this.listCredentials.Name = "listCredentials";
            this.listCredentials.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("listCredentials.Options")));
            this.listCredentials.Size = new System.Drawing.Size(185, 82);
            this.listCredentials.TabIndex = 12;
            // 
            // chkIncludeCredentials
            // 
            this.chkIncludeCredentials.AutoSize = true;
            this.chkIncludeCredentials.Location = new System.Drawing.Point(9, 214);
            this.chkIncludeCredentials.Name = "chkIncludeCredentials";
            this.chkIncludeCredentials.Size = new System.Drawing.Size(153, 17);
            this.chkIncludeCredentials.TabIndex = 11;
            this.chkIncludeCredentials.Text = "Include Shared Credentials";
            this.chkIncludeCredentials.UseVisualStyleBackColor = true;
            this.chkIncludeCredentials.CheckedChanged += new System.EventHandler(this.chkIncludeCredentials_CheckedChanged);
            // 
            // chkIncludeJobEvents
            // 
            this.chkIncludeJobEvents.AutoSize = true;
            this.chkIncludeJobEvents.Checked = true;
            this.chkIncludeJobEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeJobEvents.Location = new System.Drawing.Point(9, 96);
            this.chkIncludeJobEvents.Name = "chkIncludeJobEvents";
            this.chkIncludeJobEvents.Size = new System.Drawing.Size(146, 17);
            this.chkIncludeJobEvents.TabIndex = 10;
            this.chkIncludeJobEvents.Text = "Include Job Events Proxy";
            this.chkIncludeJobEvents.UseVisualStyleBackColor = true;
            // 
            // chkIncludeLogger
            // 
            this.chkIncludeLogger.AutoSize = true;
            this.chkIncludeLogger.Checked = true;
            this.chkIncludeLogger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeLogger.Location = new System.Drawing.Point(9, 72);
            this.chkIncludeLogger.Name = "chkIncludeLogger";
            this.chkIncludeLogger.Size = new System.Drawing.Size(97, 17);
            this.chkIncludeLogger.TabIndex = 9;
            this.chkIncludeLogger.Text = "Include Logger";
            this.chkIncludeLogger.UseVisualStyleBackColor = true;
            // 
            // chkSqlEnable
            // 
            this.chkSqlEnable.AutoSize = true;
            this.chkSqlEnable.Location = new System.Drawing.Point(9, 120);
            this.chkSqlEnable.Name = "chkSqlEnable";
            this.chkSqlEnable.Size = new System.Drawing.Size(134, 17);
            this.chkSqlEnable.TabIndex = 7;
            this.chkSqlEnable.Text = "Include SQL Database";
            this.chkSqlEnable.UseVisualStyleBackColor = true;
            this.chkSqlEnable.CheckedChanged += new System.EventHandler(this.chkSqlEnable_CheckedChanged);
            // 
            // chkContextEnable
            // 
            this.chkContextEnable.AutoSize = true;
            this.chkContextEnable.Checked = true;
            this.chkContextEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContextEnable.Location = new System.Drawing.Point(9, 49);
            this.chkContextEnable.Name = "chkContextEnable";
            this.chkContextEnable.Size = new System.Drawing.Size(131, 17);
            this.chkContextEnable.TabIndex = 4;
            this.chkContextEnable.Text = "Push Context to Script";
            this.chkContextEnable.UseVisualStyleBackColor = true;
            this.chkContextEnable.CheckedChanged += new System.EventHandler(this.chkContextEnable_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "The Context is a variable that allows your script to directly\r\n communicate with " +
    "Core.";
            // 
            // ContextOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "ContextOptions";
            this.Size = new System.Drawing.Size(358, 328);
            this.UseMinimumSize = false;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private EditableList listCredentials;
        private System.Windows.Forms.CheckBox chkIncludeCredentials;
        private System.Windows.Forms.CheckBox chkIncludeJobEvents;
        private System.Windows.Forms.CheckBox chkIncludeLogger;
        private System.Windows.Forms.CheckBox chkSqlEnable;
        private System.Windows.Forms.CheckBox chkContextEnable;
        private System.Windows.Forms.Label label3;
        private EditableList listSql;
    }
}
