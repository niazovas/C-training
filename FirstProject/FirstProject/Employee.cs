using System;
using System.Windows.Forms;

namespace FirstProject
{
    public class Employee
    {

        static int count = 0;
        object order = null;

        public object NewRequest(int quantity, string menuItem)
        {
            count++;

            if (count % 3 == 0)
            {
                if (menuItem == "egg")
                {
                    order = new Chicken(quantity);
                    MessageBox.Show($"{quantity} Chicken is ordered");
                }
                else
                {
                    order = new Egg(quantity);
                    MessageBox.Show($"{quantity} Egg is ordered");
                }
            }
            else
            {
                if (menuItem == "chicken")
                {
                    order = new Chicken(quantity);
                    MessageBox.Show($"{quantity} Chicken is ordered");
                }
                else
                {
                    order = new Egg(quantity);
                    MessageBox.Show($"{quantity} Egg is ordered");
                }
            }
            return order;
        }

        public object CopyOrder()
        {
            if (order == null)
                throw new Exception("Get the order!");
            else
            {
                switch (order)
                {
                    case Egg _:
                        return (Egg)order;
                    default:
                        return (Chicken)order;
                }
            }
        }

        public string Inspect(object order)
        {
            if (order is Egg)
                return ((Egg)order).GetQuality().ToString();
            else
                return "No inspection is required";
        }

        public string PrepareFood(object order)
        {
            if (order is Chicken)
            {
                for (int i = 0; i < ((Chicken)order).GetQuantity(); i++)
                {
                    ((Chicken)order).CutUp();
                }
                 ((Chicken)order).Cook();
                return "Chicken is ready";
            }
            else
            {
                try
                {
                    for (int i = 0; i < ((Egg)order).GetQuantity(); i++)
                    {
                        ((Egg)order).Crack();
                        ((Egg)order).DiscardShell();
                    }
                }
                catch (Exception ex)
                {
                    return (ex.Message);
                }
                finally
                {
                    ((Egg)order).Cook();
                }
                return "Egg is ready";
            }

        }
    }
}

