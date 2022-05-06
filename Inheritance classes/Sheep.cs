﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldWinForms
{
    internal class Sheep : Mammal
    {
        public static int _cnt_sheep = 0;
        public const int _buy_sheep = 225;
        public const int _sell_sheep = 200;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.SheepSound);
            noise.Play();
        }
        public Sheep() : base()
        {
            _cnt_sheep++;
        }
        ~Sheep()
        {
            _cnt_sheep--;
        }
    }
}