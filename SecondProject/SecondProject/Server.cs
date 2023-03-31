using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public enum MenuItems
    {
        Egg,
        Chicken,
        NoDrink,
        Water,
        Cola,
        Tea
    }
    public class Server
    {
        int count = 0;
        bool order = false;
        Order menuegg;
        Cook cook = new Cook();
        MenuItems[][] menuItems = new MenuItems[8][];
        public void Request(int quantityegg, int quantitychicken, string drinks)
        {
            if (order is true)
            {
                throw new Exception("Sent");
            }

            if (count < 8)
            {
                menuItems[count] = new MenuItems[quantityegg + quantitychicken + 1];
                for (int i = 0; i < quantityegg; i++)
                {
                    menuItems[count][i] = MenuItems.Egg;
                }
                for (int j = quantityegg; j < quantityegg + quantitychicken; j++)
                {
                    menuItems[count][j] = MenuItems.Chicken;
                }
                for (var drink = MenuItems.NoDrink; drink <= MenuItems.Tea; drink++)
                {
                    if (drink.ToString() == drinks)

                        menuItems[count][quantityegg + quantitychicken] = drink;
                }
                count++;

            }
            else

                throw new Exception("Order more than 8");
        }

        public void Send()
        {
            if (order is true)
            {
                throw new Exception("already sent");
            }

            int quantityegg = 0;
            int quantitychicken = 0;

            if (menuItems[0] is null)
                throw new Exception("First get the order");

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < menuItems[i].Length; j++)
                {
                    if (menuItems[i][j] == MenuItems.Egg)

                        quantityegg++;

                    if (menuItems[i][j] == MenuItems.Chicken)

                        quantitychicken++;
                }

            }

            var egg = cook.Submit(MenuItems.Egg, quantityegg);
            cook.PrepareFood(egg);
            menuegg = egg as Egg;
            var chicken = cook.Submit(MenuItems.Chicken, quantitychicken);
            cook.PrepareFood(chicken);
            order = true;

        }

        public string Serve()
        {
            if (!order)
            {
                throw new Exception("get order first");
            }

            int quantityeggs = 0;
            int quantitychickens = 0;
            string answer = "";

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < menuItems[i].Length; j++)
                {
                    if (menuItems[i][j] == MenuItems.Egg)

                        quantityeggs++;

                    if (menuItems[i][j] == MenuItems.Chicken)

                        quantitychickens++;
                }
                answer += $"Cosromr {i}:  {quantityeggs} egg;   {quantitychickens} chicken;  {menuItems[i][menuItems[i].Length - 1]} \r\n ";
                quantitychickens = 0;
                quantityeggs = 0;
            }
            menuItems = new MenuItems[8][];
            order = false;
            count = 0;
            return answer;
        }

        public string Inspect()
        {
            if (menuegg is Egg egg && egg.GetQuantity() > 0)
            {
                return egg.GetQuality().ToString();
            }
            return "No inspaction";
        }
    }
}
