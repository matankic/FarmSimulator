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
    internal class Goose : Bird
    {  
        public const int _buy_goose = 100;
        public const int _sell_goose = 87;
        private Random rand = new Random();
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.GooseSound);
            noise.Play();
        }
        public Goose() : base()
        {
            _spieces = 2;
        }
        public Goose(int id) : base()
        {
            _id = id;
            _spieces = 2;
        }
        ~Goose()
        {

        }
        public override void displayAnimal(PictureBox visual)
        {
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.goose;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.goose;
            visual.Location = new System.Drawing.Point((int)getX(), (int)getY());
            visual.Size = new System.Drawing.Size(60, 60);
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
        public override bool isInside(int X, int Y)
        {
            return Math.Abs(X - _coordinates.X) <= 30 && Math.Abs(Y - _coordinates.Y) <= 30;
        }
    }
}
