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
        protected int _eggs, _nextEgg;
        public Bird() : base()
        {
            _eggs = 0;
            _nextEgg = 0;
            _speed = 5;
        }
        public override void gainSpeed() { _speed = 5; }
        public void takeEggs() { _eggs = 0; }
        public override int doesEgg() { return _eggs; }
    }
}
