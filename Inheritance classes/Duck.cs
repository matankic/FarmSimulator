using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    internal class Duck : Bird
    {
        public static int _cnt_duck = 0;
        public const int _buy_duck = 75;
        public const int _sell_duck = 70;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.DuckSound);
            noise.Play();
        }
        public Duck() : base()
        {
            _cnt_duck++;
        }
        ~Duck()
        {
            _cnt_duck--;
        }
    }
}
