using CoreScheduler.Client.Desktop.Controls;
using EasyScintilla;

namespace CoreScheduler.Client.Desktop.Forms
{
    partial class JobBuilder
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.jobOptionsPage = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.comboScript = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jobTypeTree = new System.Windows.Forms.TreeView();
            this.triggerPage = new System.Windows.Forms.TabPage();
            this.triggerEditor = new LargeTriggerEditor();
            this.editorPage = new System.Windows.Forms.TabPage();
            this.scriptEditor = new SimpleEditor();
            this.tabControl.SuspendLayout();
            this.jobOptionsPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.triggerPage.SuspendLayout();
            this.editorPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.jobOptionsPage);
            this.tabControl.Controls.Add(this.triggerPage);
            this.tabControl.Controls.Add(this.editorPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1028, 550);
            this.tabControl.TabIndex = 0;
            // 
            // jobOptionsPage
            // 
            this.jobOptionsPage.Controls.Add(this.btnCancel);
            this.jobOptionsPage.Controls.Add(this.btnSave);
            this.jobOptionsPage.Controls.Add(this.optionsPanel);
            this.jobOptionsPage.Controls.Add(this.groupBox2);
            this.jobOptionsPage.Controls.Add(this.groupBox1);
            this.jobOptionsPage.Location = new System.Drawing.Point(4, 22);
            this.jobOptionsPage.Name = "jobOptionsPage";
            this.jobOptionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.jobOptionsPage.Size = new System.Drawing.Size(1020, 524);
            this.jobOptionsPage.TabIndex = 0;
            this.jobOptionsPage.Text = "Job Options";
            this.jobOptionsPage.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(768, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(893, 493);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Job";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsPanel.Location = new System.Drawing.Point(221, 120);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(790, 366);
            this.optionsPanel.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtScriptName);
            this.groupBox2.Controls.Add(this.comboScript);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtJobType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtJobName);
            this.groupBox2.Location = new System.Drawing.Point(222, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 111);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Script Name";
            // 
            // txtScriptName
            // 
            this.txtScriptName.Enabled = false;
            this.txtScriptName.Location = new System.Drawing.Point(407, 36);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(377, 20);
            this.txtScriptName.TabIndex = 1;
            this.txtScriptName.Leave += new System.EventHandler(this.txtScriptName_Leave);
            // 
            // comboScript
            // 
            this.comboScript.FormattingEnabled = true;
            this.comboScript.Location = new System.Drawing.Point(407, 79);
            this.comboScript.Name = "comboScript";
            this.comboScript.Size = new System.Drawing.Size(377, 21);
            this.comboScript.TabIndex = 2;
            this.comboScript.SelectedIndexChanged += new System.EventHandler(this.comboScript_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Script";
            // 
            // txtJobType
            // 
            this.txtJobType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobType.Enabled = false;
            this.txtJobType.Location = new System.Drawing.Point(10, 80);
            this.txtJobType.Name = "txtJobType";
            this.txtJobType.Size = new System.Drawing.Size(378, 20);
            this.txtJobType.TabIndex = 2;
            this.txtJobType.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Job Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Job Name";
            // 
            // txtJobName
            // 
            this.txtJobName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobName.Location = new System.Drawing.Point(10, 36);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(378, 20);
            this.txtJobName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jobTypeTree);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 518);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job Type";
            // 
            // jobTypeTree
            // 
            this.jobTypeTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobTypeTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobTypeTree.Location = new System.Drawing.Point(3, 16);
            this.jobTypeTree.Name = "jobTypeTree";
            this.jobTypeTree.Size = new System.Drawing.Size(206, 499);
            this.jobTypeTree.TabIndex = 0;
            this.jobTypeTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jobTypeTree_AfterSelect);
            // 
            // triggerPage
            // 
            this.triggerPage.Controls.Add(this.triggerEditor);
            this.triggerPage.Location = new System.Drawing.Point(4, 22);
            this.triggerPage.Name = "triggerPage";
            this.triggerPage.Size = new System.Drawing.Size(1020, 524);
            this.triggerPage.TabIndex = 2;
            this.triggerPage.Text = "Trigger";
            this.triggerPage.UseVisualStyleBackColor = true;
            // 
            // triggerEditor
            // 
            this.triggerEditor.ForecastFor = System.TimeSpan.Parse("120.00:00:00");
            this.triggerEditor.Location = new System.Drawing.Point(104, 54);
            this.triggerEditor.MaximumSize = new System.Drawing.Size(813, 416);
            this.triggerEditor.MinimumSize = new System.Drawing.Size(813, 416);
            this.triggerEditor.Name = "triggerEditor";
            this.triggerEditor.Size = new System.Drawing.Size(813, 416);
            this.triggerEditor.TabIndex = 0;
            // 
            // editorPage
            // 
            this.editorPage.Controls.Add(this.scriptEditor);
            this.editorPage.Location = new System.Drawing.Point(4, 22);
            this.editorPage.Name = "editorPage";
            this.editorPage.Padding = new System.Windows.Forms.Padding(3);
            this.editorPage.Size = new System.Drawing.Size(1020, 524);
            this.editorPage.TabIndex = 1;
            this.editorPage.Text = "Script Editor";
            this.editorPage.UseVisualStyleBackColor = true;
            // 
            // scriptEditor
            // 
            this.scriptEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditor.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.scriptEditor.Location = new System.Drawing.Point(3, 3);
            this.scriptEditor.Name = "scriptEditor";
            this.scriptEditor.Size = new System.Drawing.Size(1014, 518);
            this.scriptEditor.Styler = null;
            this.scriptEditor.TabIndex = 0;
            // 
            // JobBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 550);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JobBuilder";
            this.Text = "JobBuilder";
            this.tabControl.ResumeLayout(false);
            this.jobOptionsPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.triggerPage.ResumeLayout(false);
            this.editorPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage jobOptionsPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView jobTypeTree;
        private System.Windows.Forms.TabPage triggerPage;
        private System.Windows.Forms.TabPage editorPage;
        private SimpleEditor scriptEditor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtJobType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.ComboBox comboScript;
        private System.Windows.Forms.Label label3;
        private LargeTriggerEditor triggerEditor;

    }
}