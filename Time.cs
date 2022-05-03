using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWinForms
{
    internal class Time
    {
        private int _hours, _days;
        public Time()
        {
            _hours = 5;
            _days = 1;
        }
        public Time(int x, int y)
        {
            _hours = x;
            _days = y;
        }
        public void tick()
        {
            _hours++;
            if (_hours == 24)
            {
                _hours = 0;
                _days++;
            }
        }
        public void tick(Label hours_lbl, Label days_lbl)
        {
            _hours++;
            if (_hours == 24)
            {
                _hours = 0;
                _days++;
                hours_lbl.Text = hoursUpdate();
                days_lbl.Text = daysUpdate();
                return;
            }
            hours_lbl.Text = hoursUpdate();
        }
        public int get_hours() { return _hours; }
        public int get_days() { return _days; }
        public string hoursUpdate()
        {
            return _hours.ToString();
        }
        public string daysUpdate()
        {
            return _days.ToString();
        }
        public static Time operator +(Time a, int b) => new Time(a._hours + b, a._days);
        public static Time operator -(Time a, int b) => new Time(a._hours - b, a._days);
    }
}
