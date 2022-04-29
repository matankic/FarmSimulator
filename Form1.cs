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
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
            cnt_chicken = 0;
            _minutes = 0;
            _hours = 5;
            _days = 1;

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
