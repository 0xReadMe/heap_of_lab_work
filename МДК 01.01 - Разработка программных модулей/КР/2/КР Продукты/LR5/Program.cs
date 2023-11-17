// MAIN PROGRAM
using LR5;
DateTime date = new DateTime(2022, 5, 15);
DateTime outOfDate = new DateTime(2023, 11, 15);
DateTime outOfDate2 = new DateTime(2022, 5, 27);
AProduct[] n = new AProduct[3];
n[0] = new Product("Яблоко", "140400", "ФермерООО", 25, date, outOfDate);
n[1] = new BatchOfProducts("Апельсины", "140402", "ФермерООО", 1500, 50, date, outOfDate);
n[2] = new SetOfProducts("Букет фруктов", "140403", 99, "Апельсин, Мандарин, Яблоко, Груша");
Console.WriteLine("================Склад================");
foreach (AProduct product in n)
{
    product.InfoProduct();
    Console.WriteLine("----------------------------------------------");
}
Console.WriteLine("================Привоз партии================");
Product[] products = new Product[3];
products[0] = new Product("Яблоко", "140400", "ФермерООО", 25, date, outOfDate2);
products[1] = new Product("Апельсин", "140399", "ФермерООО", 30, date, outOfDate);
products[2] = new Product("Мандарин", "140398", "ФермерООО", 35, date, outOfDate2);
foreach (Product product in products)
{
    product.InfoProduct();
    Console.WriteLine("----------------------------------------------");
}
Console.WriteLine("================Просрочившиеся продукты================");
FindOutOfDate(products);

static void FindOutOfDate(Product[] products)
{
    int count = 0;
    foreach (Product product in products)
    {
        if (product.GetType() == typeof(BatchOfProducts) || product.GetType() == typeof(Product))
        {
            if (product.CheckDate(product.outOfDate) == "Продукт просрочен")
                product.InfoProduct();
            Console.WriteLine("----------------------------------------------");
            count++;
        }
    }
    if (count == 0)
        Console.WriteLine("Все продукты свежие");
}