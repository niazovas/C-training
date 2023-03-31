using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthProject
{
    internal class Chicken : CookedFood
    {
        public override void Cook() { }

        public override void Obtain() { }

        public override void Prepare()
        {
            Cut();
            Cook();
        }

        public override void Serve()
        {  }
        public void Cut() { }
    }
}
