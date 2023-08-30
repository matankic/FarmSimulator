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
        public int _cnt_puff {get; set;}
        public int _cnt_seahorse {get; set;}
        public int _cnt_dolphin {get; set;}
        public int _cnt_turtle {get; set;}
        public int _cnt_shark {get; set;}
        public int _cnt_jellyfish {get; set;}

        // protected Animal[] animals;
        public Farm()
        {
            myCredit = new Credit();
            myTime = new Time();
            myAnimals = new List<Animal>();
            _farmSize = _cnt_puff = _cnt_seahorse = _cnt_dolphin = _cnt_turtle = _cnt_shark = _cnt_jellyfish = 0;
        }
        public ref Credit GetCreditRef() 
        {
            return ref this.myCredit;
        }
        public ref Time GetTimeRef()
        {
            return ref this.myTime;
        }
        public void AddAnimalToList(int amount,int type) 
        {
            int i;
            for (i = 0; i < amount; i++, _farmSize++)
            {
                switch (type)
                {
                    case 0:
                        myAnimals.Add(new puff(_farmSize));
                        break;
                    case 1:
                        myAnimals.Add(new turtle(_farmSize));
                        break;
                    case 2:
                        myAnimals.Add(new seahorse(_farmSize));
                        break;
                    case 3:
                        myAnimals.Add(new dolphin(_farmSize));
                        break;
                    case 4:
                        myAnimals.Add(new shark(_farmSize));
                        break;
                    case 5:
                        myAnimals.Add(new jellyfish(_farmSize));
                        break;
                    default:
                        break;
                }
            }
        } 
    }
}
