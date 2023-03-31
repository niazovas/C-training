using System.Threading;

namespace FourthProject
{
    public class Cook
    {
        public string Name { get; set; }
        public bool busy = false;
        readonly static SemaphoreSlim slim = new SemaphoreSlim(2, 2);
        public void Process(TableRequest tableRequest)
        {
            var foods = tableRequest.Get<CookedFood>();
            busy = true;
            slim.Wait();
            Thread.Sleep(10000);
            foreach (var item in foods)
            {
                (item as CookedFood).Prepare();
            }
            slim.Release();
            busy = false;
        }


    }
}

