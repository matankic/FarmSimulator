﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    internal class Cow : Mammal
    {
        public static int _cnt_cow = 0;
        public const int _buy_cow = 200;
        public const int _sell_cow = 180;
        public override void makeNoise()
        {
            noise = new SoundPlayer(Properties.Resources.CowSound);
            noise.Play();
        }
        public Cow() : base()
        {
            _cnt_cow++;
        }
        ~Cow()
        {
            _cnt_cow--;
        }
    }
}