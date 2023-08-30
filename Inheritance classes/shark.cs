﻿using System;
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
    internal class shark : Mammal
    {
        public const int _buy_shark = 150;
        public const int _sell_shark = 70;
        private static Random rand = new Random();
        public override void makeNoise()
        {
            SoundPlayer noise = new SoundPlayer(Properties.Resources.PigSound);
            noise.Play();
            noise.Dispose();
        }
        public shark() : base()
        {
            _spieces = 4;
        }
        public shark(int id) : base()
        {
            _id = id;
            _spieces = 4;
        }
        ~shark()
        {

        }
        public override void displayAnimal(PictureBox visual)
        {
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.shark;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.shark;
            visual.Location = new System.Drawing.Point((int)getX(), (int)getY());
            visual.Size = new System.Drawing.Size(200, 120);
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
        }
        public override void updateLocation(bool changeDirection)
        {
            if (changeDirection)
                createDirection();
            if (_coordinates.X + _direction.X <= 130 || _coordinates.X + _direction.X >= 760 ||
                _coordinates.Y + _direction.Y <= 0 || _coordinates.Y + _direction.Y >= 480)
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
            return Math.Abs(X - _coordinates.X) <= 60 && Math.Abs(Y - _coordinates.Y) <= 60;
        }
        public override void updateStats()
        {
            if (_hunger - 7 <= 0 || _health - 5 <= 0 || _thirst - 3 <= 0)
                _isAlive = false;
            else
            {
                _hunger -= 7;
                _thirst -= 3;
                _health -= 5;
            }
        }
    }
}
