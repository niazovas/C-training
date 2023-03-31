using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FourthProject
{
    public class TableRequest : IEnumerable<KeyValuePair<string, List<IMenuItem>>>
    {
        public bool busy = false;
        Dictionary<string, List<IMenuItem>> Orders = new Dictionary<string, List<IMenuItem>>();

        public void Add<T>(string _name) where T : IMenuItem, new()
        {
            if (!Orders.ContainsKey(_name))
                Orders[_name] = new List<IMenuItem>();

            Orders[_name].Add(new T());
        }

        public List<IMenuItem> Get<T>() where T : CookedFood
        {
            busy = true;
            var list = Orders.Values.SelectMany(item => item).Where(o => o is T).ToList();
            return list;
        }

        public IEnumerator<KeyValuePair<string, List<IMenuItem>>> GetEnumerator()
        {
            foreach (var item in Orders)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
