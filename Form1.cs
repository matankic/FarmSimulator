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
        private aquarium myAquarium = new aquarium();
        private SoundPlayer buy_sell = new SoundPlayer(Properties.Resources.ChaChing)
            , noise = new SoundPlayer(Properties.Resources.woosh),
            audio = new SoundPlayer(Properties.Resources.Caribbean);
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
            label11.Text = myAquarium.GetCreditRef().creditUpdate();

            this.save_btn.Parent = pictureBox1;
            this.load_btn.Parent = pictureBox1;
            this.label10.Parent = pictureBox1;
            this.label9.Parent = pictureBox1;
            this.label8.Parent = pictureBox1;
            this.label7.Parent = pictureBox1;
            this.heal_btn.Parent = pictureBox1;
            this.feed_btn.Parent = pictureBox1;
            this.water_btn.Parent = pictureBox1;
            this.meat_btn.Parent = pictureBox1;
            this.milk_btn.Parent = pictureBox1;
            this.egg_btn.Parent = pictureBox1;
        }

        private void buy_btn_Click(object sender, EventArgs e)
        {
            int price = 0;
            try
            {
                price = Int32.Parse(label18.Text);
                if (price > 0 && myAquarium.GetCreditRef().get_credit() - price >= -200)
                {
                    buy_sell.Play();
                    if (puff_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_puff += Int32.Parse(amount_lbl.Text);
                        lbl_1.Text =myAquarium._cnt_puff.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 0);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    }
                    else if (seahorse_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_seahorse += Int32.Parse(amount_lbl.Text);
                        label30.Text =myAquarium._cnt_seahorse.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 2);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    }
                    else if (shark_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_shark += Int32.Parse(amount_lbl.Text);
                        label32.Text =myAquarium._cnt_shark.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 4);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    }
                    else if (jellyfish_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_jellyfish += Int32.Parse(amount_lbl.Text);
                        label33.Text =myAquarium._cnt_jellyfish.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 5);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    }
                    else if (turtle_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_turtle += Int32.Parse(amount_lbl.Text);
                        label29.Text =myAquarium._cnt_turtle.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 1);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    }
                    else if (dolphin_radio.Checked == true)
                    {
                        myAquarium.GetCreditRef() -= price;
                        myAquarium._cnt_dolphin += Int32.Parse(amount_lbl.Text);
                        label31.Text =myAquarium._cnt_dolphin.ToString();
                        int begin = myAquarium._aquariumSize;
                        myAquarium.AddAnimalToList(Int32.Parse(amount_lbl.Text), 3);

                        displayAnimals(begin, myAquarium._aquariumSize);

                        if (myAquarium.GetCreditRef().get_credit() < 0)
                        {
                            label11.ForeColor = Color.Red;
                            label12.ForeColor = Color.Red;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
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
            if (puff_radio.Checked == true)
            {
                price = puff._buy_puff;
            }
            else if (seahorse_radio.Checked == true)
            {
                price = seahorse._buy_seahorse;
            }
            else if (shark_radio.Checked == true)
            {
                price = shark._buy_shark;
            }
            else if (jellyfish_radio.Checked == true)
            {
                price = jellyfish._buy_jellyfish;
            }
            else if (turtle_radio.Checked == true)
            {
                price = turtle._buy_turtle;
            }
            else if (dolphin_radio.Checked == true)
            {
                price = dolphin._buy_dolphin;
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
            if (puff_radio.Checked == true)
            {
                price = puff._buy_puff;
            }
            else if (seahorse_radio.Checked == true)
            {
                price = seahorse._buy_seahorse;
            }
            else if (shark_radio.Checked == true)
            {
                price = shark._buy_shark;
            }
            else if (jellyfish_radio.Checked == true)
            {
                price = jellyfish._buy_jellyfish;
            }
            else if (turtle_radio.Checked == true)
            {
                price = turtle._buy_turtle;
            }
            else if (dolphin_radio.Checked == true)
            {
                price = dolphin._buy_dolphin;
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
        private void turtle_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.turtle;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * turtle._buy_turtle;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void seahorse_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.seahorse;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * seahorse._buy_seahorse;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void puff_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.puff;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * puff._buy_puff;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void jellyfish_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.jellyfish;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * jellyfish._buy_jellyfish;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void shark_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.shark;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * shark._buy_shark;
                label18.Text = x.ToString();
            }
            catch
            {
                label18.Text = x.ToString();
            }
        }
        private void dolphin_radio_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = HelloWorldWinForms.Properties.Resources.dolphin;
            int x = 0;
            try
            {
                x = Int32.Parse(amount_lbl.Text) * dolphin._buy_dolphin;
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
            myAquarium.GetCreditRef().applyInterest();
            label11.Text = myAquarium.GetCreditRef().creditUpdate();

            myAquarium.GetTimeRef().tick(label9, label10);
            for (int i = 0; i < myAquarium._aquariumSize; i++)
            {
                if (myAquarium.myAnimals[i]._isAlive == false)
                {
                    switch (myAquarium.myAnimals[i]._spieces)
                    {
                        case 0:
                            myAquarium._cnt_puff--;
                            lbl_1.Text = myAquarium._cnt_puff.ToString();
                            break;
                        case 1:
                            myAquarium._cnt_turtle--;
                            label29.Text = myAquarium._cnt_turtle.ToString();
                            break;
                        case 2:
                            myAquarium._cnt_seahorse--;
                            label30.Text = myAquarium._cnt_seahorse.ToString();
                            break;
                        case 3:
                            myAquarium._cnt_dolphin--;
                            label31.Text = myAquarium._cnt_dolphin.ToString();
                            break;
                        case 4:
                            myAquarium._cnt_shark--;
                            label32.Text = myAquarium._cnt_shark.ToString();
                            break;
                        case 5:
                            myAquarium._cnt_jellyfish--;
                            label33.Text = myAquarium._cnt_jellyfish.ToString();
                            break;
                        default:
                            break;
                    }
                    noise.Play();
                    this.Controls.Remove(visualAnimals[i]);
                    visualAnimals[i].Dispose();
                    myAquarium.myAnimals.Remove(myAquarium.myAnimals[i]);
                    visualAnimals.Remove(visualAnimals[i]);
                    prevIndex = -1;
                    clearStats();
                    myAquarium._aquariumSize--;
                    continue;
                }
                myAquarium.myAnimals[i]._age += 1;
                myAquarium.myAnimals[i].updateStats();
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
                if (id >= 0 && id < myAquarium._aquariumSize)
                {
                    myAquarium.myAnimals[id].displayAnimalStats(name_lbl, id_lbl, spieces_lbl, HungryBar,
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
            saveFileDialog1.Filter = "ocean file (*.ocn)|*.ocn|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, myAquarium);
                }
            }
        }

        private void moveAnimal_Tick(object sender, EventArgs e)
        {
            moveTickCount++;
            if (prevIndex >= 0)
                myAquarium.myAnimals[prevIndex].displayAnimalStats(name_lbl, id_lbl, spieces_lbl,
                    HungryBar, ThirstBar, HpBar, sex_lbl, age_lbl, x_lbl, y_lbl);
            int i;
            if (moveTickCount == 20)
            {
                moveTickCount = 0;
                for (i = 0; i < myAquarium._aquariumSize; i++)
                {
                    myAquarium.myAnimals[i].updateLocation(true);
                    visualAnimals[i].Location = new Point((int)myAquarium.myAnimals[i].getX(), (int)myAquarium.myAnimals[i].getY());
                }
            }
            else
            {
                for (i = 0; i < myAquarium._aquariumSize; i++)
                {
                    myAquarium.myAnimals[i].updateLocation(false);
                    visualAnimals[i].Location = new Point((int)myAquarium.myAnimals[i].getX(), (int)myAquarium.myAnimals[i].getY());
                }
            }

        }

        private void displayAnimals(int begin, int end)
        {
            for (int i = begin; i < end; i++)
            {
                visualAnimals.Add(new PictureBox());
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).BeginInit();
                myAquarium.myAnimals[i].displayAnimal(visualAnimals[i]);
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
            for (int i = 0; i < myAquarium._aquariumSize; i++)
            {
                if (myAquarium.myAnimals[i].isInside(visual.Location.X + e.X, visual.Location.Y + e.Y))
                {
                    string s = e.Button.ToString();
                    if (s == "Left")
                    {
                        myAquarium.myAnimals[i].displayAnimalStats(name_lbl, id_lbl, spieces_lbl, HungryBar, ThirstBar, HpBar, sex_lbl, age_lbl, x_lbl, y_lbl);
                        prevIndex = curIndex = i;
                        myAquarium.myAnimals[i].setSpeed(0);
                        myAquarium.myAnimals[i].makeNoise();
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
                myAquarium.myAnimals[curIndex].SetX(visual.Location.X + e.X - 30);
                myAquarium.myAnimals[curIndex].SetY(visual.Location.Y + e.Y - 30);
            }
        }

        private void visual_MouseUp(object sender, MouseEventArgs e)
        {
            if (curIndex >= 0)
                myAquarium.myAnimals[curIndex].gainSpeed();
            curIndex = -1;
        }

        private void heal_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myAquarium.GetCreditRef() -= 10;
                if (myAquarium.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myAquarium.GetCreditRef().creditUpdate();
                myAquarium.myAnimals[prevIndex].healAnimal();
            }
        }

        private void feed_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myAquarium.GetCreditRef() -= 10;
                if (myAquarium.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myAquarium.GetCreditRef().creditUpdate();
                myAquarium.myAnimals[prevIndex].feedAnimal();
            }
        }

        private void water_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                myAquarium.GetCreditRef() -= 5;
                if (myAquarium.GetCreditRef().get_credit() < 0)
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                label11.Text = myAquarium.GetCreditRef().creditUpdate();
                myAquarium.myAnimals[prevIndex].waterAnimal();
            }
        }

        private void meat_btn_Click(object sender, EventArgs e)
        {
            if (prevIndex >= 0)
            {
                buy_sell.Play();
                switch (myAquarium.myAnimals[prevIndex].getSpieces())
                { 
                    case 0: 
                        myAquarium._cnt_puff--; lbl_1.Text = myAquarium._cnt_puff.ToString();
                        myAquarium.GetCreditRef() += puff._sell_puff * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    case 1: 
                        myAquarium._cnt_turtle--; label29.Text = myAquarium._cnt_turtle.ToString();
                        myAquarium.GetCreditRef() += turtle._sell_turtle * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    case 2:
                        myAquarium._cnt_seahorse--; label30.Text = myAquarium._cnt_seahorse.ToString();
                        myAquarium.GetCreditRef() += seahorse._sell_seahorse * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    case 3: 
                        myAquarium._cnt_dolphin--; label31.Text = myAquarium._cnt_dolphin.ToString();
                        myAquarium.GetCreditRef() += dolphin._sell_dolphin * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    case 4: 
                        myAquarium._cnt_shark--; label32.Text = myAquarium._cnt_shark.ToString();
                        myAquarium.GetCreditRef() += shark._sell_shark * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    case 5: 
                        myAquarium._cnt_jellyfish--; label33.Text = myAquarium._cnt_jellyfish.ToString();
                        myAquarium.GetCreditRef() += jellyfish._sell_jellyfish * myAquarium.myAnimals[prevIndex]._age.get_days();
                        if (myAquarium.GetCreditRef().get_credit() > 0)
                        {
                            label11.ForeColor = Color.ForestGreen;
                            label12.ForeColor = Color.ForestGreen;
                        }
                        label11.Text = myAquarium.GetCreditRef().creditUpdate();
                        break;
                    default: break;
                }
                this.Controls.Remove(visualAnimals[prevIndex]);
                visualAnimals[prevIndex].Dispose();
                myAquarium.myAnimals.Remove(myAquarium.myAnimals[prevIndex]);
                visualAnimals.Remove(visualAnimals[prevIndex]);
                prevIndex = -1;
                myAquarium._aquariumSize--;
                clearStats();
            }
        }

        private void tools_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lbl_1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void amount_lbl_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void HungryBar_Click(object sender, EventArgs e)
        {

        }

        private void ThirstBar_Click(object sender, EventArgs e)
        {

        }

        private void HpBar_Click(object sender, EventArgs e)
        {

        }

        private void Animal_stats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void y_lbl_Click(object sender, EventArgs e)
        {

        }

        private void x_lbl_Click(object sender, EventArgs e)
        {

        }

        private void age_lbl_Click(object sender, EventArgs e)
        {

        }

        private void sex_lbl_Click(object sender, EventArgs e)
        {

        }

        private void id_lbl_Click(object sender, EventArgs e)
        {

        }

        private void spieces_lbl_Click(object sender, EventArgs e)
        {

        }

        private void name_lbl_Click(object sender, EventArgs e)
        {

        }

        private void searchBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void milk_btn_Click(object sender, EventArgs e)
        {   
            if (prevIndex >= 0)
            {
                if (myAquarium.myAnimals[prevIndex].doesLactate())
                {
                    buy_sell.Play();
                    myAquarium.GetCreditRef() += 40;
                    if (myAquarium.GetCreditRef().get_credit() > 0)
                    {
                        label11.ForeColor = Color.ForestGreen;
                        label12.ForeColor = Color.ForestGreen;
                    }
                    label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    Mammal m = (Mammal)myAquarium.myAnimals[prevIndex];
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
                if (myAquarium.myAnimals[prevIndex].doesEgg() > 0)
                {
                    buy_sell.Play();
                    myAquarium.GetCreditRef() += 10 * myAquarium.myAnimals[prevIndex].doesEgg();
                    if (myAquarium.GetCreditRef().get_credit() > 0)
                    {
                        label11.ForeColor = Color.ForestGreen;
                        label12.ForeColor = Color.ForestGreen;
                    }
                    label11.Text = myAquarium.GetCreditRef().creditUpdate();
                    fish b = (fish)myAquarium.myAnimals[prevIndex];
                    b.takeEggs();
                }
                else
                    noise.Play();
            }
        }

        private void displayAnimals() // For load button only!
        {
            int i;
            for (i = 0; i < myAquarium._aquariumSize; i++)
            {
                visualAnimals.Add(new PictureBox());
                ((System.ComponentModel.ISupportInitialize)(visualAnimals[i])).BeginInit();
                myAquarium.myAnimals[i].displayAnimal(visualAnimals[i]);
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
            openFileDialog1.Filter = "ocean file (*.ocn)|*.ocn|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                myAquarium = (aquarium)binaryFormatter.Deserialize(stream);
                if (myAquarium.GetCreditRef().get_credit() < 0) // COLOR CREDIT 
                {
                    label11.ForeColor = Color.Red;
                    label12.ForeColor = Color.Red;
                }
                if (myAquarium.GetCreditRef().get_credit() > 0)
                {
                    label11.ForeColor = Color.ForestGreen;
                    label12.ForeColor = Color.ForestGreen;
                }
                label11.Text = myAquarium.GetCreditRef().creditUpdate();
                label10.Text = myAquarium.GetTimeRef().daysUpdate();
                label9.Text = myAquarium.GetTimeRef().hoursUpdate();
                lbl_1.Text = myAquarium._cnt_puff.ToString();
                label29.Text = myAquarium._cnt_turtle.ToString();
                label30.Text = myAquarium._cnt_seahorse.ToString();
                label31.Text = myAquarium._cnt_dolphin.ToString();
                label32.Text = myAquarium._cnt_shark.ToString();
                label33.Text = myAquarium._cnt_jellyfish.ToString();
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
