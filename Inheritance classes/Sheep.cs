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
    internal class Sheep : Mammal
    { 
        public const int _buy_sheep = 225;
        public const int _sell_sheep = 200;
        private int _lactatingCounter;
        private static Random rand = new Random();
        public override void makeNoise()
        {
            SoundPlayer noise = new SoundPlayer(Properties.Resources.SheepSound);
            noise.Play();
            noise.Dispose();
        }
        public Sheep() : base()
        {
            _lactatingCounter = 0;
            _spieces = 5;
        }
        public Sheep(int id) : base()
        {
            _lactatingCounter = 0;
            _id = id;
            _spieces = 5;
        }
        ~Sheep()
        {

        }
        public override void displayAnimal(PictureBox visual)
        {
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.sheep;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.sheep;
            visual.Location = new System.Drawing.Point((int)_coordinates.X, (int)_coordinates.Y);
            visual.Size = new System.Drawing.Size(65, 65);
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
        }
        public override void updateLocation(bool changeDirection)
        {
            if (changeDirection)
                createDirection();
            if (_coordinates.X + _direction.X <= 130 || _coordinates.X + _direction.X >= 760 ||
                _coordinates.Y + _direction.Y <= 0 || _coordinates.Y + _direction.Y >= 470)
            {
                if (_coordinates.X + _direction.X <= 130 && _coordinates.X + _direction.X > 0 &&
                    _coordinates.Y + _direction.Y > 30 && _coordinates.Y + _direction.Y < 450)
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
        public override bool isInside(int X, int Y)
        {
            return Math.Abs(X - _coordinates.X) <= 64 && Math.Abs(Y - _coordinates.Y) <= 64;
        }
        public override void updateStats()
        {
            if (_hunger - 3 <= 0 || _health - 2 <= 0 || _thirst - 4 <= 0)
                _isAlive = false;
            else { 
            _lactatingCounter++;
            _hunger -= 3;
            _thirst -= 4;
            _health -= 2;
                if (_lactatingCounter == 24)
                {
                    updateLactate(true);
                    _lactatingCounter = 0;
                }
            }
        }
    }
}
