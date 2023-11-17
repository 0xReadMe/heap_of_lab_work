using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    class CommercialSoftware : Software
    {
        protected int cost;
        protected DateTime date;
        public CommercialSoftware(string name, string code, bool openSource, string developer, int cost, DateTime date) : base(name, code, openSource, developer)
        {
            this.cost = cost;
            this.date = date;
        }
        public override void InfoSoftware()
        {
            Console.WriteLine($"Название ПО: {name}\n" +
                          $"Кодовый номер: {code}\n" +
                          $"Свободное? {openSource}\n" +
                          $"Разработчик: {developer}\n" +
                          $"Цена: {cost}\n" +
                          $"Возможно ли использовать на текущую дату: {NonOpenSoftware.CheckDate(date)}");
        }
    }
}
