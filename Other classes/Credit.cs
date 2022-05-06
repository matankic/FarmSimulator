using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Credit
    {
        protected int _credit;
        protected  double _interest;
        public Credit()
        {
            _credit = 2000;
            _interest = 0.01;
        }
        public Credit(int x, double y)
        {
            _credit = x;
            _interest = y;
        }
        public int get_credit() { return _credit; }
        public double get_interest() { return _interest; }
        public string creditUpdate()
        {
            if (_credit < -99999)
                return "OVD :(";
            return _credit.ToString();
        }
        public void applyInterest()
        {
            if (_credit < 0)
                _credit += (int)((double)(_credit) * 0.01);
        }
        public static Credit operator +(Credit a, int b) => new Credit(a._credit + b, a._interest);
        public static Credit operator -(Credit a, int b) => new Credit(a._credit - b, a._interest);
    }
}
