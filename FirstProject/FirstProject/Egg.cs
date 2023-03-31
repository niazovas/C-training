using System;

namespace FirstProject
{
    public class Egg
    {
        private int quantity;
        private static int count = 0;
        private Random rnd;
        int quality;
        

        public Egg(int quantity)
        {
            this.quantity = quantity;
        }

        public int GetQuantity()
        {
            return quantity;
        }
       
        public int? GetQuality()
        {
            count++;
            rnd = new Random();
          
            if (count % 2 == 0)
                return null;
            else
                quality = rnd.Next(1, 100);

            return quality;
        }

        public void Crack()
        {
            if (quality < 25)
            {
                throw new Exception("Rotten egg");
            }
        }

        public void DiscardShell()
        {

        }
        public void Cook()
        {

        }
     
    }
}




