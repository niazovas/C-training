using System;


namespace ThirdProject
{
    class TableRequest
    {

        public IMenuItem[][] menuItems = new IMenuItem[0][];

        public void Add(int customer, IMenuItem i)
        {
            if (customer < 8)
            {
                if (menuItems.Length < customer + 1)
                    Array.Resize(ref menuItems, menuItems.Length + 1);

                if (menuItems[customer] == null)
                    menuItems[customer] = new MenuIteam[0];

                Array.Resize(ref menuItems[customer], menuItems[customer].Length + 1);
                menuItems[customer][menuItems[customer].Length - 1] = i;
            }
            else
                throw new Exception("Order mo than 8");
        }


        public IMenuItem[] this[Type type]
        {
            get
            {
                IMenuItem[] result = new IMenuItem[0];
                for (int i = 0; i < menuItems.Length; i++)
                {
                    for (int j = 0; j < menuItems[i].Length; j++)
                    {
                        if (type.IsAssignableFrom(menuItems[i][j].GetType()))
                        {
                            Array.Resize(ref result, result.Length + 1);
                            result[result.Length - 1] = menuItems[i][j];
                        }

                    }
                }
                return result;
            }
        }

        public IMenuItem[] this[int customerNumber]
        {
            get
            {
                return menuItems[customerNumber];
            }
        }


    }
}
