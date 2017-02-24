namespace CoreScheduler.Client.Desktop.Forms
{
    partial class JobEditor
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.detailPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.properties = new System.Windows.Forms.PropertyGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCategory = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJobDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jobIcon = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eventTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.optionsPage = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenScript = new System.Windows.Forms.Button();
            this.btnNewTrigger = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.detailPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.detailPage);
            this.tabs.Controls.Add(this.optionsPage);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(961, 510);
            this.tabs.TabIndex = 0;
            // 
            // detailPage
            // 
            this.detailPage.Controls.Add(this.groupBox3);
            this.detailPage.Controls.Add(this.groupBox2);
            this.detailPage.Controls.Add(this.groupBox1);
            this.detailPage.Controls.Add(this.button1);
            this.detailPage.Location = new System.Drawing.Point(4, 22);
            this.detailPage.Name = "detailPage";
            this.detailPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailPage.Size = new System.Drawing.Size(953, 484);
            this.detailPage.TabIndex = 0;
            this.detailPage.Text = "Job Detail";
            this.detailPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.properties);
            this.groupBox3.Location = new System.Drawing.Point(6, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 333);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Job Details";
            // 
            // properties
            // 
            this.properties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.properties.HelpVisible = false;
            this.properties.Location = new System.Drawing.Point(6, 19);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(601, 308);
            this.properties.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCategory);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtJobDescription);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtJobType);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.jobIcon);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 130);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job Type";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(140, 107);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(467, 13);
            this.txtCategory.TabIndex = 7;
            this.txtCategory.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Category";
            // 
            // txtJobDescription
            // 
            this.txtJobDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobDescription.Location = new System.Drawing.Point(140, 70);
            this.txtJobDescription.Name = "txtJobDescription";
            this.txtJobDescription.Size = new System.Drawing.Size(467, 13);
            this.txtJobDescription.TabIndex = 5;
            this.txtJobDescription.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description";
            // 
            // txtJobType
            // 
            this.txtJobType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobType.Location = new System.Drawing.Point(140, 34);
            this.txtJobType.Name = "txtJobType";
            this.txtJobType.Size = new System.Drawing.Size(467, 13);
            this.txtJobType.TabIndex = 3;
            this.txtJobType.Text = "Job Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Job Type";
            // 
            // jobIcon
            // 
            this.jobIcon.Location = new System.Drawing.Point(6, 19);
            this.jobIcon.Name = "jobIcon";
            this.jobIcon.Size = new System.Drawing.Size(105, 105);
            this.jobIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jobIcon.TabIndex = 1;
            this.jobIcon.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eventTree);
            this.groupBox1.Location = new System.Drawing.Point(625, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 472);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recent Runs";
            // 
            // eventTree
            // 
            this.eventTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventTree.Location = new System.Drawing.Point(3, 16);
            this.eventTree.Name = "eventTree";
            this.eventTree.Size = new System.Drawing.Size(316, 453);
            this.eventTree.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // optionsPage
            // 
            this.optionsPage.Location = new System.Drawing.Point(4, 22);
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.Size = new System.Drawing.Size(953, 484);
            this.optionsPage.TabIndex = 2;
            this.optionsPage.Text = "Script Options";
            this.optionsPage.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(898, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(817, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenScript
            // 
            this.btnOpenScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenScript.Location = new System.Drawing.Point(12, 528);
            this.btnOpenScript.Name = "btnOpenScript";
            this.btnOpenScript.Size = new System.Drawing.Size(75, 23);
            this.btnOpenScript.TabIndex = 3;
            this.btnOpenScript.Text = "Open Script";
            this.btnOpenScript.UseVisualStyleBackColor = true;
            this.btnOpenScript.Click += new System.EventHandler(this.btnOpenScript_Click);
            // 
            // btnNewTrigger
            // 
            this.btnNewTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewTrigger.Location = new System.Drawing.Point(93, 528);
            this.btnNewTrigger.Name = "btnNewTrigger";
            this.btnNewTrigger.Size = new System.Drawing.Size(75, 23);
            this.btnNewTrigger.TabIndex = 4;
            this.btnNewTrigger.Text = "New Trigger";
            this.btnNewTrigger.UseVisualStyleBackColor = true;
            this.btnNewTrigger.Click += new System.EventHandler(this.btnNewTrigger_Click);
            // 
            // JobEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 562);
            this.Controls.Add(this.btnNewTrigger);
            this.Controls.Add(this.btnOpenScript);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JobEditor";
            this.Text = "Job Editor";
            this.tabs.ResumeLayout(false);
            this.detailPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobIcon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage detailPage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage optionsPage;
        private System.Windows.Forms.Button btnOpenScript;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button btnNewTrigger;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox jobIcon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtJobDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtJobType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView eventTree;
        private System.Windows.Forms.Label txtCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PropertyGrid properties;
    }
}