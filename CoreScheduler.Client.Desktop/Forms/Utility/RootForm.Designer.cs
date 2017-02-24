namespace CoreScheduler.Client.Desktop.Forms
{
    partial class RootForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.credentialManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionStringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobExecutionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobPackagingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.developmentToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLabel,
            this.spacer,
            this.loadingBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 359);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(614, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(15, 17);
            this.statusLabel.Text = "[]";
            // 
            // spacer
            // 
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(440, 17);
            this.spacer.Spring = true;
            // 
            // loadingBar
            // 
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(100, 16);
            this.loadingBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.ToolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(614, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newJobToolStripMenuItem,
            this.openPackageToolStripMenuItem,
            this.savePackageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newJobToolStripMenuItem
            // 
            this.newJobToolStripMenuItem.Name = "newJobToolStripMenuItem";
            this.newJobToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newJobToolStripMenuItem.Text = "New Job";
            // 
            // openPackageToolStripMenuItem
            // 
            this.openPackageToolStripMenuItem.Name = "openPackageToolStripMenuItem";
            this.openPackageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openPackageToolStripMenuItem.Text = "Open Package";
            // 
            // savePackageToolStripMenuItem
            // 
            this.savePackageToolStripMenuItem.Name = "savePackageToolStripMenuItem";
            this.savePackageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.savePackageToolStripMenuItem.Text = "Save Package";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobListToolStripMenuItem,
            this.triggersToolStripMenuItem,
            this.scriptsToolStripMenuItem,
            this.toolStripSeparator1,
            this.credentialManagerToolStripMenuItem,
            this.connectionStringsToolStripMenuItem,
            this.assemblyManagerToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // jobListToolStripMenuItem
            // 
            this.jobListToolStripMenuItem.Name = "jobListToolStripMenuItem";
            this.jobListToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.jobListToolStripMenuItem.Text = "Jobs";
            // 
            // triggersToolStripMenuItem
            // 
            this.triggersToolStripMenuItem.Name = "triggersToolStripMenuItem";
            this.triggersToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.triggersToolStripMenuItem.Text = "Triggers";
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // credentialManagerToolStripMenuItem
            // 
            this.credentialManagerToolStripMenuItem.Name = "credentialManagerToolStripMenuItem";
            this.credentialManagerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.credentialManagerToolStripMenuItem.Text = "Credential Manager";
            // 
            // connectionStringsToolStripMenuItem
            // 
            this.connectionStringsToolStripMenuItem.Name = "connectionStringsToolStripMenuItem";
            this.connectionStringsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.connectionStringsToolStripMenuItem.Text = "Connection Strings";
            // 
            // assemblyManagerToolStripMenuItem
            // 
            this.assemblyManagerToolStripMenuItem.Name = "assemblyManagerToolStripMenuItem";
            this.assemblyManagerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.assemblyManagerToolStripMenuItem.Text = "Assembly Manager";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobExecutionHistoryToolStripMenuItem});
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // jobExecutionHistoryToolStripMenuItem
            // 
            this.jobExecutionHistoryToolStripMenuItem.Name = "jobExecutionHistoryToolStripMenuItem";
            this.jobExecutionHistoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.jobExecutionHistoryToolStripMenuItem.Text = "Job Execution History";
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobPackagingToolStripMenuItem,
            this.toolStripSeparator2,
            this.developmentToolsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // jobPackagingToolStripMenuItem
            // 
            this.jobPackagingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergePackageToolStripMenuItem,
            this.encryptPackageToolStripMenuItem});
            this.jobPackagingToolStripMenuItem.Name = "jobPackagingToolStripMenuItem";
            this.jobPackagingToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.jobPackagingToolStripMenuItem.Text = "Job Packaging";
            // 
            // mergePackageToolStripMenuItem
            // 
            this.mergePackageToolStripMenuItem.Name = "mergePackageToolStripMenuItem";
            this.mergePackageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.mergePackageToolStripMenuItem.Text = "Merge Package";
            // 
            // encryptPackageToolStripMenuItem
            // 
            this.encryptPackageToolStripMenuItem.Name = "encryptPackageToolStripMenuItem";
            this.encryptPackageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.encryptPackageToolStripMenuItem.Text = "Encrypt Package";
            this.encryptPackageToolStripMenuItem.Click += new System.EventHandler(this.encryptPackageToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // developmentToolsToolStripMenuItem
            // 
            this.developmentToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testFormToolStripMenuItem});
            this.developmentToolsToolStripMenuItem.Name = "developmentToolsToolStripMenuItem";
            this.developmentToolsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.developmentToolsToolStripMenuItem.Text = "Development Tools";
            // 
            // testFormToolStripMenuItem
            // 
            this.testFormToolStripMenuItem.Name = "testFormToolStripMenuItem";
            this.testFormToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.testFormToolStripMenuItem.Text = "Test Form";
            // 
            // RootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 381);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "RootForm";
            this.Text = "CORE Scheduler Desktop - Common Runtime Event Scheduler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggersToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel spacer;
        private System.Windows.Forms.ToolStripProgressBar loadingBar;
        private System.Windows.Forms.ToolStripMenuItem newJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobExecutionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credentialManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem connectionStringsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblyManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobPackagingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergePackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem developmentToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePackageToolStripMenuItem;
    }
}

