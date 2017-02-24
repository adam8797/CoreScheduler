namespace CoreScheduler.Client.Desktop.Controls
{
    partial class LargeTriggerEditor
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.forecastCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cronLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTriggerName = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.forecastCalendar);
            this.groupBox5.Location = new System.Drawing.Point(322, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(486, 350);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Forecast";
            // 
            // forecastCalendar
            // 
            this.forecastCalendar.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.forecastCalendar.Location = new System.Drawing.Point(12, 22);
            this.forecastCalendar.Name = "forecastCalendar";
            this.forecastCalendar.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cronLabel);
            this.groupBox4.Location = new System.Drawing.Point(3, 376);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 37);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cron Expression";
            // 
            // cronLabel
            // 
            this.cronLabel.Location = new System.Drawing.Point(6, 16);
            this.cronLabel.Name = "cronLabel";
            this.cronLabel.Size = new System.Drawing.Size(301, 13);
            this.cronLabel.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSummary);
            this.groupBox3.Location = new System.Drawing.Point(3, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 62);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Summary";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(6, 16);
            this.lblSummary.MaximumSize = new System.Drawing.Size(301, 62);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(57, 13);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "No Trigger";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTriggerName);
            this.groupBox6.Location = new System.Drawing.Point(322, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(486, 54);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Trigger Name";
            // 
            // txtTriggerName
            // 
            this.txtTriggerName.Location = new System.Drawing.Point(12, 19);
            this.txtTriggerName.Name = "txtTriggerName";
            this.txtTriggerName.Size = new System.Drawing.Size(458, 20);
            this.txtTriggerName.TabIndex = 0;
            // 
            // LargeTriggerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.CronLabel = this.cronLabel;
            this.ForecastCalendar = this.forecastCalendar;
            this.ForecastFor = System.TimeSpan.Parse("120.00:00:00");
            this.MaximumSize = new System.Drawing.Size(813, 416);
            this.MinimumSize = new System.Drawing.Size(813, 416);
            this.Name = "LargeTriggerEditor";
            this.NameBox = this.txtTriggerName;
            this.Size = new System.Drawing.Size(813, 416);
            this.SummaryLabel = this.lblSummary;
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MonthCalendar forecastCalendar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label cronLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTriggerName;
    }
}
