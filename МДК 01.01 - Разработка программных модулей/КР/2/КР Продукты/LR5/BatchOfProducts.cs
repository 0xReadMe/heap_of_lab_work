// Children of AProduct
namespace LR5
{
    class BatchOfProducts : AProduct
    {
        protected double cost;
        protected DateTime date;
        protected DateTime outOfDate;
        protected int count;
        public BatchOfProducts(string name, string code, string manufacturer, double cost, int count, DateTime date, DateTime outOfDate) : base(name, code, manufacturer)
        {
            try 
            {
                this.cost = cost;
                this.date = date;
                this.outOfDate = outOfDate;
                this.count = count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании конструктора BatchOfProducts: {ex}");
            }
        }
        public override void InfoProduct()
        {
            try 
            {
                Console.WriteLine($"Наименование партии: {name}\n" +
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
            if (DateTime.Now < outOfDate)
                return "Продукт не просрочен";
            else
                return "Продукт просрочен";
        }
    }
}
