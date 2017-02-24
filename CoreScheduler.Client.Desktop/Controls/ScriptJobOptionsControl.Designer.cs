using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Controls
{
    partial class ScriptJobOptionsControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scriptBrowser = new System.Windows.Forms.TreeView();
            this.contextOptions = new ContextOptions();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeDllReferences = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scriptBrowser);
            this.groupBox1.Location = new System.Drawing.Point(360, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 322);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script References";
            // 
            // scriptBrowser
            // 
            this.scriptBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scriptBrowser.CheckBoxes = true;
            this.scriptBrowser.Location = new System.Drawing.Point(6, 19);
            this.scriptBrowser.Name = "scriptBrowser";
            this.scriptBrowser.Size = new System.Drawing.Size(198, 297);
            this.scriptBrowser.TabIndex = 0;
            this.scriptBrowser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeScriptReferences_AfterCheck);
            // 
            // contextOptions
            // 
            this.contextOptions.Location = new System.Drawing.Point(0, 0);
            this.contextOptions.Name = "contextOptions";
            this.contextOptions.Size = new System.Drawing.Size(360, 328);
            this.contextOptions.TabIndex = 2;
            this.contextOptions.UseMinimumSize = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeDllReferences);
            this.groupBox2.Location = new System.Drawing.Point(576, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 322);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DLL References";
            // 
            // treeDllReferences
            // 
            this.treeDllReferences.BackColor = System.Drawing.SystemColors.Window;
            this.treeDllReferences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeDllReferences.CheckBoxes = true;
            this.treeDllReferences.Location = new System.Drawing.Point(6, 19);
            this.treeDllReferences.Name = "treeDllReferences";
            this.treeDllReferences.Size = new System.Drawing.Size(196, 297);
            this.treeDllReferences.TabIndex = 0;
            this.treeDllReferences.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeScriptReferences_AfterCheck);
            // 
            // ScriptJobOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.contextOptions);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScriptJobOptionsControl";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ContextOptions contextOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeDllReferences;
        private TreeView scriptBrowser;
    }
}
