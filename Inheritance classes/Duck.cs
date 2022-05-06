using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Duck : Bird
    {
        public const int _buy_duck = 75;
        public const int _sell_duck = 70;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.DuckSound);
            noise.Play();
        }
        public Duck() : base()
        {
           
        }
        ~Duck()
        {
           
        }
    }
}
