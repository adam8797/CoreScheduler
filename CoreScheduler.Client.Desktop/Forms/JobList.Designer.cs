namespace CoreScheduler.Client.Desktop.Forms
{
    partial class JobList
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
            this.components = new System.ComponentModel.Container();
            this.tree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ContextMenuStrip = this.contextMenuStrip;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(491, 426);
            this.tree.TabIndex = 0;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.fireToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.pauseToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(171, 192);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.viewDetailsToolStripMenuItem.Text = "Edit Job";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewDetailsToolStripMenuItem_Click);
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // fireToolStripMenuItem
            // 
            this.fireToolStripMenuItem.Name = "fireToolStripMenuItem";
            this.fireToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.fireToolStripMenuItem.Text = "Fire";
            this.fireToolStripMenuItem.Click += new System.EventHandler(this.fireToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.pauseToolStripMenuItem.Text = "Pause Execution";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.resumeToolStripMenuItem.Text = "Resume Execution";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteToolStripMenuItem.Text = "Delete Job";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // JobList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 426);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "JobList";
            this.Text = "Job List";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fireToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}