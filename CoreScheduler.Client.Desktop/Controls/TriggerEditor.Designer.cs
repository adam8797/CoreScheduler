namespace CoreScheduler.Client.Desktop.Controls
{
    partial class TriggerEditor
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
            this.mode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxDaysOfWeek = new System.Windows.Forms.GroupBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.boxRepeatEvery = new System.Windows.Forms.GroupBox();
            this.lblRepeatType = new System.Windows.Forms.Label();
            this.numRepeat = new System.Windows.Forms.NumericUpDown();
            this.boxStartOn = new System.Windows.Forms.GroupBox();
            this.dateStartOn = new System.Windows.Forms.DateTimePicker();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.boxTime = new System.Windows.Forms.GroupBox();
            this.boxCronString = new System.Windows.Forms.GroupBox();
            this.txtCron = new System.Windows.Forms.TextBox();
            this.boxEnds = new System.Windows.Forms.GroupBox();
            this.dateEndsOn = new System.Windows.Forms.DateTimePicker();
            this.radEndsOn = new System.Windows.Forms.RadioButton();
            this.radEndsNever = new System.Windows.Forms.RadioButton();
            this.boxMonthlyRepeat = new System.Windows.Forms.GroupBox();
            this.radDayOfWeek = new System.Windows.Forms.RadioButton();
            this.radDayOfMonth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radDoNothing = new System.Windows.Forms.RadioButton();
            this.radFirstMissed = new System.Windows.Forms.RadioButton();
            this.radAllMissed = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.boxDaysOfWeek.SuspendLayout();
            this.boxRepeatEvery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).BeginInit();
            this.boxStartOn.SuspendLayout();
            this.boxTime.SuspendLayout();
            this.boxCronString.SuspendLayout();
            this.boxEnds.SuspendLayout();
            this.boxMonthlyRepeat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly",
            "Cron",
            "No Trigger"});
            this.mode.Location = new System.Drawing.Point(6, 19);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(183, 21);
            this.mode.TabIndex = 0;
            this.mode.SelectedIndexChanged += new System.EventHandler(this.mode_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mode);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Of Trigger";
            // 
            // boxDaysOfWeek
            // 
            this.boxDaysOfWeek.Controls.Add(this.chkSaturday);
            this.boxDaysOfWeek.Controls.Add(this.chkFriday);
            this.boxDaysOfWeek.Controls.Add(this.chkThursday);
            this.boxDaysOfWeek.Controls.Add(this.chkWednesday);
            this.boxDaysOfWeek.Controls.Add(this.chkTuesday);
            this.boxDaysOfWeek.Controls.Add(this.chkMonday);
            this.boxDaysOfWeek.Controls.Add(this.chkSunday);
            this.boxDaysOfWeek.Location = new System.Drawing.Point(3, 63);
            this.boxDaysOfWeek.Name = "boxDaysOfWeek";
            this.boxDaysOfWeek.Size = new System.Drawing.Size(313, 49);
            this.boxDaysOfWeek.TabIndex = 2;
            this.boxDaysOfWeek.TabStop = false;
            this.boxDaysOfWeek.Text = "Days of the Week";
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(268, 19);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(33, 17);
            this.chkSaturday.TabIndex = 6;
            this.chkSaturday.Text = "S";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(227, 19);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(32, 17);
            this.chkFriday.TabIndex = 5;
            this.chkFriday.Text = "F";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(185, 19);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(33, 17);
            this.chkThursday.TabIndex = 4;
            this.chkThursday.Text = "T";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(139, 19);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(37, 17);
            this.chkWednesday.TabIndex = 3;
            this.chkWednesday.Text = "W";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(97, 19);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(33, 17);
            this.chkTuesday.TabIndex = 2;
            this.chkTuesday.Text = "T";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(53, 19);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(35, 17);
            this.chkMonday.TabIndex = 1;
            this.chkMonday.Text = "M";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(11, 19);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(33, 17);
            this.chkSunday.TabIndex = 0;
            this.chkSunday.Text = "S";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // boxRepeatEvery
            // 
            this.boxRepeatEvery.Controls.Add(this.lblRepeatType);
            this.boxRepeatEvery.Controls.Add(this.numRepeat);
            this.boxRepeatEvery.Location = new System.Drawing.Point(3, 171);
            this.boxRepeatEvery.Name = "boxRepeatEvery";
            this.boxRepeatEvery.Size = new System.Drawing.Size(130, 45);
            this.boxRepeatEvery.TabIndex = 3;
            this.boxRepeatEvery.TabStop = false;
            this.boxRepeatEvery.Text = "Repeat Every:";
            // 
            // lblRepeatType
            // 
            this.lblRepeatType.AutoSize = true;
            this.lblRepeatType.Location = new System.Drawing.Point(66, 21);
            this.lblRepeatType.Name = "lblRepeatType";
            this.lblRepeatType.Size = new System.Drawing.Size(31, 13);
            this.lblRepeatType.TabIndex = 1;
            this.lblRepeatType.Text = "Days";
            // 
            // numRepeat
            // 
            this.numRepeat.Location = new System.Drawing.Point(6, 19);
            this.numRepeat.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRepeat.Name = "numRepeat";
            this.numRepeat.Size = new System.Drawing.Size(54, 20);
            this.numRepeat.TabIndex = 0;
            this.numRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // boxStartOn
            // 
            this.boxStartOn.Controls.Add(this.dateStartOn);
            this.boxStartOn.Location = new System.Drawing.Point(139, 171);
            this.boxStartOn.Name = "boxStartOn";
            this.boxStartOn.Size = new System.Drawing.Size(177, 45);
            this.boxStartOn.TabIndex = 4;
            this.boxStartOn.TabStop = false;
            this.boxStartOn.Text = "Start On";
            // 
            // dateStartOn
            // 
            this.dateStartOn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStartOn.Location = new System.Drawing.Point(6, 19);
            this.dateStartOn.MinDate = new System.DateTime(2016, 9, 26, 0, 0, 0, 0);
            this.dateStartOn.Name = "dateStartOn";
            this.dateStartOn.Size = new System.Drawing.Size(165, 20);
            this.dateStartOn.TabIndex = 0;
            // 
            // dateTime
            // 
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTime.Location = new System.Drawing.Point(6, 20);
            this.dateTime.Name = "dateTime";
            this.dateTime.ShowUpDown = true;
            this.dateTime.Size = new System.Drawing.Size(94, 20);
            this.dateTime.TabIndex = 5;
            // 
            // boxTime
            // 
            this.boxTime.Controls.Add(this.dateTime);
            this.boxTime.Location = new System.Drawing.Point(204, 3);
            this.boxTime.Name = "boxTime";
            this.boxTime.Size = new System.Drawing.Size(112, 54);
            this.boxTime.TabIndex = 1;
            this.boxTime.TabStop = false;
            this.boxTime.Text = "Time";
            // 
            // boxCronString
            // 
            this.boxCronString.Controls.Add(this.txtCron);
            this.boxCronString.Location = new System.Drawing.Point(3, 64);
            this.boxCronString.Name = "boxCronString";
            this.boxCronString.Size = new System.Drawing.Size(313, 46);
            this.boxCronString.TabIndex = 5;
            this.boxCronString.TabStop = false;
            this.boxCronString.Text = "Cron String";
            // 
            // txtCron
            // 
            this.txtCron.Location = new System.Drawing.Point(9, 17);
            this.txtCron.Name = "txtCron";
            this.txtCron.Size = new System.Drawing.Size(296, 20);
            this.txtCron.TabIndex = 0;
            // 
            // boxEnds
            // 
            this.boxEnds.Controls.Add(this.dateEndsOn);
            this.boxEnds.Controls.Add(this.radEndsOn);
            this.boxEnds.Controls.Add(this.radEndsNever);
            this.boxEnds.Location = new System.Drawing.Point(3, 216);
            this.boxEnds.Name = "boxEnds";
            this.boxEnds.Size = new System.Drawing.Size(154, 89);
            this.boxEnds.TabIndex = 6;
            this.boxEnds.TabStop = false;
            this.boxEnds.Text = "Ends";
            // 
            // dateEndsOn
            // 
            this.dateEndsOn.Enabled = false;
            this.dateEndsOn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEndsOn.Location = new System.Drawing.Point(53, 55);
            this.dateEndsOn.Name = "dateEndsOn";
            this.dateEndsOn.Size = new System.Drawing.Size(95, 20);
            this.dateEndsOn.TabIndex = 5;
            // 
            // radEndsOn
            // 
            this.radEndsOn.AutoSize = true;
            this.radEndsOn.Location = new System.Drawing.Point(6, 56);
            this.radEndsOn.Name = "radEndsOn";
            this.radEndsOn.Size = new System.Drawing.Size(39, 17);
            this.radEndsOn.TabIndex = 2;
            this.radEndsOn.Text = "On";
            this.radEndsOn.UseVisualStyleBackColor = true;
            this.radEndsOn.CheckedChanged += new System.EventHandler(this.radEnds_CheckedChanged);
            // 
            // radEndsNever
            // 
            this.radEndsNever.AutoSize = true;
            this.radEndsNever.Checked = true;
            this.radEndsNever.Location = new System.Drawing.Point(6, 24);
            this.radEndsNever.Name = "radEndsNever";
            this.radEndsNever.Size = new System.Drawing.Size(54, 17);
            this.radEndsNever.TabIndex = 0;
            this.radEndsNever.TabStop = true;
            this.radEndsNever.Text = "Never";
            this.radEndsNever.UseVisualStyleBackColor = true;
            this.radEndsNever.CheckedChanged += new System.EventHandler(this.radEnds_CheckedChanged);
            // 
            // boxMonthlyRepeat
            // 
            this.boxMonthlyRepeat.Controls.Add(this.radDayOfWeek);
            this.boxMonthlyRepeat.Controls.Add(this.radDayOfMonth);
            this.boxMonthlyRepeat.Location = new System.Drawing.Point(3, 118);
            this.boxMonthlyRepeat.Name = "boxMonthlyRepeat";
            this.boxMonthlyRepeat.Size = new System.Drawing.Size(313, 47);
            this.boxMonthlyRepeat.TabIndex = 7;
            this.boxMonthlyRepeat.TabStop = false;
            this.boxMonthlyRepeat.Text = "Monthy Repeat";
            // 
            // radDayOfWeek
            // 
            this.radDayOfWeek.AutoSize = true;
            this.radDayOfWeek.Location = new System.Drawing.Point(160, 19);
            this.radDayOfWeek.Name = "radDayOfWeek";
            this.radDayOfWeek.Size = new System.Drawing.Size(106, 17);
            this.radDayOfWeek.TabIndex = 1;
            this.radDayOfWeek.Text = "Day of the Week";
            this.radDayOfWeek.UseVisualStyleBackColor = true;
            // 
            // radDayOfMonth
            // 
            this.radDayOfMonth.AutoSize = true;
            this.radDayOfMonth.Checked = true;
            this.radDayOfMonth.Location = new System.Drawing.Point(41, 19);
            this.radDayOfMonth.Name = "radDayOfMonth";
            this.radDayOfMonth.Size = new System.Drawing.Size(107, 17);
            this.radDayOfMonth.TabIndex = 0;
            this.radDayOfMonth.TabStop = true;
            this.radDayOfMonth.Text = "Day of the Month";
            this.radDayOfMonth.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radDoNothing);
            this.groupBox2.Controls.Add(this.radFirstMissed);
            this.groupBox2.Controls.Add(this.radAllMissed);
            this.groupBox2.Location = new System.Drawing.Point(162, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 89);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Missfire Instruction";
            // 
            // radDoNothing
            // 
            this.radDoNothing.AutoSize = true;
            this.radDoNothing.Checked = true;
            this.radDoNothing.Location = new System.Drawing.Point(6, 64);
            this.radDoNothing.Name = "radDoNothing";
            this.radDoNothing.Size = new System.Drawing.Size(79, 17);
            this.radDoNothing.TabIndex = 3;
            this.radDoNothing.TabStop = true;
            this.radDoNothing.Text = "Do Nothing";
            this.radDoNothing.UseVisualStyleBackColor = true;
            // 
            // radFirstMissed
            // 
            this.radFirstMissed.AutoSize = true;
            this.radFirstMissed.Location = new System.Drawing.Point(6, 41);
            this.radFirstMissed.Name = "radFirstMissed";
            this.radFirstMissed.Size = new System.Drawing.Size(136, 17);
            this.radFirstMissed.TabIndex = 2;
            this.radFirstMissed.Text = "Fire First Missed Trigger";
            this.radFirstMissed.UseVisualStyleBackColor = true;
            // 
            // radAllMissed
            // 
            this.radAllMissed.AutoSize = true;
            this.radAllMissed.Location = new System.Drawing.Point(6, 19);
            this.radAllMissed.Name = "radAllMissed";
            this.radAllMissed.Size = new System.Drawing.Size(133, 17);
            this.radAllMissed.TabIndex = 0;
            this.radAllMissed.Text = "Fire All Missed Triggers";
            this.radAllMissed.UseVisualStyleBackColor = true;
            // 
            // TriggerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.boxMonthlyRepeat);
            this.Controls.Add(this.boxEnds);
            this.Controls.Add(this.boxCronString);
            this.Controls.Add(this.boxTime);
            this.Controls.Add(this.boxStartOn);
            this.Controls.Add(this.boxRepeatEvery);
            this.Controls.Add(this.boxDaysOfWeek);
            this.Controls.Add(this.groupBox1);
            this.Name = "TriggerEditor";
            this.Size = new System.Drawing.Size(321, 308);
            this.groupBox1.ResumeLayout(false);
            this.boxDaysOfWeek.ResumeLayout(false);
            this.boxDaysOfWeek.PerformLayout();
            this.boxRepeatEvery.ResumeLayout(false);
            this.boxRepeatEvery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).EndInit();
            this.boxStartOn.ResumeLayout(false);
            this.boxTime.ResumeLayout(false);
            this.boxCronString.ResumeLayout(false);
            this.boxCronString.PerformLayout();
            this.boxEnds.ResumeLayout(false);
            this.boxEnds.PerformLayout();
            this.boxMonthlyRepeat.ResumeLayout(false);
            this.boxMonthlyRepeat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox boxDaysOfWeek;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.GroupBox boxRepeatEvery;
        private System.Windows.Forms.Label lblRepeatType;
        private System.Windows.Forms.NumericUpDown numRepeat;
        private System.Windows.Forms.GroupBox boxStartOn;
        private System.Windows.Forms.DateTimePicker dateStartOn;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.GroupBox boxTime;
        private System.Windows.Forms.GroupBox boxCronString;
        private System.Windows.Forms.TextBox txtCron;
        private System.Windows.Forms.GroupBox boxEnds;
        private System.Windows.Forms.DateTimePicker dateEndsOn;
        private System.Windows.Forms.RadioButton radEndsOn;
        private System.Windows.Forms.RadioButton radEndsNever;
        private System.Windows.Forms.GroupBox boxMonthlyRepeat;
        private System.Windows.Forms.RadioButton radDayOfWeek;
        private System.Windows.Forms.RadioButton radDayOfMonth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radDoNothing;
        private System.Windows.Forms.RadioButton radFirstMissed;
        private System.Windows.Forms.RadioButton radAllMissed;
    }
}
