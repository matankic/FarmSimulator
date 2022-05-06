using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class Farm 
    {
        public List<Animal> myAnimals;
        private Credit myCredit;
        private Time myTime;
        public int _farmSize;          
        public int _cnt_chicken {get; set;}
        public int _cnt_goose {get; set;}
        public int _cnt_cow {get; set;}
        public int _cnt_duck {get; set;}
        public int _cnt_pig {get; set;}
        public int _cnt_sheep {get; set;}

        // protected Animal[] animals;
        public Farm()
        {
            myCredit = new Credit();
            myTime = new Time();
            myAnimals = new List<Animal>();
            _farmSize = _cnt_chicken = _cnt_goose = _cnt_cow = _cnt_duck = _cnt_pig = _cnt_sheep = 0;
        }
        public ref Credit GetCreditRef()
        {
            return ref this.myCredit;
        }
        public ref Time GetTimeRef()
        {
            return ref this.myTime;
        }
        public void AddAnimalToList(int amount, int type) 
        {
            _farmSize += amount;
            switch (type){
                case 0:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Chicken());
                        _cnt_chicken++;
                    }
                    break;
                case 1:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Duck());
                        _cnt_duck++;
                    }
                    break;
                case 3:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Goose());
                        _cnt_goose++;
                    }
                    break;
                case 4:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Cow());
                        _cnt_cow++;
                    }
                    break;
                case 5:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Pig());
                        _cnt_pig++;
                    }
                    break;
                case 6:
                    for (int i = 0; i < amount; i++)
                    {
                        myAnimals.Add(new Sheep ());
                        _cnt_sheep++;
                    }
                    break;
                default:
                    break;
            } 
        } 
    }
}
