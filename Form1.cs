using System;
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
        private int cnt_chicken;
        private int _minutes;
        private int _hours;
        private int _days;

        public Form1()
        {
            InitializeComponent();
            //player.SoundLocation = "Relaxing.mp3";
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cnt_chicken = 0;
            _minutes = 0;
            _hours = 5;
            _days = 1;
            label9.BackColor = System.Drawing.Color.Transparent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cnt_chicken++;
            lbl_1.Text = cnt_chicken.ToString();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _minutes++;
            label13.Text = _minutes.ToString();
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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
