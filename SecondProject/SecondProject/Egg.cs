using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
  public class Egg:Order
    {
      
        Random random = new Random();
        public Egg(int quantity) : base(quantity)
        {

        }

        public  int GetQuality()
        {
            return random.Next(50, 100);
        }
        public void Crack()
        {

        }
        public void Discard()
        {

        }
        public override void Prepare()
        {
            Crack();
            Discard();
            base.Prepare();
        }
    }
}
