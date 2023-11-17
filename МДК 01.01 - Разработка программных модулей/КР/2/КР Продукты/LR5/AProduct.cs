// Abstract Class
namespace LR5
{
    abstract class AProduct
    {
        public string name;
        public string code;
        public string manufacturer;
        public DateTime date;

        public AProduct(string name, string code, string manufacturer)
        {
            this.name = name;
            this.code = code;
            this.manufacturer = manufacturer;
        }

        public AProduct(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public abstract void InfoProduct();

        public static AProduct[] CompareTo(AProduct[] n)
        {
            var product = new List<AProduct>();
            for (int i = 0; i < n.Length; i++) 
            {
                product.Add(n[i]);
            }
            product.Sort((product1, product2) =>
            {
                var res = product1.name.CompareTo(product2.name);
                return res;
            });
            n = product.ToArray();
            return n;
        }
    }
}
