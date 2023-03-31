using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject
{
    sealed  class Egg : CookedFood, IDisposable
    {
        Random random = new Random();
        public override void Cook()
        {
        }
        public override void Obtain()
        {
        }
        public override void Serve()
        {
        }
        public void Crack()
        {
        }
        public void DiscardShell()
        {
        }
        public void Dispose()
        {
            DiscardShell();
        }
        public override void Prepare()
        {
            Obtain();
            Crack();
            Cook();
        }
        public int GetQuality()
        {
          Random rand = new Random();
           int quality= rand.Next(20,100);
            return quality;
            
        }
    }
}
