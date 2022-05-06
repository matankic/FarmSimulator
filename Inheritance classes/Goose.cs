using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Goose : Bird
    {  
        public const int _buy_goose = 100;
        public const int _sell_goose = 87;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.GooseSound);
            noise.Play();
        }
        public Goose() : base()
        {

        }
        public Goose(int id) : base()
        {
            _id = id;
            _spieces = 2;
        }
        ~Goose()
        {
           
        }
    }
}
