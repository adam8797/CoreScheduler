using CoreScheduler.Client.Desktop.Controls;

namespace CoreScheduler.Client.Desktop.Forms
{
    partial class TriggerManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.editor = new LargeTriggerEditor();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditJob = new System.Windows.Forms.Button();
            this.lblJob = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.editor);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 470);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 0;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(197, 470);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            // 
            // editor
            // 
            this.editor.ForecastFor = System.TimeSpan.Parse("120.00:00:00");
            this.editor.Location = new System.Drawing.Point(3, 0);
            this.editor.MaximumSize = new System.Drawing.Size(813, 416);
            this.editor.MinimumSize = new System.Drawing.Size(813, 416);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(813, 416);
            this.editor.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResume);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(6, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(11, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "label1";
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Location = new System.Drawing.Point(233, 15);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResume.Location = new System.Drawing.Point(152, 15);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 2;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditJob);
            this.groupBox2.Controls.Add(this.lblJob);
            this.groupBox2.Location = new System.Drawing.Point(326, 416);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 46);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job";
            // 
            // btnEditJob
            // 
            this.btnEditJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditJob.Location = new System.Drawing.Point(238, 15);
            this.btnEditJob.Name = "btnEditJob";
            this.btnEditJob.Size = new System.Drawing.Size(75, 23);
            this.btnEditJob.TabIndex = 1;
            this.btnEditJob.Text = "Edit Job";
            this.btnEditJob.UseVisualStyleBackColor = true;
            this.btnEditJob.Click += new System.EventHandler(this.btnEditJob_Click);
            // 
            // lblJob
            // 
            this.lblJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJob.Location = new System.Drawing.Point(11, 20);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(221, 18);
            this.lblJob.TabIndex = 0;
            this.lblJob.Text = "label2";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(732, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(651, 431);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TriggerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 470);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(99999, 504);
            this.Name = "TriggerManager";
            this.Text = "TriggerManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditJob;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblStatus;
        private Controls.LargeTriggerEditor editor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}