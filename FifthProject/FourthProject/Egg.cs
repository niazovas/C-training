using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthProject
{
    sealed class Egg : CookedFood, IDisposable
    {
        public override void Cook() { }

        public override void Obtain() { }

        public override void Prepare()
        {
            Obtain();
            Crack();
            Cook();
        }
        public override void Serve() { }
        public void DiscardShell() { }

        public void Crack() { }

        public void Dispose()
        { DiscardShell(); }

      
        public int GetQuality()
        {
           Random random = new Random();
            return random.Next(30, 100);
        }
    }
}
