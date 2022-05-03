using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HelloWorldWinForms
{
    internal class Animal
    {
        public virtual string _name { get; set; }
        private Time _age;
        private int _id,
            _thirst,
            _hunger,
            _health;
        private Vector vector;
        private double _speed;
        private bool _sex, _isFertile;
        public Animal() { }
        public void updateAnimal()
        {
            _age += 10; //TODO : adjust to the amount of world time

            _thirst -= 10;
            _hunger -= 10;
            _health -= 5;
        }
        public void feedAnimal()
        {
            _hunger += 200;
        }
        public void waterAnimal()
        {
            _thirst += 200;
        }
        public void healAnimal()
        {
            _health += 200;
        }
        public void displayAnimalStats(Label lbl1, Label lbl2, Label lbl3, Label lbl4, 
            Label lbl5, Label lbl6, Label lbl7, Label lbl8, Label lbl9, Label lbl10)
        {
            lbl1.Text = _name;
            lbl2.Text = _id.ToString();
        }

    }
}
