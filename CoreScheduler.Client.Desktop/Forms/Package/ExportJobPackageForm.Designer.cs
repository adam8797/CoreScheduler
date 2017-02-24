using CoreScheduler.Client.Desktop.Controls;

namespace CoreScheduler.Client.Desktop.Forms.Package
{
    partial class ExportJobPackageForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.renderOptions = new JobRenderOptionsControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPrimaryScript = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.dependencyTree = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jobTree = new System.Windows.Forms.TreeView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.renderOptions);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblPrimaryScript);
            this.groupBox1.Controls.Add(this.lblJobName);
            this.groupBox1.Controls.Add(this.dependencyTree);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.jobTree);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // renderOptions
            // 
            this.renderOptions.Location = new System.Drawing.Point(209, 269);
            this.renderOptions.Name = "renderOptions";
            this.renderOptions.Size = new System.Drawing.Size(297, 144);
            this.renderOptions.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(394, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Job Package";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPrimaryScript
            // 
            this.lblPrimaryScript.AutoSize = true;
            this.lblPrimaryScript.Location = new System.Drawing.Point(224, 66);
            this.lblPrimaryScript.Name = "lblPrimaryScript";
            this.lblPrimaryScript.Size = new System.Drawing.Size(0, 13);
            this.lblPrimaryScript.TabIndex = 7;
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(224, 32);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(0, 13);
            this.lblJobName.TabIndex = 6;
            // 
            // dependencyTree
            // 
            this.dependencyTree.Location = new System.Drawing.Point(224, 98);
            this.dependencyTree.Name = "dependencyTree";
            this.dependencyTree.Size = new System.Drawing.Size(282, 165);
            this.dependencyTree.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dependencies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Primary Script Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected Job";
            // 
            // jobTree
            // 
            this.jobTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.jobTree.Location = new System.Drawing.Point(6, 19);
            this.jobTree.Name = "jobTree";
            this.jobTree.Size = new System.Drawing.Size(192, 416);
            this.jobTree.TabIndex = 0;
            this.jobTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jobTree_AfterSelect);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.FileName = "Package.xml";
            this.saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            // 
            // ExportJobPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 468);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportJobPackageForm";
            this.Text = "Export Job Package";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView dependencyTree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView jobTree;
        private System.Windows.Forms.Label lblPrimaryScript;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Controls.JobRenderOptionsControl renderOptions;
    }
}