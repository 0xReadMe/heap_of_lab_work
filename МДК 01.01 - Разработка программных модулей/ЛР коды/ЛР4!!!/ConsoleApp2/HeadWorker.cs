using System;

namespace ConsoleApp2
{
    class HeadWorker : Worker
    {
        public HeadWorker(string name) : base(name) 
        {
            cash = 20000;
        }
        public override void Work()
        {
            base.Work();
            yearsBeforeRetirement++;
        }

        public override void PrizeForWorker(Random rnd)
        {
            rnd = new Random();
            int increase = rnd.Next(500, 1000);
            cash += increase * 3;
        }

        public void SetCash(Worker wrk) 
        {
            Console.Write($"Какую зарплату установить работнику {wrk.Name}?\n");
            Console.Write(">");
            int setCash = int.Parse(Console.ReadLine());
            wrk.cash = setCash;
        }
    }
}
