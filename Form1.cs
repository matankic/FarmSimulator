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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HelloWorldWinForms
{
    internal partial class Form1 : Form
    { 
        //Fields
        private int counter;
        private Farm myFarm = new Farm();
        private SoundPlayer audio, buy_sell;
        private int moveTickCount;
        //Methods
        public Form1()
        {
            
            InitializeComponent();
            timer1.Start();
            moveAnimal.Start();
            moveTickCount = 0; 
            counter = 0;
            audio = new SoundPlayer(Properties.Resources.song);
            buy_sell = new SoundPlayer(Properties.Resources.ChaChing);
            audio.Play();

            label11.Text = myFarm.GetCreditRef().creditUpdate();

            save_btn.Parent = pictureBox1;
            load_btn.Parent = pictureBox1;
            label10.Parent = pictureBox1;
            label9.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            label7.Parent = pictureBox1;
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
                        if (myFarm._cnt_chicken > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_chicken)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Chicken._sell_chicken;
                            myFarm._cnt_chicken -= Int32.Parse(amount_lbl.Text);
                            lbl_1.Text =myFarm._cnt_chicken.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_chicken * Chicken._sell_chicken;
                            myFarm._cnt_chicken = 0;
                            lbl_1.Text =myFarm._cnt_chicken.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                    }
                    else if (goose_radio.Checked == true)
                    {
                        if (myFarm._cnt_goose > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_goose)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Goose._sell_goose;
                            myFarm._cnt_goose -= Int32.Parse(amount_lbl.Text);
                            label30.Text =myFarm._cnt_goose.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_goose * Goose._sell_goose;
                            myFarm._cnt_goose = 0;
                            label30.Text =myFarm._cnt_goose.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                    }
                    else if (pig_radio.Checked == true)
                    {
                        if (myFarm._cnt_pig > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_pig)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Pig._sell_pig;
                            myFarm._cnt_pig -= Int32.Parse(amount_lbl.Text);
                            label32.Text =myFarm._cnt_pig.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_pig * Pig._sell_pig;
                            myFarm._cnt_pig = 0;
                            label32.Text =myFarm._cnt_pig.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                    }
                    else if (sheep_radio.Checked == true)
                    {
                        if (myFarm._cnt_sheep > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_sheep)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Sheep._sell_sheep;
                            myFarm._cnt_sheep -= Int32.Parse(amount_lbl.Text);
                            label33.Text =myFarm._cnt_sheep.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_sheep * Sheep._sell_sheep;
                            myFarm._cnt_sheep = 0;
                            label33.Text =myFarm._cnt_sheep.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                    }
                    else if (Duck_radio.Checked == true)
                    {
                        if (myFarm._cnt_duck > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_duck)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Duck._sell_duck;
                            myFarm._cnt_duck -= Int32.Parse(amount_lbl.Text);
                            label29.Text =myFarm._cnt_duck.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_duck * Duck._sell_duck;
                            myFarm._cnt_duck = 0;
                            label29.Text =myFarm._cnt_duck.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                    }
                    else if (cow_radio.Checked == true)
                    {
                        if (myFarm._cnt_cow > 0)
                            buy_sell.Play();
                        if (Int32.Parse(amount_lbl.Text) <=myFarm._cnt_cow)
                        {
                            myFarm.GetCreditRef() += Int32.Parse(amount_lbl.Text) * Cow._sell_cow;
                            myFarm._cnt_cow -= Int32.Parse(amount_lbl.Text);
                            label31.Text =myFarm._cnt_cow.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
                        }
                        else
                        {
                            myFarm.GetCreditRef() +=myFarm._cnt_cow * Cow._sell_cow;
                            myFarm._cnt_cow = 0;
                            label31.Text =myFarm._cnt_cow.ToString();

                            if (myFarm.GetCreditRef().get_credit() > 0)
                            {
                                label11.ForeColor = Color.ForestGreen;
                                label12.ForeColor = Color.ForestGreen;
                            }
                            label11.Text = myFarm.GetCreditRef().creditUpdate();
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
                if (price > 0 && myFarm.GetCreditRef().get_credit() - price >= -200)
                {
                    buy_sell.Play();
                    if (Chicken_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_chicken += Int32.Parse(amount_lbl.Text);
                        lbl_1.Text =myFarm._cnt_chicken.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 0, this);

                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                    }
                    else if (goose_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_goose += Int32.Parse(amount_lbl.Text);
                        label30.Text =myFarm._cnt_goose.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 2, this);

                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                    }
                    else if (pig_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_pig += Int32.Parse(amount_lbl.Text);
                        label32.Text =myFarm._cnt_pig.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 4, this);

                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                    }
                    else if (sheep_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_sheep += Int32.Parse(amount_lbl.Text);
                        label33.Text =myFarm._cnt_sheep.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 5, this);


                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                    }
                    else if (Duck_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_duck += Int32.Parse(amount_lbl.Text);
                        label29.Text =myFarm._cnt_duck.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 1, this);


                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                    }
                    else if (cow_radio.Checked == true)
                    {
                        myFarm.GetCreditRef() -= price;
                        myFarm._cnt_cow += Int32.Parse(amount_lbl.Text);
                        label31.Text =myFarm._cnt_cow.ToString();
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 3, this);


                        if (myFarm.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
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
                price = Chicken._buy_chicken;
            }
            else if (goose_radio.Checked == true)
            {
                price = Goose._buy_goose;
            }
            else if (pig_radio.Checked == true)
            {
                price = Pig._buy_pig;
            }
            else if (sheep_radio.Checked == true)
            {
                price = Sheep._buy_sheep;
            }
            else if (Duck_radio.Checked == true)
            {
                price = Duck._buy_duck;
            }
            else if (cow_radio.Checked == true)
            {
                price = Cow._buy_cow;
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
                price = Chicken._buy_chicken;
            }
            else if (goose_radio.Checked == true)
            {
                price = Goose._buy_goose;
            }
            else if (pig_radio.Checked == true)
            {
                price = Pig._buy_pig;
            }
            else if (sheep_radio.Checked == true)
            {
                price = Sheep._buy_sheep;
            }
            else if (Duck_radio.Checked == true)
            {
                price = Duck._buy_duck;
            }
            else if (cow_radio.Checked == true)
            {
                price = Cow._buy_cow;
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
                x = Int32.Parse(amount_lbl.Text) * Duck._buy_duck;
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
                x = Int32.Parse(amount_lbl.Text) * Goose._buy_goose;
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
                x = Int32.Parse(amount_lbl.Text) * Chicken._buy_chicken;
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
                x = Int32.Parse(amount_lbl.Text) * Sheep._buy_sheep;
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
                x = Int32.Parse(amount_lbl.Text) * Pig._buy_pig;
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
                x = Int32.Parse(amount_lbl.Text) * Cow._buy_cow;
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
            myFarm.GetCreditRef().applyInterest();
            label11.Text = myFarm.GetCreditRef().creditUpdate();

            myFarm.GetTimeRef().tick(label9, label10);
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
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //myGoose.makeNoise();
        }

        private void search_icon_Click(object sender, EventArgs e)
        {
            searchBox.Text = "!!!!!!!!!!!!!it's working!!";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "farm files (*.frm)|*.frm|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, myFarm);
                }
            }
        }

        private void moveAnimal_Tick(object sender, EventArgs e)
        {
            moveTickCount++;
            int i;
            for (i = 0; i < myFarm._farmSize; i++)
            {
                if (moveTickCount == 20)
                {
                    moveTickCount = 0;
                    myFarm.myAnimals[i].updateLocation(true);
                }
                else
                    myFarm.myAnimals[i].updateLocation(false);
                myFarm.myAnimals[i].visual.Location = new Point((int)myFarm.myAnimals[i].getX(), (int)myFarm.myAnimals[i].getY());
            }
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "farm files (*.frm)|*.frm|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                myFarm = (Farm)binaryFormatter.Deserialize(stream);
                //pictureBox1.Invalidate();
                if (myFarm.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                if (myFarm.GetCreditRef().get_credit() > 0)
                {
                    label11.ForeColor = Color.ForestGreen;
                    label12.ForeColor = Color.ForestGreen;
                }
                label11.Text = myFarm.GetCreditRef().creditUpdate();
                label10.Text = myFarm.GetTimeRef().daysUpdate();
                label9.Text = myFarm.GetTimeRef().hoursUpdate();
                lbl_1.Text = myFarm._cnt_chicken.ToString();
                label29.Text = myFarm._cnt_duck.ToString();
                label30.Text = myFarm._cnt_goose.ToString();
                label31.Text = myFarm._cnt_cow.ToString();
                label32.Text = myFarm._cnt_pig.ToString();
                label33.Text = myFarm._cnt_sheep.ToString();
            }
        }
    }
}
