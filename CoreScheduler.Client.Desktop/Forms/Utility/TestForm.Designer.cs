using CoreScheduler.Client.Desktop.Controls;

namespace CoreScheduler.Client.Desktop.Forms
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseLarge = new System.Windows.Forms.CheckBox();
            this.btnUpdateIcons = new System.Windows.Forms.Button();
            this.txtDll = new System.Windows.Forms.TextBox();
            this.iconList = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.stockList = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.btnCon = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.e6 = new EditableList();
            this.e5 = new EditableList();
            this.e4 = new EditableList();
            this.e3 = new EditableList();
            this.e2 = new EditableList();
            this.e1 = new EditableList();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAssemblies = new System.Windows.Forms.CheckBox();
            this.chkTriggers = new System.Windows.Forms.CheckBox();
            this.chkScripts = new System.Windows.Forms.CheckBox();
            this.chkJobs = new System.Windows.Forms.CheckBox();
            this.chkEvents = new System.Windows.Forms.CheckBox();
            this.chkCred = new System.Windows.Forms.CheckBox();
            this.chkConn = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.jobsTree = new System.Windows.Forms.TreeView();
            this.btnFireAll = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkUseLarge);
            this.groupBox1.Controls.Add(this.btnUpdateIcons);
            this.groupBox1.Controls.Add(this.txtDll);
            this.groupBox1.Controls.Add(this.iconList);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 435);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Icons In DLL";
            // 
            // chkUseLarge
            // 
            this.chkUseLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseLarge.AutoSize = true;
            this.chkUseLarge.Location = new System.Drawing.Point(680, 26);
            this.chkUseLarge.Name = "chkUseLarge";
            this.chkUseLarge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUseLarge.Size = new System.Drawing.Size(75, 17);
            this.chkUseLarge.TabIndex = 5;
            this.chkUseLarge.Text = "Use Large";
            this.chkUseLarge.UseVisualStyleBackColor = true;
            // 
            // btnUpdateIcons
            // 
            this.btnUpdateIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateIcons.Location = new System.Drawing.Point(599, 22);
            this.btnUpdateIcons.Name = "btnUpdateIcons";
            this.btnUpdateIcons.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateIcons.TabIndex = 4;
            this.btnUpdateIcons.Text = "Update";
            this.btnUpdateIcons.UseVisualStyleBackColor = true;
            this.btnUpdateIcons.Click += new System.EventHandler(this.btnUpdateIcons_Click);
            // 
            // txtDll
            // 
            this.txtDll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDll.Location = new System.Drawing.Point(6, 24);
            this.txtDll.Name = "txtDll";
            this.txtDll.Size = new System.Drawing.Size(587, 20);
            this.txtDll.TabIndex = 3;
            this.txtDll.Text = "imageres.dll";
            // 
            // iconList
            // 
            this.iconList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconList.Location = new System.Drawing.Point(6, 50);
            this.iconList.Name = "iconList";
            this.iconList.Size = new System.Drawing.Size(749, 379);
            this.iconList.TabIndex = 2;
            this.iconList.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 474);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(777, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Icons";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.stockList);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(777, 448);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Stock Icons";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // stockList
            // 
            this.stockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stockList.Location = new System.Drawing.Point(8, 6);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(761, 434);
            this.stockList.TabIndex = 3;
            this.stockList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCon);
            this.tabPage2.Controls.Add(this.btnCon);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(777, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(105, 242);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(566, 20);
            this.txtCon.TabIndex = 1;
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(351, 213);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(75, 23);
            this.btnCon.TabIndex = 0;
            this.btnCon.Text = "Open Editor";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.e6);
            this.tabPage3.Controls.Add(this.e5);
            this.tabPage3.Controls.Add(this.e4);
            this.tabPage3.Controls.Add(this.e3);
            this.tabPage3.Controls.Add(this.e2);
            this.tabPage3.Controls.Add(this.e1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(777, 448);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Editable Lists";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // e6
            // 
            this.e6.AllowSort = true;
            this.e6.Location = new System.Drawing.Point(528, 225);
            this.e6.Mode = ListMode.ComboBox;
            this.e6.Name = "e6";
            this.e6.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e6.Options")));
            this.e6.Size = new System.Drawing.Size(241, 197);
            this.e6.TabIndex = 5;
            // 
            // e5
            // 
            this.e5.AllowSort = true;
            this.e5.Location = new System.Drawing.Point(267, 225);
            this.e5.Mode = ListMode.DropDown;
            this.e5.Name = "e5";
            this.e5.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e5.Options")));
            this.e5.Size = new System.Drawing.Size(241, 197);
            this.e5.TabIndex = 4;
            // 
            // e4
            // 
            this.e4.AllowSort = true;
            this.e4.Location = new System.Drawing.Point(8, 225);
            this.e4.Mode = ListMode.TextBox;
            this.e4.Name = "e4";
            this.e4.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e4.Options")));
            this.e4.Size = new System.Drawing.Size(241, 197);
            this.e4.TabIndex = 3;
            // 
            // e3
            // 
            this.e3.AllowSort = false;
            this.e3.Location = new System.Drawing.Point(528, 22);
            this.e3.Mode = ListMode.ComboBox;
            this.e3.Name = "e3";
            this.e3.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e3.Options")));
            this.e3.Size = new System.Drawing.Size(241, 197);
            this.e3.TabIndex = 2;
            // 
            // e2
            // 
            this.e2.AllowSort = false;
            this.e2.Location = new System.Drawing.Point(267, 22);
            this.e2.Mode = ListMode.DropDown;
            this.e2.Name = "e2";
            this.e2.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e2.Options")));
            this.e2.Size = new System.Drawing.Size(241, 197);
            this.e2.TabIndex = 1;
            // 
            // e1
            // 
            this.e1.AllowSort = false;
            this.e1.Location = new System.Drawing.Point(8, 22);
            this.e1.Mode = ListMode.TextBox;
            this.e1.Name = "e1";
            this.e1.Options = ((System.Collections.Generic.List<object>)(resources.GetObject("e1.Options")));
            this.e1.Size = new System.Drawing.Size(241, 197);
            this.e1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(777, 448);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Clear DB";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGo);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(313, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 231);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reset";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(75, 202);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkAssemblies);
            this.groupBox2.Controls.Add(this.chkTriggers);
            this.groupBox2.Controls.Add(this.chkScripts);
            this.groupBox2.Controls.Add(this.chkJobs);
            this.groupBox2.Controls.Add(this.chkEvents);
            this.groupBox2.Controls.Add(this.chkCred);
            this.groupBox2.Controls.Add(this.chkConn);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 179);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete";
            // 
            // chkAssemblies
            // 
            this.chkAssemblies.AutoSize = true;
            this.chkAssemblies.Location = new System.Drawing.Point(6, 157);
            this.chkAssemblies.Name = "chkAssemblies";
            this.chkAssemblies.Size = new System.Drawing.Size(78, 17);
            this.chkAssemblies.TabIndex = 7;
            this.chkAssemblies.Text = "Assemblies";
            this.chkAssemblies.UseVisualStyleBackColor = true;
            // 
            // chkTriggers
            // 
            this.chkTriggers.AutoSize = true;
            this.chkTriggers.Location = new System.Drawing.Point(6, 134);
            this.chkTriggers.Name = "chkTriggers";
            this.chkTriggers.Size = new System.Drawing.Size(64, 17);
            this.chkTriggers.TabIndex = 6;
            this.chkTriggers.Text = "Triggers";
            this.chkTriggers.UseVisualStyleBackColor = true;
            // 
            // chkScripts
            // 
            this.chkScripts.AutoSize = true;
            this.chkScripts.Location = new System.Drawing.Point(6, 19);
            this.chkScripts.Name = "chkScripts";
            this.chkScripts.Size = new System.Drawing.Size(58, 17);
            this.chkScripts.TabIndex = 0;
            this.chkScripts.Text = "Scripts";
            this.chkScripts.UseVisualStyleBackColor = true;
            // 
            // chkJobs
            // 
            this.chkJobs.AutoSize = true;
            this.chkJobs.Location = new System.Drawing.Point(6, 111);
            this.chkJobs.Name = "chkJobs";
            this.chkJobs.Size = new System.Drawing.Size(48, 17);
            this.chkJobs.TabIndex = 5;
            this.chkJobs.Text = "Jobs";
            this.chkJobs.UseVisualStyleBackColor = true;
            // 
            // chkEvents
            // 
            this.chkEvents.AutoSize = true;
            this.chkEvents.Location = new System.Drawing.Point(6, 42);
            this.chkEvents.Name = "chkEvents";
            this.chkEvents.Size = new System.Drawing.Size(79, 17);
            this.chkEvents.TabIndex = 1;
            this.chkEvents.Text = "Job Events";
            this.chkEvents.UseVisualStyleBackColor = true;
            // 
            // chkCred
            // 
            this.chkCred.AutoSize = true;
            this.chkCred.Location = new System.Drawing.Point(6, 65);
            this.chkCred.Name = "chkCred";
            this.chkCred.Size = new System.Drawing.Size(78, 17);
            this.chkCred.TabIndex = 2;
            this.chkCred.Text = "Credentials";
            this.chkCred.UseVisualStyleBackColor = true;
            // 
            // chkConn
            // 
            this.chkConn.AutoSize = true;
            this.chkConn.Location = new System.Drawing.Point(6, 88);
            this.chkConn.Name = "chkConn";
            this.chkConn.Size = new System.Drawing.Size(115, 17);
            this.chkConn.TabIndex = 3;
            this.chkConn.Text = "Connection Strings";
            this.chkConn.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.jobsTree);
            this.tabPage5.Controls.Add(this.btnFireAll);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(777, 448);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "FireJob";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // jobsTree
            // 
            this.jobsTree.CheckBoxes = true;
            this.jobsTree.Location = new System.Drawing.Point(6, 6);
            this.jobsTree.Name = "jobsTree";
            this.jobsTree.Size = new System.Drawing.Size(319, 434);
            this.jobsTree.TabIndex = 1;
            // 
            // btnFireAll
            // 
            this.btnFireAll.Location = new System.Drawing.Point(472, 189);
            this.btnFireAll.Name = "btnFireAll";
            this.btnFireAll.Size = new System.Drawing.Size(75, 23);
            this.btnFireAll.TabIndex = 0;
            this.btnFireAll.Text = "Fire All";
            this.btnFireAll.UseVisualStyleBackColor = true;
            this.btnFireAll.Click += new System.EventHandler(this.btnFireAll_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dataGridView1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(777, 448);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Property Table";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.value});
            this.dataGridView1.Location = new System.Drawing.Point(70, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(606, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Parameter Name";
            this.name.Name = "name";
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.value.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.value.HeaderText = "Parameter Value";
            this.value.Items.AddRange(new object[] {
            "Yesterday\'s Date",
            "Yesterday\'s Gaming Date",
            "Two Days Pervious Date"});
            this.value.Name = "value";
            this.value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 474);
            this.Controls.Add(this.tabControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateIcons;
        private System.Windows.Forms.TextBox txtDll;
        private System.Windows.Forms.ListView iconList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkUseLarge;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.TabPage tabPage3;
        private Controls.EditableList e2;
        private Controls.EditableList e1;
        private Controls.EditableList e6;
        private Controls.EditableList e5;
        private Controls.EditableList e4;
        private Controls.EditableList e3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox chkConn;
        private System.Windows.Forms.CheckBox chkCred;
        private System.Windows.Forms.CheckBox chkEvents;
        private System.Windows.Forms.CheckBox chkScripts;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkJobs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnFireAll;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListView stockList;
        private System.Windows.Forms.CheckBox chkAssemblies;
        private System.Windows.Forms.CheckBox chkTriggers;
        private System.Windows.Forms.TreeView jobsTree;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn value;

    }
}