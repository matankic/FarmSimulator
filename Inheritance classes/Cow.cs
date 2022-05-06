using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Cow : Mammal
    {
        
        public const int _buy_cow = 200;
        public const int _sell_cow = 180;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.CowSound);
            noise.Play();
        }
        public Cow() : base()
        {
            
        }
        ~Cow()
        {
            
        }
    }
}
