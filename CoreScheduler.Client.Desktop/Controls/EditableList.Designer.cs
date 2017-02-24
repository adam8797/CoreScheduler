namespace CoreScheduler.Client.Desktop.Controls
{
    partial class EditableList
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
            this.list = new System.Windows.Forms.ListBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(0, 20);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(223, 160);
            this.list.TabIndex = 0;
            // 
            // txtAdd
            // 
            this.txtAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdd.Location = new System.Drawing.Point(0, 0);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(223, 20);
            this.txtAdd.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(229, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(18, 20);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSize = true;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(229, 23);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(19, 20);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "--";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Location = new System.Drawing.Point(228, 75);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(21, 23);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoveDown.FlatAppearance.BorderSize = 0;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Location = new System.Drawing.Point(228, 104);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(21, 23);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // comboBox
            // 
            this.comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(0, -1);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(223, 21);
            this.comboBox.TabIndex = 6;
            this.comboBox.Visible = false;
            this.comboBox.DropDown += new System.EventHandler(this.comboBox_DropDown);
            this.comboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // EditableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.list);
            this.Name = "EditableList";
            this.Size = new System.Drawing.Size(254, 179);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Label btnRemove;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.ComboBox comboBox;
    }
}
