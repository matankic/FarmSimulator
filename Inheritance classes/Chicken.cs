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
            displayAnimal(form1);
            _id = id;
            _spieces = 0;
        }
        ~Chicken()
        {

        }
        public override void displayAnimal(Form1 form1)
        {
            visual = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            visual.BackColor = System.Drawing.Color.Transparent;
            visual.Cursor = System.Windows.Forms.Cursors.Hand;
            visual.Image = global::HelloWorldWinForms.Properties.Resources.Chicken_Strut;
            visual.InitialImage = global::HelloWorldWinForms.Properties.Resources.Chicken_Strut;
            visual.Location = new System.Drawing.Point(rand.Next(2, 760), rand.Next(2, 540));
            visual.Name = "visual";
            visual.Size = new System.Drawing.Size(32, 32);
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
