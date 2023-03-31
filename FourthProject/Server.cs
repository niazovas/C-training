using System;
using System.Collections.Generic;

namespace FourthProject
{
    public class Server
    {
        public delegate void ServerEventHandler(TableRequest tableRequest);
        public event ServerEventHandler ReadyEvent;
        TableRequest tableRequest = new TableRequest();
        int count = 0;
        bool order = false;

        public void Request(string name, int eggquantity, int chickenquantity, string drinks)
        {

            if (count < 8)
            {
                for (int i = 0; i < eggquantity; i++)
                { tableRequest.Add<Egg>(name); }

                for (int i = 0; i < chickenquantity; i++)
                { tableRequest.Add<Chicken>(name); }

                if (drinks != "NoDrink")
                {
                    if (drinks == "CocaCola") tableRequest.Add<CocaCola>(name);
                    else if (drinks == "Pepsi") tableRequest.Add<Pepsi>(name);
                    else if (drinks == "Tea") tableRequest.Add<Tea>(name);
                }
                count++;
                order = true;
            }
            else throw new Exception("order more than 8");
        }

        public void Send()
        {
            if (!order)
            { throw new Exception("Firs get the order"); }

            ReadyEvent?.Invoke(tableRequest);
        }

        public List<string> Serve()
        {
            List<string> list = new List<string>();
            int egg = 0;
            int ch = 0;
            
            string typeDrink = "";
            string drink = "NoDrink";
            foreach (var item in tableRequest)
            {
                var customersOrders = tableRequest[item];
                foreach (IMenuItem menu in customersOrders)
                {
                    if (menu is Egg)
                        egg++;
                    else if (menu is Chicken)
                        ch++;
                    else
                    {
                        drink = ((Drinks)menu).GetType().Name;
                        typeDrink += drink;
                        typeDrink += " ";
                    }
                }
                list.Add($"Customer {item} - is surved {typeDrink}, {egg} egg, {ch} chicken");
                egg = 0;
                ch = 0;
            }
            tableRequest = new TableRequest();
            return list;
        }
    }
}
