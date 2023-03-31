using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthProject
{
    public abstract class MenuItem : IMenuItem
    {
        public abstract void Obtain();

        public abstract void Serve();

    }
}
