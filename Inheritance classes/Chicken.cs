using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Drawing;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Chicken : Bird
    {
        public const int _buy_chicken = 50;
        public const int _sell_chicken = 47;
        private Random rand = new Random();
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.ChickenSound);
            noise.Play();
        }
        public Chicken() : base()
        {
            _spieces = 0;
        }
        public Chicken(int id, Form1 form1) : base()
        {
            _coordinates.X = rand.Next(140, 700);
            _coordinates.Y = rand.Next(100, 500);
            displayAnimal(form1);
            _id = id;
            _spieces = 0;
        }
        ~Chicken()
        {

        }
        public override void updateLocation(bool changeDirection)
        {
            if (changeDirection)
                createDirection();
            if (_coordinates.X + _direction.X <= 130 || _coordinates.X + _direction.X >= 760 ||
                _coordinates.Y + _direction.Y <= 0 || _coordinates.Y + _direction.Y >= 540)
            {
                if (_coordinates.X + _direction.X <= 130 && _coordinates.X + _direction.X > 0 &&
                    _coordinates.Y + _direction.Y > 30 && _coordinates.Y + _direction.Y < 480)
                {
                    _coordinates += _direction;
                    return;
                }
                    _direction = -_direction;
            }
            _coordinates += _direction;
        }
        public override void createDirection()
        {
            _direction.X = rand.Next(0, 200) - 100;
            _direction.Y = rand.Next(0, 200) - 100;
            _direction.Normalize();
            _direction *= _speed;
        }
    }
}
