using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    class OpenSourceSoftware : Software
    {
        public OpenSourceSoftware(string name, string code, bool openSource, string developer) : base(name, code, openSource, developer)   
        {

        }

        public override void InfoSoftware()
        {
            Console.WriteLine($"Название ПО: {name} \n" +
                          $"Кодовый номер: {code}\n" +
                          $"Свободное? {openSource}\n" +
                          $"Разработчик: {developer}");
        }
    }

    //public override void InfoTransport()
    //{
    //    Console.WriteLine($"Марка - {make} \n" +
    //                      $"Номер - {number}\n" +
    //                      $"Скорость - {speed}");
    //}
    //public override void InfoСapacity()
    //{
    //    Console.WriteLine($"Грузоподъемность - {loadСapacity}");
    //}
}
