using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
   public class Chicken:Order
    {
        public Chicken(int quantity):base(quantity)
        {

        }
        public void Cut()
        {

        }
        public override void Prepare()
        {
            Cook();
            base.Prepare();
        }
    }
}
