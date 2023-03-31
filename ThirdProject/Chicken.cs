using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject
{
    sealed public class Chicken : CookedFood
    {
        public void CutUp()
        {
        }
        public override void Cook()
        {
        }
        public override void Obtain()
        {
        }
        public override void Serve()
        {
        }
        public override void Prepare()
        {
            Obtain();
            CutUp();
            Cook();
        }
    }
}
