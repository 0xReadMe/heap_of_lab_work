// Children of AProduct
namespace LR5
{
    class Product : AProduct
    {
        protected double cost;
        protected DateTime date;
        public DateTime outOfDate;
        public Product(string name, string code, string manufacturer, double cost, DateTime date, DateTime outOfDate) : base(name, code, manufacturer)
        {
            try
            {
                this.cost = cost;
                this.date = date;
                this.outOfDate = outOfDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании конструктора Product: {ex}");
            }

        }

        public override void InfoProduct()
        {
            try 
            {
                Console.WriteLine($"Наименование продукта: {name} \n" +
                      $"Кодовый номер: {code}\n" +
                      $"Производитель: {manufacturer}\n" +
                      $"Дата производства: {date}\n" +
                      $"Просрочка: {CheckDate(outOfDate)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе InfoProduct: {ex}");
            }

        }

        public string CheckDate(DateTime outOfDate)
        {
            try 
            {
                if (DateTime.Now < outOfDate)
                    return "Продукт не просрочен";
                else
                    return "Продукт просрочен";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе Checkdate: {ex}");
                return "0";
            }

        }
    }
}
