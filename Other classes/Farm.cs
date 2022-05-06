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
        private Credit myCredit;
        private Time myTime;
       // protected Animal[] animals;
       public Farm()
        {
            myCredit = new Credit();
            myTime = new Time();

        }
        public ref Credit GetCreditRef()
        {
            return ref this.myCredit;
        }
        public ref Time GetTimeRef()
        {
            return ref this.myTime;
        }
    }
}
