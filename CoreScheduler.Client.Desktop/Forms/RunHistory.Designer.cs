namespace CoreScheduler.Client.Desktop.Forms
{
    partial class RunHistory
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Jobs");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jobTree = new System.Windows.Forms.TreeView();
            this.runTree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimumEventLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fatalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twelveHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixMonthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jobTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.runTree);
            this.splitContainer1.Size = new System.Drawing.Size(896, 517);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // jobTree
            // 
            this.jobTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTree.Location = new System.Drawing.Point(0, 0);
            this.jobTree.Name = "jobTree";
            treeNode1.Name = "Jobs";
            treeNode1.Text = "Jobs";
            this.jobTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.jobTree.Size = new System.Drawing.Size(210, 517);
            this.jobTree.TabIndex = 0;
            this.jobTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jobTree_AfterSelect);
            // 
            // runTree
            // 
            this.runTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runTree.Location = new System.Drawing.Point(0, 0);
            this.runTree.Name = "runTree";
            this.runTree.Size = new System.Drawing.Size(682, 517);
            this.runTree.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimumEventLevelToolStripMenuItem,
            this.timeIntervalToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // minimumEventLevelToolStripMenuItem
            // 
            this.minimumEventLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.warningToolStripMenuItem,
            this.errorToolStripMenuItem,
            this.fatalToolStripMenuItem});
            this.minimumEventLevelToolStripMenuItem.Name = "minimumEventLevelToolStripMenuItem";
            this.minimumEventLevelToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.minimumEventLevelToolStripMenuItem.Text = "Minimum Event Level";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Checked = true;
            this.infoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // warningToolStripMenuItem
            // 
            this.warningToolStripMenuItem.Name = "warningToolStripMenuItem";
            this.warningToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.warningToolStripMenuItem.Text = "Warning";
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.errorToolStripMenuItem.Text = "Error";
            // 
            // fatalToolStripMenuItem
            // 
            this.fatalToolStripMenuItem.Name = "fatalToolStripMenuItem";
            this.fatalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fatalToolStripMenuItem.Text = "Fatal";
            // 
            // timeIntervalToolStripMenuItem
            // 
            this.timeIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneHourToolStripMenuItem,
            this.twelveHourToolStripMenuItem,
            this.oneDayToolStripMenuItem,
            this.twoDaysToolStripMenuItem,
            this.threeDaysToolStripMenuItem,
            this.oneWeekToolStripMenuItem,
            this.oneMonthToolStripMenuItem,
            this.sixMonthsToolStripMenuItem,
            this.oneYearToolStripMenuItem,
            this.allTimeToolStripMenuItem});
            this.timeIntervalToolStripMenuItem.Name = "timeIntervalToolStripMenuItem";
            this.timeIntervalToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.timeIntervalToolStripMenuItem.Text = "Time Interval";
            // 
            // oneHourToolStripMenuItem
            // 
            this.oneHourToolStripMenuItem.Name = "oneHourToolStripMenuItem";
            this.oneHourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneHourToolStripMenuItem.Text = "1 Hour";
            // 
            // twelveHourToolStripMenuItem
            // 
            this.twelveHourToolStripMenuItem.Name = "twelveHourToolStripMenuItem";
            this.twelveHourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.twelveHourToolStripMenuItem.Text = "12 Hour";
            // 
            // oneDayToolStripMenuItem
            // 
            this.oneDayToolStripMenuItem.Checked = true;
            this.oneDayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.oneDayToolStripMenuItem.Name = "oneDayToolStripMenuItem";
            this.oneDayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneDayToolStripMenuItem.Text = "1 Day";
            // 
            // twoDaysToolStripMenuItem
            // 
            this.twoDaysToolStripMenuItem.Name = "twoDaysToolStripMenuItem";
            this.twoDaysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.twoDaysToolStripMenuItem.Text = "2 Days";
            // 
            // threeDaysToolStripMenuItem
            // 
            this.threeDaysToolStripMenuItem.Name = "threeDaysToolStripMenuItem";
            this.threeDaysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.threeDaysToolStripMenuItem.Text = "3 Days";
            // 
            // oneWeekToolStripMenuItem
            // 
            this.oneWeekToolStripMenuItem.Name = "oneWeekToolStripMenuItem";
            this.oneWeekToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneWeekToolStripMenuItem.Text = "1 Week";
            // 
            // oneMonthToolStripMenuItem
            // 
            this.oneMonthToolStripMenuItem.Name = "oneMonthToolStripMenuItem";
            this.oneMonthToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneMonthToolStripMenuItem.Text = "1 Month";
            // 
            // sixMonthsToolStripMenuItem
            // 
            this.sixMonthsToolStripMenuItem.Name = "sixMonthsToolStripMenuItem";
            this.sixMonthsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sixMonthsToolStripMenuItem.Text = "6 Months";
            // 
            // oneYearToolStripMenuItem
            // 
            this.oneYearToolStripMenuItem.Name = "oneYearToolStripMenuItem";
            this.oneYearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneYearToolStripMenuItem.Text = "1 Year";
            // 
            // allTimeToolStripMenuItem
            // 
            this.allTimeToolStripMenuItem.Name = "allTimeToolStripMenuItem";
            this.allTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allTimeToolStripMenuItem.Text = "All Time";
            // 
            // RunHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 541);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RunHistory";
            this.Text = "RunHistory";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView jobTree;
        private System.Windows.Forms.TreeView runTree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimumEventLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fatalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twelveHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sixMonthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTimeToolStripMenuItem;
    }
}