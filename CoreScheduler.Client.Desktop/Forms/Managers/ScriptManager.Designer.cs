using System.Windows.Forms;
using EasyScintilla;

namespace CoreScheduler.Client.Desktop.Forms
{
    partial class ScriptManager
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
            this.fileActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scriptBrowser = new System.Windows.Forms.TreeView();
            this.editor = new SimpleEditor();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileActions
            // 
            this.fileActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.copyIDToolStripMenuItem,
            this.toolStripSeparator1,
            this.moveToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.fileActions.Name = "fileActions";
            this.fileActions.Size = new System.Drawing.Size(125, 120);
            this.fileActions.Opening += new System.ComponentModel.CancelEventHandler(this.fileActions_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // copyIDToolStripMenuItem
            // 
            this.copyIDToolStripMenuItem.Name = "copyIDToolStripMenuItem";
            this.copyIDToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.copyIDToolStripMenuItem.Text = "Copy ID";
            this.copyIDToolStripMenuItem.Click += new System.EventHandler(this.copyIDToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scriptBrowser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.editor);
            this.splitContainer1.Size = new System.Drawing.Size(998, 454);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 1;
            // 
            // scriptBrowser
            // 
            this.scriptBrowser.AllowDrop = true;
            this.scriptBrowser.ContextMenuStrip = this.fileActions;
            this.scriptBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptBrowser.LabelEdit = true;
            this.scriptBrowser.Location = new System.Drawing.Point(0, 0);
            this.scriptBrowser.Name = "scriptBrowser";
            this.scriptBrowser.PathSeparator = "/";
            this.scriptBrowser.Size = new System.Drawing.Size(272, 454);
            this.scriptBrowser.TabIndex = 0;
            this.scriptBrowser.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.scriptBrowser_AfterLabelEdit);
            this.scriptBrowser.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.scriptBrowser_ItemDrag);
            this.scriptBrowser.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.scriptBrowser_BeforeSelect);
            this.scriptBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.scriptBrowser_AfterSelect);
            this.scriptBrowser.DragDrop += new System.Windows.Forms.DragEventHandler(this.scriptBrowser_DragDrop);
            this.scriptBrowser.DragOver += new System.Windows.Forms.DragEventHandler(this.scriptBrowser_DragOver);
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(722, 454);
            this.editor.Styler = null;
            this.editor.TabIndex = 1;
            this.editor.TextChanged += new System.EventHandler(this.editor_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(998, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // ScriptManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 478);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ScriptManager";
            this.Text = "Script Editor";
            this.fileActions.ResumeLayout(false);
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
        private SimpleEditor editor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip fileActions;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private TreeView scriptBrowser;
        private ToolStripMenuItem duplicateToolStripMenuItem;
        private ToolStripMenuItem copyIDToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}