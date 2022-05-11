using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Bird : Animal
    {
        private int _eggs;
        public Bird() : base()
        {
            _eggs = 0;
            _speed = 5;
        }
        public override void gainSpeed() { _speed = 5; }
    }
}
