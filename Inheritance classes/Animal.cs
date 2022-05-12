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
        private static Random rand = new Random();
        readonly private string _name;
        public Time _age;
        public  int _id, _spieces;

         protected int _thirst,
            _hunger,
            _health;
        protected Vector _coordinates, _direction;
        protected double _speed;
        protected readonly bool _sex;
        public bool _isAlive;
        
        public Animal() {
            _isAlive = true;
            _coordinates.X = rand.Next(140, 700);
            _coordinates.Y = rand.Next(100, 465);
            _speed = 3;
            int val = rand.Next(0, 100);
            if (val < 55)
                _sex = false; // female
            else
                _sex = true; // male
            _age = new Time(0, 1);
            _thirst = _hunger = _health = 300;
            _name = generateName(rand.Next(0, 38));
            createDirection();
        }
        public virtual void makeNoise() { }
        public virtual bool doesLactate() { return false; }
        public virtual void displayAnimal(PictureBox visual) { }
        public virtual bool isInside(int X, int Y) { return true; }
        public void feedAnimal()
        {
            if (_hunger + 50 <= 300)
                _hunger += 50;
            else
                _hunger = 300;
        }
        public void waterAnimal()
        {
            if (_thirst + 30 <= 300)
                _thirst += 30;
            else
                _thirst = 300;
        }
        public void healAnimal()
        {
            if (_health + 100 <= 300)
                _health += 100;
            else
                _health = 300;
        }
        public void displayAnimalStats(Label lbl1, Label lbl2, Label lbl3, ProgressBar bar1, ProgressBar bar2,
            ProgressBar bar3, Label lbl5, Label lbl6, Label lbl7, Label lbl8)
        {
            lbl1.Text = _name;
            lbl2.Text = _id.ToString();
            bar1.Value = _hunger;
            bar2.Value = _thirst;
            bar3.Value = _health;
            if (_sex)
                lbl5.Text = "Male";
            else
                lbl5.Text = "Female";
            lbl6.Text = _age.daysUpdate() + " days";
            lbl7.Text = ((int)_coordinates.X).ToString();
            lbl8.Text = ((int)_coordinates.Y).ToString();
            switch (_spieces)
            {
                case 0: lbl3.Text = "Chicken"; break;
                case 1: lbl3.Text = "Duck"; break;
                case 2: lbl3.Text = "Goose"; break;
                case 3: lbl3.Text = "Cow"; break;
                case 4: lbl3.Text = "Pig"; break;
                case 5: lbl3.Text = "Sheep"; break;
                default: break;
            }
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
        public virtual void updateStats() { }
        public int getSpieces() { return _spieces; }
        private string generateName(int val)
        {
            switch (val)
            {
                case 0: return "Hezi";
                case 1: return "Tzahi";
                case 2: return "Hertzel";
                case 3: return "Shuki";
                case 4: return "Eyal";
                case 5: return "Noa";
                case 6: return "Shuki";
                case 7: return "Efi";
                case 8: return "Elad";
                case 9: return "Shrek";
                case 10: return "Gadi";
                case 11: return "Naveh";
                case 12: return "Yosef";
                case 13: return "Sami";
                case 14: return "Rina";
                case 15: return "Gigi";
                case 16: return "Ziona";
                case 17: return "Shimrit";
                case 18: return "Roti";
                case 19: return "Osnat";
                case 20: return "Dafna";
                case 21: return "Riki";
                case 22: return "Eti";
                case 23: return "Nadav";
                case 24: return "Nevo";
                case 25: return "Raz";
                case 26: return "Gila";
                case 27: return "Ezra";
                case 28: return "Yeheskel";
                case 29: return "Shosh";
                case 30: return "Ilanit";
                case 31: return "Ravit";
                case 32: return "Revital";
                case 33: return "Shahar";
                case 34: return "Maayan";
                case 35: return "Shalev";
                case 36: return "Lidor";
                case 37: return "Itay";
                case 38: return "Almog";
                default: return "Eyal";
            }
        }
    }
}
