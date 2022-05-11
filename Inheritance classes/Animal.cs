using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Animal
    {
        protected SoundPlayer noise;
        private static Random rand = new Random();
        private string _name;
        private Time _age;
        protected int _id, _spieces, 
            _thirst,
            _hunger,
            _health;
        protected Vector _coordinates, _direction;
        protected double _speed;
        private bool _sex;
       
        public Animal() {
            _coordinates.X = rand.Next(140, 700);
            _coordinates.Y = rand.Next(100, 465);
            _speed = 3;
            int val = rand.Next(0, 1);
            if (val == 0)
                _sex = false; // female
            else
                _sex = true; // male
            _age = new Time();
            _thirst = _hunger = _health = 100;
            _name = generateName(rand.Next(0, 20));
            createDirection();
        }
        public virtual void makeNoise() { }
        public virtual void displayAnimal(PictureBox visual) { }
        public virtual bool isInside(int X, int Y) { return true; }
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
        public void displayAnimalStats(Label lbl1, Label lbl2, ProgressBar bar1, ProgressBar bar2,
            ProgressBar bar3, Label lbl6, Label lbl7, Label lbl8, Label lbl9)
        {
            lbl1.Text = _name;
            lbl2.Text = _id.ToString();
            bar1.Value = _hunger;
            bar2.Value = _thirst;
            bar3.Value = _health;
            if (_sex)
                lbl6.Text = "Female";
            else
                lbl6.Text = "Male";
            lbl7.Text = _age.daysUpdate() + " days";
            lbl8.Text = ((int)_coordinates.X).ToString();
            lbl9.Text = ((int)_coordinates.Y).ToString();
        }
        public virtual void updateLocation(bool changeDirection) { }
        public virtual void createDirection() { }
        public double getX() { return _coordinates.X; }
        public double getY() { return _coordinates.Y; }
        public void SetX(int val) { _coordinates.X = (double)val; } 
        public void SetY(int val) { _coordinates.Y = (double)val; } 
        public double getSpeed() { return _speed; }
        public void setSpeed(int val) { _speed = val; }
        public virtual void gainSpeed() { }
        private string generateName(int val)
        {
            switch (val)
            {
                case 0: return "Simba";
                case 1: return "Lala";
                case 2: return "Pooh";
                case 3: return "Simba";
                case 4: return "Eyal";
                case 5: return "Holon";
                case 6: return "Jerusalem";
                case 7: return "Efi";
                case 8: return "Elad";
                case 9: return "Shrek";
                case 10: return "Lehem";
                case 11: return "Nevel";
                case 12: return "Yosef";
                case 13: return "Sami";
                case 14: return "Rina";
                case 15: return "Gigi";
                case 16: return "Shon";
                case 17: return "Nala";
                case 18: return "Roti";
                case 19: return "Baal";
                case 20: return "Enlil";
                default: return "Eyal";
            }
        }
    }
}
