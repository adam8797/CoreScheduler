using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CronExpressionDescriptor;
using Quartz;

namespace CoreScheduler.Client.Desktop.Controls
{
    public partial class TriggerEditor : UserControl
    {
        public Label SummaryLabel { get; set; }
        public Label CronLabel { get; set; }
        public MonthCalendar ForecastCalendar { get; set; }
        public TextBox NameBox { get; set; }
        public event Action<List<DateTime>> ForecastUpdate;
        public TimeSpan ForecastFor { get; set; }
        public TriggerKey Key { get; private set; }


        public TriggerEditor()
        {
            InitializeComponent();
            SummaryLabel = null;
            CronLabel = null;
            ForecastFor = new TimeSpan(30, 0, 0, 0);
            Key = new TriggerKey(Guid.NewGuid().ToString());

            mode.SelectedIndexChanged += RefreshExternalControls;
            dateTime.ValueChanged += RefreshExternalControls;
            chkMonday.CheckedChanged += RefreshExternalControls;
            chkTuesday.CheckedChanged += RefreshExternalControls;
            chkWednesday.CheckedChanged += RefreshExternalControls;
            chkThursday.CheckedChanged += RefreshExternalControls;
            chkFriday.CheckedChanged += RefreshExternalControls;
            chkSaturday.CheckedChanged += RefreshExternalControls;
            chkSunday.CheckedChanged += RefreshExternalControls;
            radDayOfMonth.CheckedChanged += RefreshExternalControls;
            radDayOfWeek.CheckedChanged += RefreshExternalControls;
            numRepeat.ValueChanged += RefreshExternalControls;
            dateStartOn.ValueChanged += RefreshExternalControls;
            radEndsNever.CheckedChanged += RefreshExternalControls;
            radEndsOn.CheckedChanged += RefreshExternalControls;
            dateEndsOn.ValueChanged += RefreshExternalControls;
            txtCron.TextChanged += RefreshExternalControls;

        }

        public TriggerEditor(ICronTrigger trigger) : this()
        {
            if (trigger != null)
            {
                LoadTrigger(trigger);
            }
        }

        public void LoadTrigger(ICronTrigger trigger)
        {
            mode.SelectedIndex = (int)Mode.Cron;

            txtCron.Text = trigger.CronExpressionString;

            Key = trigger.Key;

            switch (trigger.MisfireInstruction)
            {
                case -1: // All Missed
                    radAllMissed.Checked = true;
                    break;
                case 1: // First Missed
                    radFirstMissed.Checked = true;
                    break;
                default:
                    radDoNothing.Checked = true;
                    break;
                    
            }

            if (NameBox != null)
                NameBox.Text = trigger.Description;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (mode.SelectedIndex == -1)
                mode.SelectedIndex = 5;
            //Set the dateTime picker to the current hour and minute, but leave second at 0
            dateTime.Value = DateTime.Now.AddSeconds(-1*DateTime.Now.Second);
            RefreshExternalControls(null, null);
        }

        #region Events

        private void mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode.SelectedIndex == 4)
            {
                // Cron hides all the other boxes
                boxTime.Visible = false;
                boxRepeatEvery.Visible = false;
                boxStartOn.Visible = false;
                boxEnds.Visible = true;
                boxDaysOfWeek.Visible = false;
                boxMonthlyRepeat.Visible = false;
                boxCronString.Visible = true;
                boxCronString.Enabled = true;
            }
            else
            {
                boxTime.Visible = true;
                boxRepeatEvery.Visible = true;
                boxStartOn.Visible = true;
                boxEnds.Visible = true;
                boxDaysOfWeek.Visible = true;
                boxCronString.Visible = false;
                boxMonthlyRepeat.Visible = true;
                numRepeat.Value = 1;

                switch (mode.SelectedIndex)
                {
                    case 0:
                        //Daily
                        boxDaysOfWeek.Enabled = false;
                        boxTime.Enabled = true;
                        boxRepeatEvery.Enabled = true;
                        boxStartOn.Enabled = true;
                        boxEnds.Enabled = true;
                        boxMonthlyRepeat.Enabled = false;
                        lblRepeatType.Text = "Days";
                        break;
                    case 1:
                        //Weekly
                        boxDaysOfWeek.Enabled = true;
                        boxTime.Enabled = true;
                        boxRepeatEvery.Enabled = false;
                        boxStartOn.Enabled = true;
                        boxMonthlyRepeat.Enabled = false;
                        boxEnds.Enabled = true;
                        lblRepeatType.Text = "Weeks";
                        break;
                    case 2:
                        //Monthly
                        lblRepeatType.Text = "Months";
                        boxStartOn.Enabled = true;
                        boxEnds.Enabled = true;
                        boxDaysOfWeek.Enabled = false;
                        boxRepeatEvery.Enabled = true;
                        boxMonthlyRepeat.Enabled = true;
                        boxTime.Enabled = true;
                        break;
                    case 3:
                        //Yearly
                        lblRepeatType.Text = "Years";
                        boxStartOn.Enabled = true;
                        boxDaysOfWeek.Enabled = false;
                        boxEnds.Enabled = true;
                        boxMonthlyRepeat.Enabled = false;
                        boxTime.Enabled = true;
                        break;
                    case 5:
                        //No Trigger
                        boxTime.Enabled = false;
                        boxRepeatEvery.Enabled = false;
                        boxStartOn.Enabled = false;
                        boxEnds.Enabled = false;
                        boxDaysOfWeek.Enabled = false;
                        boxCronString.Enabled = false;
                        break;
                }
            }
        }

        private void radEnds_CheckedChanged(object sender, EventArgs e)
        {
            dateEndsOn.Enabled = !radEndsNever.Checked;
        }

        private void RefreshExternalControls(object sender, EventArgs e)
        {
            #region Disabled

            if (SummaryLabel != null && false)
            {
                if (mode.SelectedIndex == 5) // No Trigger
                {
                    SummaryLabel.Text = "Disabled";
                }

                SummaryLabel.Text = dateTime.Value.ToString("t");

                // Daily
                if (mode.SelectedIndex == 0)
                {
                    if (numRepeat.Value == 1)
                        SummaryLabel.Text += ", Daily,";
                    else
                        SummaryLabel.Text += ", Every " + numRepeat.Value + " days,";
                }
                // Weekly
                else if (mode.SelectedIndex == 1)
                {
                    if (numRepeat.Value == 1)
                        SummaryLabel.Text += ", Weekly on";
                    else
                        SummaryLabel.Text += ", Every " + numRepeat.Value + " weeks on";

                    var s = chkSunday.Checked;
                    var m = chkMonday.Checked;
                    var t = chkTuesday.Checked;
                    var w = chkWednesday.Checked;
                    var th = chkThursday.Checked;
                    var f = chkFriday.Checked;
                    var sat = chkSaturday.Checked;

                    if (!s && m && t && w && th && f && !sat) // weekdays
                        SummaryLabel.Text += " weekdays,";
                    else if (s && !m && !t && !w && !th && !f && sat) // weekends
                        SummaryLabel.Text += " weekends,";
                    else if (s && m && t && w && th && f && sat)
                        SummaryLabel.Text += " all days,";
                    else
                    {
                        if (s) SummaryLabel.Text += " Sunday,";
                        if (m) SummaryLabel.Text += " Monday,";
                        if (t) SummaryLabel.Text += " Tuesday,";
                        if (w) SummaryLabel.Text += " Wednesday,";
                        if (th) SummaryLabel.Text += " Thursday,";
                        if (f) SummaryLabel.Text += " Friday,";
                        if (sat) SummaryLabel.Text += " Saturday,";
                    }

                }
                // Monthly
                else if (mode.SelectedIndex == 2)
                {
                    if (numRepeat.Value == 1)
                        SummaryLabel.Text += ", Monthly";
                    else
                        SummaryLabel.Text += ", Every " + numRepeat.Value + " months";

                    if (radDayOfMonth.Checked)
                    {
                        SummaryLabel.Text += " on day " + dateStartOn.Value.Day + ", ";
                    }
                    else if (radDayOfWeek.Checked)
                    {
                        //ToDo: Week of month for trigger editor
                        SummaryLabel.Text += " on 1st " + dateStartOn.Value.DayOfWeek + ", ";
                    }
                }
                // Yearly
                else if (mode.SelectedIndex == 3)
                {
                    if (numRepeat.Value == 1)
                        SummaryLabel.Text += ", Annually";
                    else
                        SummaryLabel.Text += ", Every " + numRepeat.Value + " years";

                    SummaryLabel.Text += " on " + dateStartOn.Value.ToString("MMMM dd") + ", ";

                }

                if (radEndsOn.Checked)
                    SummaryLabel.Text += " until " + dateEndsOn.Value.ToString("d");

                SummaryLabel.Text = SummaryLabel.Text.Trim(' ', ',');
            }

            #endregion

            var cron = BuildCron();

            if (SummaryLabel != null)
            {
                if ((Mode) mode.SelectedIndex == Mode.NoTrigger)
                {
                    SummaryLabel.Text = "No Trigger";
                }
                else
                {
                    try
                    {
                        SummaryLabel.Text = ExpressionDescriptor.GetDescription(cron);
                        if (radEndsOn.Checked)
                            SummaryLabel.Text += " until " + dateEndsOn.Value.ToString("d");
                    }
                    catch (Exception)
                    {
                        SummaryLabel.Text = "Error";
                    }
                }
            }

            if (CronLabel != null)
                CronLabel.Text = BuildCron();

            if (ForecastUpdate != null || ForecastCalendar != null)
            {
                var forecast = new List<DateTime>();

                try
                {
                    var expression = new CronExpression(cron);
                    var lastDateTime = DateTimeOffset.Now;
                    var endDate = DateTime.Now + ForecastFor;
                    int eval = 0;
                    while (lastDateTime < endDate && eval < 120)
                    {
                        var res = expression.GetTimeAfter(lastDateTime);

                        if (res.HasValue == false)
                            break;
                        forecast.Add(res.Value.DateTime);
                        lastDateTime = res.Value;
                        eval++;
                    }
                }
                catch (Exception)
                {
                    //Eat it
                }
                

                if (ForecastCalendar != null)
                {
                    if (radEndsNever.Checked)
                        ForecastCalendar.BoldedDates = forecast.ToArray();
                    else
                        ForecastCalendar.BoldedDates = forecast.Where(x => x.Date <= dateEndsOn.Value.Date).ToArray();
                }

                if (ForecastUpdate != null)
                    ForecastUpdate(forecast);
            }
        }
        
        #endregion
        
        private int GetWeekNumber(DateTime time)
        {
            var targetDay = time.DayOfWeek;
            var dayCount = 0;
            var lens = new DateTime(time.Year, time.Month, 1);

            while (lens < time)
            {
                if (lens.DayOfWeek == targetDay)
                    dayCount++;

                lens = lens.AddDays(1);
            }

            return dayCount;
        }

        private class Cron
        {
            public const int Seconds = 0;
            public const int Minutes = 1;
            public const int Hours = 2;
            public const int DayOfMonth = 3;
            public const int Month = 4;
            public const int DayOfWeek = 5;
            public const int Year = 6;
        }

        private enum Mode
        {
            Daily,
            Weekly,
            Monthly,
            Yearly,
            Cron,
            NoTrigger
        }


        public ITrigger Build()
        {
            var builder = BuildBuilder();
            if (builder == null)
                return null;
            return builder.Build();
        }

        public TriggerBuilder BuildBuilder()
        {
            if (mode.SelectedIndex >= 0 && mode.SelectedIndex < 5)
            {
                var cronString = BuildCron();

                var trig = TriggerBuilder.Create()
                    .WithCronSchedule(cronString, x =>
                    {
                        if (radDoNothing.Checked)
                            x.WithMisfireHandlingInstructionDoNothing();
                        else if (radAllMissed.Checked)
                            x.WithMisfireHandlingInstructionIgnoreMisfires();
                        else
                            x.WithMisfireHandlingInstructionFireAndProceed();
                    });

                var startTime = dateStartOn.Value.Date + dateTime.Value.TimeOfDay;

                if (DateTime.Now > startTime || (Mode) mode.SelectedIndex == Mode.Cron)
                    trig.StartNow();
                else
                    trig.StartAt(startTime);


                if (radEndsOn.Checked)
                    trig.EndAt(dateEndsOn.Value);
                
                if (NameBox != null)
                    trig.WithDescription(NameBox.Text);

                trig.WithIdentity(Key);

                return trig;
            }

            return null;
        }
        
        public string BuildCron()
        {
            if ((Mode) mode.SelectedIndex == Mode.Cron)
                return txtCron.Text;

            if ((Mode) mode.SelectedIndex == Mode.NoTrigger)
                return null;

            var comp = new string[7];

            //Build Seconds
            comp[Cron.Seconds] = dateTime.Value.Second.ToString();
            
            //Build Minutes
            comp[Cron.Minutes] = dateTime.Value.Minute.ToString();

            //Build Hours
            comp[Cron.Hours] = dateTime.Value.Hour.ToString();

            //Build DayOfMonth
            switch ((Mode)mode.SelectedIndex)
            {
                case Mode.Daily:
                    if (numRepeat.Value > 1)
                        comp[Cron.DayOfMonth] = "*/" + numRepeat.Value;
                    else
                        comp[Cron.DayOfMonth] = "*";
                    break;
                case Mode.Weekly:
                    comp[Cron.DayOfMonth] = "?";
                    break;
                case Mode.Monthly:
                    if (radDayOfMonth.Checked)
                        comp[Cron.DayOfMonth] = dateStartOn.Value.Day.ToString();
                    else
                        comp[Cron.DayOfMonth] = "?";
                    break;
                case Mode.Yearly:
                    comp[Cron.DayOfMonth] = dateStartOn.Value.Day.ToString();
                    break;
            }

            //Build Month
            switch ((Mode)mode.SelectedIndex)
            {
                case Mode.Daily:
                case Mode.Weekly:
                    comp[Cron.Month] = "*";
                    break;
                case Mode.Monthly:
                    if (numRepeat.Value > 1)
                        comp[Cron.Month] = "*/" + numRepeat.Value;
                    else
                        comp[Cron.Month] = "*";
                    break;
                case Mode.Yearly:
                    comp[Cron.Month] = dateStartOn.Value.Month.ToString();
                    break;
            }

            //Build DayofWeek

            switch ((Mode)mode.SelectedIndex)
            {
                case Mode.Daily:
                    comp[Cron.DayOfWeek] = "?";
                    break;
                case Mode.Weekly:
                    var s = chkSunday.Checked;
                    var m = chkMonday.Checked;
                    var t = chkTuesday.Checked;
                    var w = chkWednesday.Checked;
                    var th = chkThursday.Checked;
                    var f = chkFriday.Checked;
                    var sat = chkSaturday.Checked;

                    //All boxes checked, or none are
                    if ((s && m && t && w && th && f && sat) || (!s && !m && !t && !w && !th && !f && !sat))
                        comp[Cron.DayOfWeek] = "*";
                    else
                    {
                        comp[Cron.DayOfWeek] = "";

                        if (s) comp[Cron.DayOfWeek] += "SUN,";
                        if (m) comp[Cron.DayOfWeek] += "MON,";
                        if (t) comp[Cron.DayOfWeek] += "TUE,";
                        if (w) comp[Cron.DayOfWeek] += "WED,";
                        if (th) comp[Cron.DayOfWeek] += "THU,";
                        if (f) comp[Cron.DayOfWeek] += "FRI,";
                        if (sat) comp[Cron.DayOfWeek] += "SAT";

                        comp[Cron.DayOfWeek] = comp[Cron.DayOfWeek].Trim(',');
                    }
                    break;
                case Mode.Monthly:
                    if (radDayOfWeek.Checked)
                    {
                        var day = dateStartOn.Value.DayOfWeek.ToString().ToUpper().Substring(0, 3);
                        var pos = GetWeekNumber(dateStartOn.Value);
                        comp[Cron.DayOfWeek] = day + "#" + pos;
                    }
                    else
                        comp[Cron.DayOfWeek] = "?";
                    break;
                case Mode.Yearly:
                    comp[Cron.DayOfWeek] = "?";
                    break;
            }

            //Build Year?

            if ((Mode) mode.SelectedIndex == Mode.Yearly)
            {
                if (numRepeat.Value > 1)
                    comp[Cron.Year] = "*/" + numRepeat.Value;
                else
                    comp[Cron.Year] = "";
            }
            else
            {
                comp[Cron.Year] = "";
            }

            return string.Join(" ", comp);
        }


    }
}
