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
    internal class Cow : Mammal
    {  
        public const int _buy_cow = 200;
        public const int _sell_cow = 180;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.CowSound);
            noise.Play();
        }
        public Cow() : base()
        {
            _spieces = 3;
        }
        public Cow(int id, Form1 form1) : base()
        {
            displayAnimal(form1);
            _id = id;
            _spieces = 3;
        }
        ~Cow()
        {

        }
        public override void displayAnimal(Form1 form1)
        {
            visual = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.cow;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.cow;
            visual.Location = new System.Drawing.Point((int)_coordinates.X, (int)_coordinates.Y);
            visual.Name = "visual";
            visual.Size = new System.Drawing.Size(61, 58);
            visual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            visual.TabIndex = 13;
            visual.TabStop = false;
            form1.Controls.Add(this.visual);
            ((System.ComponentModel.ISupportInitialize)(this.visual)).EndInit();
            //visual.Click += new System.EventHandler(this.visual_Click);
            visual.Parent = form1.pictureBox1;
        }
    }
}
