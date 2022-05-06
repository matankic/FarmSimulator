using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Sheep : Mammal
    { 
        public const int _buy_sheep = 225;
        public const int _sell_sheep = 200;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.SheepSound);
            noise.Play();
        }
        public Sheep() : base()
        {
           
        }
        public Sheep(int id) : base()
        {
            _id = id;
            _spieces = 5;
        }
        ~Sheep()
        {
           
        }
    }
}
