using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HelloWorldWinForms
{
    [Serializable]
    internal class aquarium 
    {
        public List<Animal> myAnimals;
        private Credit myCredit;
        private Time myTime;
        public int _aquariumSize;          
        public int _cnt_puff {get; set;}
        public int _cnt_seahorse {get; set;}
        public int _cnt_dolphin {get; set;}
        public int _cnt_turtle {get; set;}
        public int _cnt_shark {get; set;}
        public int _cnt_jellyfish {get; set;}

        // protected Animal[] animals;
        public aquarium()
        {
            myCredit = new Credit();
            myTime = new Time();
            myAnimals = new List<Animal>();
            _aquariumSize = _cnt_puff = _cnt_seahorse = _cnt_dolphin = _cnt_turtle = _cnt_shark = _cnt_jellyfish = 0;
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
            for (i = 0; i < amount; i++, _aquariumSize++)
            {
                switch (type)
                {
                    case 0:
                        myAnimals.Add(new puff(_aquariumSize));
                        break;
                    case 1:
                        myAnimals.Add(new turtle(_aquariumSize));
                        break;
                    case 2:
                        myAnimals.Add(new seahorse(_aquariumSize));
                        break;
                    case 3:
                        myAnimals.Add(new dolphin(_aquariumSize));
                        break;
                    case 4:
                        myAnimals.Add(new shark(_aquariumSize));
                        break;
                    case 5:
                        myAnimals.Add(new jellyfish(_aquariumSize));
                        break;
                    default:
                        break;
                }
            }
        } 
    }
}
