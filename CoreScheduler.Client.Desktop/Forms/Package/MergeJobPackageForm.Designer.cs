using CoreScheduler.Client.Desktop.Controls;

namespace CoreScheduler.Client.Desktop.Forms.Package
{
    partial class MergeJobPackageForm
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
            this.fileList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnAddPackage = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.renderOptions = new JobRenderOptionsControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(6, 49);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(192, 238);
            this.fileList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearList);
            this.groupBox1.Controls.Add(this.btnAddPackage);
            this.groupBox1.Controls.Add(this.fileList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 320);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Packages";
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(6, 291);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(192, 23);
            this.btnClearList.TabIndex = 2;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Location = new System.Drawing.Point(6, 22);
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Size = new System.Drawing.Size(192, 23);
            this.btnAddPackage.TabIndex = 1;
            this.btnAddPackage.Text = "Add Package";
            this.btnAddPackage.UseVisualStyleBackColor = true;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "XML Files|*.xml";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(296, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save And Merge";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML Files|*.xml";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CoreScheduler.Client.Desktop.Images.MergeArrow;
            this.pictureBox1.Location = new System.Drawing.Point(222, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.renderOptions);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(410, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 196);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination Package";
            // 
            // renderOptions
            // 
            this.renderOptions.Location = new System.Drawing.Point(6, 49);
            this.renderOptions.Name = "renderOptions";
            this.renderOptions.Size = new System.Drawing.Size(297, 144);
            this.renderOptions.TabIndex = 0;
            // 
            // MergeJobPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 344);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MergeJobPackageForm";
            this.Text = "Merge Job Packages";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnAddPackage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.JobRenderOptionsControl renderOptions;

    }
}