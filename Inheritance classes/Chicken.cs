using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Chicken : Bird
    {
        public const int _buy_chicken = 50;
        public const int _sell_chicken = 47;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.ChickenSound);
            noise.Play();
        }
        public Chicken() : base()
        {
            _spieces = 0;
        }
        public Chicken(int id) : base()
        {
            _id = id;
            _spieces = 0;
        }
        ~Chicken()
        {
          
        }
    }
}
