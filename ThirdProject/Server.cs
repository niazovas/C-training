using System;


namespace ThirdProject
{
    public class Server
    {
        Cook cook = new Cook();
        TableRequest tableRequests = new TableRequest();
        int customerOrder = 0;
        bool order = false;


        public void Request(int quantityEgg, int quantityChicken, string drink)
        {
            if (order is true)
                throw new Exception("Order not Prepared");

            for (int i = 0; i < quantityChicken; i++)
            {
                tableRequests.Add(customerOrder, new Chicken());
            }
            for (int i = 0; i < quantityEgg; i++)
            {
                tableRequests.Add(customerOrder, new Egg());
            }
            if (drink != "NoDrink")
            {
                if (drink == "Tea") tableRequests.Add(customerOrder, new Tea());
                else if (drink == "CocaCola") tableRequests.Add(customerOrder, new CocaCola());
                else if (drink == "Pepsi") tableRequests.Add(customerOrder, new Pepsi());
            }
            customerOrder++;
        }

        public void Send()
        {
            if (order is true)
                throw new Exception("Alredy sent");

            cook.Process(tableRequests);
            order = true;
        }


        public string[] Serve()
        {
            if (!order)
                throw new Exception("First get the order and sent it to cook");

            int chicken = 0;
            int egg = 0;
            string drink = "NoDrink";
            string[] customersTable = new string[customerOrder];
            for (int i = 0; i < customerOrder; i++)
            {
                foreach (IMenuItem item in tableRequests[i])
                {
                    if (item is Egg)
                        egg++;
                    else if (item is Chicken)
                        chicken++;
                    else
                        drink = ((Drinks)item).GetType().Name;
                }
                customersTable[i] = $"Customer{i} is served {egg} egg,{chicken} chicken, {drink}";

                egg = 0;
                chicken = 0;
            }
            customerOrder = 0;
            order = false;
            tableRequests = new TableRequest();
            return customersTable;
        }
    }
}
