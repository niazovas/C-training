
using System.Windows.Forms;

namespace ThirdProject
{
    class Cook
    {
        public void Process(TableRequest tableRequest)
        {
            int counter = 0;
            int avr = 0;
            IMenuItem[] itemegg = tableRequest[typeof(Egg)];
            foreach (IMenuItem item in itemegg)
            {
                Egg egg = (Egg)item;
                egg.Prepare();

                avr += egg.GetQuality();
                counter++;
            }
            if (counter != 0)
                MessageBox.Show($"Average quality Egg is { avr / counter}");



            IMenuItem[] itemchicken = tableRequest[typeof(Chicken)];
            foreach (IMenuItem item in itemchicken)
            {
                Chicken chicken = (Chicken)item;
                chicken.Prepare();

            }
        }
    }
}
