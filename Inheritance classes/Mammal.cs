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
        private bool _isLactating; //?
        private int _Pragnancy;
        public Mammal() : base()
        {
            _isLactating = false;
            _Pragnancy = 0;
            _speed = 2;
        }
    }
}


