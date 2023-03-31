using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthProject
{
    public class TableRequest : IEnumerable<string>
    {
        Dictionary<string, List<IMenuItem>> Orders = new Dictionary<string, List<IMenuItem>>();

        public void Add<T>(string _name) where T : IMenuItem, new()
        {
            if (!Orders.ContainsKey(_name))
            {
                Orders[_name] = new List<IMenuItem>();
            }
            Orders[_name].Add(new T());
        }

        public List<IMenuItem> Get<T>() where T : CookedFood
        {
            var list = new List<IMenuItem>();
            foreach (var itemlist in Orders.Values)
            {
                foreach (var item in itemlist)
                {
                    if (item is T)
                        list.Add((T)item);
                }
            }
            return list;
        }

        public IEnumerator<string> GetEnumerator() => Orders.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public List<IMenuItem> this[string name]
        {
            get => Orders[name];
        }
    }
}
