namespace CoreScheduler.Client.Desktop.Base
{
    partial class SimpleManager<T, TContext>
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
            this.treeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.auxButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.DerivedPanel = new System.Windows.Forms.Panel();
            this.copyIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.auxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeContext
            // 
            this.treeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.copyIDToolStripMenuItem});
            this.treeContext.Name = "treeContext";
            this.treeContext.Size = new System.Drawing.Size(153, 70);
            this.treeContext.Opening += new System.ComponentModel.CancelEventHandler(this.treeContext_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(543, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.DerivedPanel);
            this.splitContainer1.Size = new System.Drawing.Size(792, 315);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 12;
            // 
            // tree
            // 
            this.tree.ContextMenuStrip = this.treeContext;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(167, 315);
            this.tree.TabIndex = 11;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.auxButtons);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 28);
            this.panel2.TabIndex = 13;
            // 
            // auxButtons
            // 
            this.auxButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auxButtons.Controls.Add(this.btnNew);
            this.auxButtons.Location = new System.Drawing.Point(0, 0);
            this.auxButtons.Name = "auxButtons";
            this.auxButtons.Size = new System.Drawing.Size(454, 26);
            this.auxButtons.TabIndex = 12;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.AutoSize = true;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(462, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DerivedPanel
            // 
            this.DerivedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DerivedPanel.Location = new System.Drawing.Point(0, 0);
            this.DerivedPanel.Name = "DerivedPanel";
            this.DerivedPanel.Size = new System.Drawing.Size(621, 315);
            this.DerivedPanel.TabIndex = 11;
            // 
            // copyIDToolStripMenuItem
            // 
            this.copyIDToolStripMenuItem.Name = "copyIDToolStripMenuItem";
            this.copyIDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyIDToolStripMenuItem.Text = "Copy ID";
            this.copyIDToolStripMenuItem.Click += new System.EventHandler(this.copyIDToolStripMenuItem_Click);
            // 
            // SimpleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 315);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimpleManager";
            this.Text = "Manager";
            this.treeContext.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.auxButtons.ResumeLayout(false);
            this.auxButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ContextMenuStrip treeContext;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        protected System.Windows.Forms.Panel DerivedPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel auxButtons;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem copyIDToolStripMenuItem;
    }
}