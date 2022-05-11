using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Mammal : Animal
    {
        protected bool _isLactating;
        public Mammal() : base()
        {
            _isLactating = false;
            _speed = 2;
        }
        public override void gainSpeed() { _speed = 2; }
        public void updateLactate() { _isLactating = true; }
        public override bool  doesLactate() { return _isLactating; }
      
    }
}


