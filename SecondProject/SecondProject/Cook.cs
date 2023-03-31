using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public  class Cook
    {
        public Order Submit(MenuItems menu, int quantity)
        {
            Order order;
           if(menu is MenuItems.Egg)

                order=new Egg(quantity);

           else 
                order=new Chicken(quantity);

            return order;
        }
        public void PrepareFood(Order order)
        {
            for (int i = 0; i < order.GetQuantity(); i++)
            {
                order.Prepare();
            }
           
        }

    }
}
