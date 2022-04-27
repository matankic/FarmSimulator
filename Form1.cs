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
        
        public Form1()
        {
            InitializeComponent();
            //player.SoundLocation = "Relaxing.mp3";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cnt_chicken = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //player.Play();
            cnt_chicken++;
            lbl_click.Text = cnt_chicken.ToString();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
