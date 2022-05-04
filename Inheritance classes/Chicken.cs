using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    internal class Chicken : Bird
    {
        public static int _cnt_chicken = 0;
        public const int _buy_chicken = 50;
        public const int _sell_chicken = 47;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.ChickenSound);
            noise.Play();
        }
        public Chicken() : base()
        {
            _cnt_chicken++;
        }
        ~Chicken()
        {
            _cnt_chicken--;
        }
    }
}
