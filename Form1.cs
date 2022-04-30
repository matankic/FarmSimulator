﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldWinForms
{
    public partial class Form1 : Form
    {
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private int cnt_chicken, cnt_duck, cnt_goose, cnt_cow, cnt_pig, cnt_sheep;
        private int buy_chicken, buy_duck, buy_goose, buy_cow, buy_pig, buy_sheep;
        private int sell_chicken, sell_duck, sell_goose, sell_cow, sell_pig, sell_sheep;

        private int _credit, _minutes, _hours, _days;

        private void Duck_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.duck;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_duck;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void goose_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.goose;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_goose;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void Chicken_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.Chicken_Strut;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_chicken;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            amount_lbl.Text = comboBox1.SelectedIndex.ToString();
            int x = 0, price = 0;
            if (Chicken_radio.Checked == true)
            {
                price = buy_chicken;
            }
            else if (goose_radio.Checked == true)
            {
                price = buy_goose;
            }
            else if (pig_radio.Checked == true)
            {
                price = buy_pig;
            }
            else if (sheep_radio.Checked == true)
            {
                price = buy_sheep;
            }
            else if (Duck_radio.Checked == true)
            {
                price = buy_duck;
            }
            else if (cow_radio.Checked == true)
            {
                price = buy_cow;
            }


            try
            {
                x = Int32.Parse(amount_lbl.Text) * price;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int y = 0;
            try
            {
                y = Int32.Parse(comboBox1.Text);
                amount_lbl.Text = y.ToString();
            }
            catch
            {
                amount_lbl.Text = y.ToString();
            }
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_cow;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }

        private void sheep_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.sheep;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_sheep;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void pig_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.pig;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_pig;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void cow_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.cow;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * buy_cow;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
            //player.SoundLocation = "Relaxing.mp3";
            timer1.Start();

            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
                        
            cnt_chicken = cnt_duck = cnt_goose = cnt_cow = cnt_pig = cnt_sheep = 0;

            _minutes = 0;
            _hours = 5;
            _days = 1;
            _credit = 2000;
            label11.Text = _credit.ToString();

            buy_chicken = 50;
            buy_duck = 75;
            buy_goose = 100;
            buy_cow = 200;
            buy_pig = 150;
            buy_sheep = 225;

            sell_chicken = 47;
            sell_duck = 70;
            sell_goose = 87;
            sell_cow = 180;
            sell_pig = 70;
            sell_sheep = 200;


            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;
            label9.Parent = pictureBox1;
            label9.BackColor = Color.Transparent;
            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;
            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            cnt_chicken++;
            lbl_1.Text = cnt_chicken.ToString();

            _credit -= 50;
            if (_credit < 0)
            {
                label11.ForeColor = Color.Red;
                label12.ForeColor = Color.Red;
            }
            label11.Text = _credit.ToString();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _minutes++;
            label9.Text = _hours.ToString();
            label10.Text = _days.ToString();
            if (_minutes == 60)
            {
                _minutes = 0;
                _hours++;
            }
            if(_hours == 24)
            {
                _hours = 0;
                _days++;
            }
        }
    }
}
