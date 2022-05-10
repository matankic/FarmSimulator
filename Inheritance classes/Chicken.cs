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
        public Chicken(int id) : base()
        {
            _id = id;
            _spieces = 0;
        }
        ~Chicken()
        {

        }
        public override void displayAnimal(PictureBox visual)
        {
            visual.Image = global::HelloWorldWinForms.Properties.Resources.Chicken_Strut;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.Chicken_Strut;
            visual.Size = new System.Drawing.Size(32, 32);
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Location = new System.Drawing.Point((int)getX(), (int)getY());
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
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
            _direction.X = rand.Next(0, _id * 100) - 100 - _id * 50;
            _direction.Y = rand.Next(0, _id * 100) - 100 - _id * 50;
            _direction.Normalize();
            _direction *= _speed;
        }
    }
}
