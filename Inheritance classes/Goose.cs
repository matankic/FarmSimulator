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
        public Goose(int id, Form1 form1) : base()
        {
            displayAnimal(form1);
            _id = id;
            _spieces = 2;
        }
        ~Goose()
        {

        }
        public override void displayAnimal(Form1 form1)
        {
            visual = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.goose;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.goose;
            visual.Location = new System.Drawing.Point(rand.Next(2, 760), rand.Next(2, 540));
            visual.Name = "visual";
            visual.Size = new System.Drawing.Size(61, 58);
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
