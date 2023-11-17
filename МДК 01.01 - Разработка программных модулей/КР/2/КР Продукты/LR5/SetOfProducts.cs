// Children of AProduct
namespace LR5
{
    class SetOfProducts : AProduct
    {
        protected double cost;
        protected string products;
        public SetOfProducts(string name, string code, double cost, string products) : base(name, code)
        {
            this.cost = cost;
            this.products = products;
            this.products = products;
        }
        public override void InfoProduct()
        {
            Console.WriteLine($"Название комплекта: {name}\n" +
                          $"Кодовый номер: {code}\n" +
                          $"Содержимое: {products}\n" +
                          $"Цена: {cost}");
        }
    }
}
