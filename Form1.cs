using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace HelloWorldWinForms
{
    public partial class Form1 : Form
    {
        //Fields
        private int cnt_chicken, cnt_duck, cnt_goose, cnt_cow, cnt_pig, cnt_sheep;
        private int buy_chicken, buy_duck, buy_goose, buy_cow, buy_pig, buy_sheep;
        private int sell_chicken, sell_duck, sell_goose, sell_cow, sell_pig, sell_sheep;
        private int counter;

        private SoundPlayer audio;

        private Credit myCredit;
        private Time myTime;
        
        //Methods
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            counter = 0;
            audio = new SoundPlayer(Properties.Resources.song);
            audio.Play();
            myCredit = new Credit(2000, 0.01);
            myTime = new Time(5, 1);

            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;

            cnt_chicken = cnt_duck = cnt_goose = cnt_cow = cnt_pig = cnt_sheep = 0;

            label11.Text = myCredit.creditUpdate();

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

        private void sell_btn_Click(object sender, EventArgs e)
        {
            int price = 0;
            try
            {
                price = Int32.Parse(label18.Text);
                if (price > 0)
                {
                    if (Chicken_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_chicken)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_chicken;
                            cnt_chicken -= Int32.Parse(amount_lbl.Text);
                            lbl_1.Text = cnt_chicken.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_chicken * sell_chicken;
                            cnt_chicken = 0;
                            lbl_1.Text = cnt_chicken.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                    else if (goose_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_goose)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_goose;
                            cnt_goose -= Int32.Parse(amount_lbl.Text);
                            label30.Text = cnt_goose.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_goose * sell_goose;
                            cnt_goose = 0;
                            label30.Text = cnt_goose.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                    else if (pig_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_pig)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_pig;
                            cnt_pig -= Int32.Parse(amount_lbl.Text);
                            label32.Text = cnt_pig.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_pig * sell_pig;
                            cnt_pig = 0;
                            label32.Text = cnt_pig.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                    else if (sheep_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_sheep)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_sheep;
                            cnt_sheep -= Int32.Parse(amount_lbl.Text);
                            label33.Text = cnt_sheep.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_sheep * sell_sheep;
                            cnt_sheep = 0;
                            label33.Text = cnt_sheep.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                    else if (Duck_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_duck)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_duck;
                            cnt_duck -= Int32.Parse(amount_lbl.Text);
                            label29.Text = cnt_duck.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_duck * sell_duck;
                            cnt_duck = 0;
                            label29.Text = cnt_duck.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                    else if (cow_radio.Checked == true)
                    {
                        if (Int32.Parse(amount_lbl.Text) <= cnt_cow)
                        {
                            myCredit += Int32.Parse(amount_lbl.Text) * sell_cow;
                            cnt_cow -= Int32.Parse(amount_lbl.Text);
                            label31.Text = cnt_cow.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                        else
                        {
                            myCredit += cnt_cow * sell_cow;
                            cnt_cow = 0;
                            label31.Text = cnt_cow.ToString();

                            if (myCredit.get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myCredit.creditUpdate();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void buy_btn_Click(object sender, EventArgs e)
        {
            int price = 0;
            try
            {
                price = Int32.Parse(label18.Text);
                if (price > 0)
                {
                    if (Chicken_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_chicken += Int32.Parse(amount_lbl.Text);
                        lbl_1.Text = cnt_chicken.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                    else if (goose_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_goose += Int32.Parse(amount_lbl.Text);
                        label30.Text = cnt_goose.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                    else if (pig_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_pig += Int32.Parse(amount_lbl.Text);
                        label32.Text = cnt_pig.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                    else if (sheep_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_sheep += Int32.Parse(amount_lbl.Text);
                        label33.Text = cnt_sheep.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                    else if (Duck_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_duck += Int32.Parse(amount_lbl.Text);
                        label29.Text = cnt_duck.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                    else if (cow_radio.Checked == true)
                    {
                        myCredit -= price;
                        cnt_cow += Int32.Parse(amount_lbl.Text);
                        label31.Text = cnt_cow.ToString();

                        if (myCredit.get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myCredit.creditUpdate();
                    }
                }
            }
            catch
            {

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
                if (y > 99)
                    y = 99;
                if (y < 0)
                    y = 0;
                amount_lbl.Text = y.ToString();
            }
            catch
            {
                amount_lbl.Text = y.ToString();
            }
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

        //Radios
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
        
        //Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            myCredit.applyInterest();
            label11.Text = myCredit.creditUpdate();

            myTime.tick(label9, label10);
        }
        private void timer_song_Tick(object sender, EventArgs e)
        {
            if (counter == 29)
            {
                audio.Stop();
                audio.Play();
                counter = 0;
            }
            counter++;
        }
    }
}
