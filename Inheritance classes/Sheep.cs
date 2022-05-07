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
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.SheepSound);
            noise.Play();
        }
        public Sheep() : base()
        {
            _spieces = 5;
        }
        public Sheep(int id, Form1 form1) : base()
        {
            displayAnimal(form1); 
            _id = id;
            _spieces = 5;
        }
        ~Sheep()
        {

        }
        public override void displayAnimal(Form1 form1)
        {
            visual = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.sheep;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.sheep;
            visual.Location = new System.Drawing.Point(100, 340);
            visual.Name = "visual";
            visual.Size = new System.Drawing.Size(75, 65);
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
            form1.Controls.Add(this.visual);
            ((System.ComponentModel.ISupportInitialize)(this.visual)).EndInit();
            //visual.Click += new System.EventHandler(this.visual_Click);
            visual.Parent = form1.pictureBox1;
            visual.BringToFront();
        }
    }
}
