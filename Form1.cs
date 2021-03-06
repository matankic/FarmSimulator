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
        private int counter, moveTickCount, curIndex, prevIndex;
        private Farm myFarm = new Farm();
        private SoundPlayer audio = new SoundPlayer(Properties.Resources.song)
            , buy_sell = new SoundPlayer(Properties.Resources.ChaChing)
            , noise = new SoundPlayer(Properties.Resources.woosh);
        public List<PictureBox> visualAnimals = new List<PictureBox>();
        
        //Methods
        public Form1()
        {
           
            InitializeComponent();
            prevIndex = curIndex = -1;
            moveTickCount = counter = 0;
            timer1.Start();
            moveAnimal.Start();
            audio.Play();
            label11.Text = myFarm.GetCreditRef().creditUpdate();

            this.save_btn.Parent = pictureBox1;
            this.load_btn.Parent = pictureBox1;
            this.label10.Parent = pictureBox1;
            this.label9.Parent = pictureBox1;
            this.label8.Parent = pictureBox1;
            this.label7.Parent = pictureBox1;
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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 0);

                        displayAnimals(begin, myFarm._farmSize);

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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 2);

                        displayAnimals(begin, myFarm._farmSize);

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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 4);

                        displayAnimals(begin, myFarm._farmSize);

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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 5);

                        displayAnimals(begin, myFarm._farmSize);

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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 1);

                        displayAnimals(begin, myFarm._farmSize);

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
                        int begin = myFarm._farmSize;
                        myFarm.AddAnimalToList(Int32.Parse(amount_lbl.Text), 3);

                        displayAnimals(begin, myFarm._farmSize);

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
            for (int i = 0; i < myFarm._farmSize; i++)
            {
                if (myFarm.myAnimals[i]._isAlive == false)
                {
                    switch (myFarm.myAnimals[i]._spieces)
                    {
                        case 0:
                            myFarm._cnt_chicken--;
                            lbl_1.Text = myFarm._cnt_chicken.ToString();
                            break;
                        case 1:
                            myFarm._cnt_duck--;
                            label29.Text = myFarm._cnt_duck.ToString();
                            break;
                        case 2:
                            myFarm._cnt_goose--;
                            label30.Text = myFarm._cnt_goose.ToString();
                            break;
                        case 3:
                            myFarm._cnt_cow--;
                            label31.Text = myFarm._cnt_cow.ToString();
                            break;
                        case 4:
                            myFarm._cnt_pig--;
                            label32.Text = myFarm._cnt_pig.ToString();
                            break;
                        case 5:
                            myFarm._cnt_sheep--;
                            label33.Text = myFarm._cnt_sheep.ToString();
                            break;
                        default:
                            break;
                    }
                    noise.Play();
                    this.Controls.Remove(visualAnimals[i]);
                    visualAnimals[i].Dispose();
                    myFarm.myAnimals.Remove(myFarm.myAnimals[i]);
                    visualAnimals.Remove(visualAnimals[i]);
                    prevIndex = -1;
                    clearStats();
                    myFarm._farmSize--;
                    continue;
                }
                myFarm.myAnimals[i]._age += 1;
                myFarm.myAnimals[i].updateStats();
            }
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
        
        private void search_icon_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = Int32.Parse(searchBox.Text);
                if (id >= 0 && id < myFarm._farmSize)
                {
                    myFarm.myAnimals[id].displayAnimalStats(name_lbl, id_lbl, spieces_lbl, HungryBar,
                        ThirstBar, HpBar, sex_lbl, age_lbl, x_lbl, y_lbl);
                    prevIndex = id;
                }
                else
                {
                    searchBox.Text = "Entered ID doesnot exist";
                }
            }
            catch
            {
                searchBox.Text = "Not an ID..";
            }
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
            if (prevIndex >= 0)
                myFarm.myAnimals[prevIndex].displayAnimalStats(name_lbl, id_lbl, spieces_lbl,
                    HungryBar, ThirstBar, HpBar, sex_lbl, age_lbl, x_lbl, y_lbl);
            int i;
            if (moveTickCount == 20)
            {
                moveTickCount = 0;
                for (i = 0; i < myFarm._farmSize; i++)
                {
                    myFarm.myAnimals[i].updateLocation(true);
                    visualAnimals[i].Location = new Point((int)myFarm.myAnimals[i].getX(), (int)myFarm.myAnimals[i].getY());
                }
            }
            else
            {
                for (i = 0; i < myFarm._farmSize; i++)
                {
                    myFarm.myAnimals[i].updateLocation(false);
                    visualAnimals[i].Location = new Point((int)myFarm.myAnimals[i].getX(), (int)myFarm.myAnimals[i].getY());
                }
            }

        }

        private void displayAnimals(int begin, int end)
        {
            for (int i = begin; i < end; i++)
            {
                visualAnimals.Add(new PictureBox());
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).BeginInit();
                myFarm.myAnimals[i].displayAnimal(visualAnimals[i]);
                visualAnimals[i].Name = "visual"+i.ToString();
                visualAnimals[i].MouseDown += new MouseEventHandler(this.visual_MouseDown);
                visualAnimals[i].MouseMove += new MouseEventHandler(this.visual_MouseMove);
                visualAnimals[i].MouseUp += new MouseEventHandler(this.visual_MouseUp);
                this.Controls.Add(visualAnimals[i]);
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).EndInit();
                visualAnimals[i].Parent = this.pictureBox1;
            }
        }

        private void visual_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox visual = new PictureBox();
            visual = (PictureBox)sender;
            curIndex = -1;
            for (int i = 0; i < myFarm._farmSize; i++)
            {
                if (myFarm.myAnimals[i].isInside(visual.Location.X + e.X, visual.Location.Y + e.Y))
                {
                    string s = e.Button.ToString();
                    if (s == "Left")
                    {
                        myFarm.myAnimals[i].displayAnimalStats(name_lbl, id_lbl, spieces_lbl, HungryBar, ThirstBar, HpBar, sex_lbl, age_lbl, x_lbl, y_lbl);
                        prevIndex = curIndex = i;
                        myFarm.myAnimals[i].setSpeed(0);
                        myFarm.myAnimals[i].makeNoise();
                        break;
                    }
                }
            }
        }

        private void visual_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox visual = new PictureBox();
            visual = (PictureBox)sender;
            if (curIndex >= 0)
            {
                myFarm.myAnimals[curIndex].SetX(visual.Location.X + e.X - 30);
                myFarm.myAnimals[curIndex].SetY(visual.Location.Y + e.Y - 30);
            }
        }

        private void visual_MouseUp(object sender, MouseEventArgs e)
        {
            if (curIndex >= 0)
                myFarm.myAnimals[curIndex].gainSpeed();
            curIndex = -1;
        }

        private void heal_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myFarm.GetCreditRef() -= 10;
                if (myFarm.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myFarm.GetCreditRef().creditUpdate();
                myFarm.myAnimals[prevIndex].healAnimal();
            }
        }

        private void feed_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myFarm.GetCreditRef() -= 10;
                if (myFarm.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myFarm.GetCreditRef().creditUpdate();
                myFarm.myAnimals[prevIndex].feedAnimal();
            }
        }

        private void water_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myFarm.GetCreditRef() -= 5;
                if (myFarm.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myFarm.GetCreditRef().creditUpdate();
                myFarm.myAnimals[prevIndex].waterAnimal();
            }
        }

        private void meat_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                switch (myFarm.myAnimals[prevIndex].getSpieces())
                { 
                    case 0: 
                        myFarm._cnt_chicken--; lbl_1.Text = myFarm._cnt_chicken.ToString();
                        myFarm.GetCreditRef() += Chicken._sell_chicken * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    case 1: 
                        myFarm._cnt_duck--; label29.Text = myFarm._cnt_duck.ToString();
                        myFarm.GetCreditRef() += Duck._sell_duck * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    case 2:
                        myFarm._cnt_goose--; label30.Text = myFarm._cnt_goose.ToString();
                        myFarm.GetCreditRef() += Goose._sell_goose * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    case 3: 
                        myFarm._cnt_cow--; label31.Text = myFarm._cnt_cow.ToString();
                        myFarm.GetCreditRef() += Cow._sell_cow * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    case 4: 
                        myFarm._cnt_pig--; label32.Text = myFarm._cnt_pig.ToString();
                        myFarm.GetCreditRef() += Pig._sell_pig * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    case 5: 
                        myFarm._cnt_sheep--; label33.Text = myFarm._cnt_sheep.ToString();
                        myFarm.GetCreditRef() += Sheep._sell_sheep * myFarm.myAnimals[prevIndex]._age.get_days();
                        if (myFarm.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myFarm.GetCreditRef().creditUpdate();
                        break;
                    default: break;
                }
                this.Controls.Remove(visualAnimals[prevIndex]);
                visualAnimals[prevIndex].Dispose();
                myFarm.myAnimals.Remove(myFarm.myAnimals[prevIndex]);
                visualAnimals.Remove(visualAnimals[prevIndex]);
                prevIndex = -1;
                myFarm._farmSize--;
                clearStats();
            }
        }

        private void milk_btn_Click(object sender, EventArgs e)
        {   
            if (prevIndex >= 0)
            {
                if (myFarm.myAnimals[prevIndex].doesLactate())
                {
                    buy_sell.Play();
                    myFarm.GetCreditRef() += 40;
                    if (myFarm.GetCreditRef().get_credit() > 0)
                    {
                        label11.ForeColor = Color.ForestGreen;
                        label12.ForeColor = Color.ForestGreen;
                    }
                    label11.Text = myFarm.GetCreditRef().creditUpdate();
                    Mammal m = (Mammal)myFarm.myAnimals[prevIndex];
                    m.updateLactate(false);
                } 
                else
                    noise.Play();
            }
        }

        private void egg_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                if (myFarm.myAnimals[prevIndex].doesEgg() > 0)
                {
                    buy_sell.Play();
                    myFarm.GetCreditRef() += 10 * myFarm.myAnimals[prevIndex].doesEgg();
                    if (myFarm.GetCreditRef().get_credit() > 0)
                    {
                        label11.ForeColor = Color.ForestGreen;
                        label12.ForeColor = Color.ForestGreen;
                    }
                    label11.Text = myFarm.GetCreditRef().creditUpdate();
                    Bird b = (Bird)myFarm.myAnimals[prevIndex];
                    b.takeEggs();
                }
                else
                    noise.Play();
            }
        }

        private void displayAnimals() // For load button only!
        {
            int i;
            for (i = 0; i < myFarm._farmSize; i++)
            {
                visualAnimals.Add(new PictureBox());
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).BeginInit();
                myFarm.myAnimals[i].displayAnimal(visualAnimals[i]);
                visualAnimals[i].Name = "visual" + i;
                this.Controls.Add(visualAnimals[i]);
                visualAnimals[i].MouseDown += new MouseEventHandler(this.visual_MouseDown);
                visualAnimals[i].MouseMove += new MouseEventHandler(this.visual_MouseMove);
                visualAnimals[i].MouseUp += new MouseEventHandler(this.visual_MouseUp);
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).EndInit();
                visualAnimals[i].Parent = this.pictureBox1;
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
                if (myFarm.GetCreditRef().get_credit() < 0) // COLOR CREDIT 
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
                displayAnimals();
            }
        }
        private void clearStats()
        {
            name_lbl.Text = "-----";
            id_lbl.Text = "-------";
            spieces_lbl.Text = "----";
            HungryBar.Value = 0;
            ThirstBar.Value = 0;
            HpBar.Value = 0;
            sex_lbl.Text = "------";
            age_lbl.Text = "------";
            x_lbl.Text = "----";
            y_lbl.Text ="----";
        }
    }

}
