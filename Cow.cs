using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    internal class Cow : Mammal
    {

       public  void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.CowSound);
            noise.Play();
        }
        
        
    }
}
