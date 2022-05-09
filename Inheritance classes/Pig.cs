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
    internal class Pig : Mammal
    {
        public const int _buy_pig = 150;
        public const int _sell_pig = 70;
        private Random rand = new Random();
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.PigSound);
            noise.Play();
        }
        public Pig() : base()
        {
            _spieces = 4;
        }
        public Pig(int id, Form1 form1) : base()
        {
            _coordinates.X = rand.Next(100, 700);
            _coordinates.Y = rand.Next(100, 500);
            displayAnimal(form1);
            _id = id;
            _spieces = 4;
        }
        ~Pig()
        {

        }
        public override void displayAnimal(Form1 form1)
        {
            visual = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.pig;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.pig;
            visual.Location = new System.Drawing.Point((int)_coordinates.X, (int)_coordinates.Y);
            visual.Name = "visual";
            visual.Size = new System.Drawing.Size(58, 58);
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
            form1.Controls.Add(this.visual);
            ((System.ComponentModel.ISupportInitialize)(this.visual)).EndInit();
            //visual.Click += new System.EventHandler(this.visual_Click);
            visual.Parent = form1.pictureBox1;
        }
        public override void updateLocation(bool changeDirection)
        {
            if (changeDirection)
                createDirection();
            if (_coordinates.X + _direction.X <= 0 || _coordinates.X + _direction.X >= 760 ||
                _coordinates.Y + _direction.Y <= 0 || _coordinates.Y + _direction.Y >= 540)
                _direction = -_direction;
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
