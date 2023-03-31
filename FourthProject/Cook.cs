
using System.Collections.Generic;
using System.Windows.Forms;

namespace FourthProject
{
    public class Cook
    {
        int counter = 0;
        public delegate void ProcessedDelegate();
        public event ProcessedDelegate Processed;

        public void Process(TableRequest tableRequest)
        {

            int avr = 0;
            List<IMenuItem> eggs = tableRequest.Get<Egg>();
            List<IMenuItem> chickens = tableRequest.Get<Chicken>();
            foreach (var item in eggs)
            {
                var egg = (Egg)item;
                egg.Prepare();
                avr += egg.GetQuality();
                counter++;
            }
            foreach (var item in chickens)
            {
                var chicken = (Chicken)item;
                chicken.Prepare();
            }
            if (counter!=0)
            counter = avr / counter;
            else counter = 0;
            Processed?.Invoke();
        }
        public int GetQuality() => counter;
       
    }
}

