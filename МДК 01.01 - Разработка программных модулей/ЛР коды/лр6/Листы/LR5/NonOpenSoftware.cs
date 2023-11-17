using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    class NonOpenSoftware : Software
    {
        protected int cost;
        protected DateTime date;
        public NonOpenSoftware(string name, string code, bool openSource, string developer, DateTime date) : base(name, code, openSource, developer)
        {
            this.date = date;
        }
        public override void InfoSoftware()
        {
            Console.WriteLine($"Название ПО: {name}\n" +
                          $"Кодовый номер: {code}\n" +
                          $"Свободное? {openSource}\n" +
                          $"Разработчик: {developer}\n" +
                          $"Возможно ли использовать на текущую дату: {CheckDate(date)}");
        }
        static public bool CheckDate(DateTime date) 
        {
            if (DateTime.Now.Year > date.Year && DateTime.Now.Month > date.Month && DateTime.Now.Day > date.Day && DateTime.Now.Hour > date.Hour) return false;
            return true;
        }
    }
}
