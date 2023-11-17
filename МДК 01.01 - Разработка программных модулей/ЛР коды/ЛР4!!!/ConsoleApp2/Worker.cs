using System;

namespace ConsoleApp2
{
    class Worker
    {
        protected string name;
        protected int yearsBeforeRetirement;
        public int cash;

        public string Name 
        {
            get => name;
            set 
            {
                name = value;
            } 
        }

        public Worker(string name) 
        {
            Name = name;
            cash = 10000;
            yearsBeforeRetirement = 40;
        }

        public virtual void Work() 
        {
            Console.WriteLine($"Человек {Name} работает...");
            cash += 100;
            yearsBeforeRetirement--;
        }

        public void PrintInfo() 
        {
            Console.WriteLine($"У {Name} заработная плата {cash}");
        }

        public void PrizeForWorker(int increase) 
        {
            cash += increase;
        }

        public virtual void PrizeForWorker(Random rnd)
        {
            rnd = new Random();
            int increase = rnd.Next(500, 1000);
            cash += increase;
        }
        private void Fine()
        {
            Console.WriteLine($"Штраф работнику {Name}");
        }

        public void GetCash() 
        {
            cash /= 2;
            Console.WriteLine($"Текущая З/П: {cash}");
        }
    }
}
