﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Animal
    {
        protected SoundPlayer noise;
        private Random rand = new Random();
        public virtual string _name { get; set; }
        private Time _age;
        protected int _id, _spieces, 
            _thirst,
            _hunger,
            _health;
        protected Vector _coordinates, _direction;
        protected double _speed;
        private bool _sex, _isFertile;
       
        public Animal() {
            _speed = 3;
            createDirection();
        }
        public virtual void makeNoise() { }
        public virtual void displayAnimal(ref PictureBox visual) { }
        public void updateAnimal()
        {
            _age += 10; //TODO : adjust to the amount of world time

            _thirst -= 10;
            _hunger -= 10;
            _health -= 5;
        }
        public void feedAnimal()
        {
            _hunger += 200;
        }
        public void waterAnimal()
        {
            _thirst += 200;
        }
        public void healAnimal()
        {
            _health += 200;
        }
        public void displayAnimalStats(Label lbl1, Label lbl2, Label lbl3, Label lbl4, 
            Label lbl5, Label lbl6, Label lbl7, Label lbl8, Label lbl9)
        {
            lbl1.Text = _name;
            lbl2.Text = _id.ToString();
            lbl3.Text = _thirst.ToString();
            lbl4.Text = _hunger.ToString();
            lbl5.Text = _health.ToString();
            if (_sex)
                lbl6.Text = "Female";
            else
                lbl6.Text = "Male";
            lbl7.Text = _age.daysUpdate() + " days, " + _age.hoursUpdate() + " hours";
            lbl8.Text = _coordinates.X.ToString();
            lbl9.Text = _coordinates.Y.ToString();
        }
        public virtual void updateLocation(bool changeDirection) { }
        public virtual void createDirection() { }
        public double getX() { return _coordinates.X; }
        public double getY() { return _coordinates.Y; }

    }
}
