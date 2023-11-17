namespace Katalog
{
    internal class Catalog
    {
        public string periogika;
        public string readHall;
        public string abonement;
        public string rareLiteratyre;
        public Catalog(string periogika, string readHall, string abonement, string rareLiteratyre)
        {
            this.periogika = periogika;
            this.readHall = readHall;
            this.abonement = abonement;
            this.rareLiteratyre = rareLiteratyre;
        }     
        public void InfoCatalog()
        {
            Console.WriteLine($"Периодика - {this.periogika}");
            Console.WriteLine($"Читальный зал - {this.readHall}");
            Console.WriteLine($"Абонемент - {this.abonement}");
            Console.WriteLine($"Редкость литературы - {this.rareLiteratyre}");
        }
    }
}
