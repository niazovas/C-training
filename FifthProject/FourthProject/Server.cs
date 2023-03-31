using System.Collections.Generic;
using System.Linq;


namespace FourthProject
{
    public class Server
    {
        TableRequest tableRequest = new TableRequest();
        public void Request(string name, int eggquantity, int chickenquantity, string drinks)
        {
            if (tableRequest.busy)
                tableRequest = new TableRequest();

            lock (this)
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
            }
        }
        public TableRequest GetTable() => tableRequest;

        public List<string> Serve(TableRequest table)
        {
            List<string> list = new List<string>();
            int egg = 0;
            int ch = 0;
            string drink = "NoDrink";
            string typeDrink = "";
            var listTable = table.OrderBy(i => i.Key);
            foreach (var item in listTable)
            {
                foreach (var i in item.Value)
                {
                    if (i is Egg)
                        egg++;
                    else if (i is Chicken)
                        ch++;
                    else
                    {
                        drink = ((Drinks)i).GetType().Name;
                        typeDrink = drink;
                        typeDrink += "";
                    }
                }
                list.Add($"Customer {item.Key} - is surved {typeDrink}, {egg} egg, {ch} chicken");
                egg = 0;
                ch = 0;
            }
            return list;
        }
    }

}


