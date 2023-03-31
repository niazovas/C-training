using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Order
    {
        private int quantity { get; set; }
        
        public Order(int quantity)
        {
            this.quantity = quantity;
        }
        public int GetQuantity()
        {
            return quantity;
        }

       
        public void Cook()
        {

        }
        public virtual void Prepare()
        {
            Cook();
        }
    }
}
