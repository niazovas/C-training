using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthProject
{
   public abstract class CookedFood:MenuItem
    {
        public abstract void Prepare();
        public abstract void Cook();

    }
}
