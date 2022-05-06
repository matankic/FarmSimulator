using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Pig : Mammal
    {
      
        public const int _buy_pig = 150;
        public const int _sell_pig = 70;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.PigSound);
            noise.Play();
        }
        public Pig() : base()
        {
           
        }
        ~Pig()
        {
          
        }
    }
}
