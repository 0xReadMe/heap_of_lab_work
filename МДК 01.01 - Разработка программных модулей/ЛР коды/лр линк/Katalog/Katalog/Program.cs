using Katalog;
List<Catalog> list = new List<Catalog>()
{
    new Catalog("1950-1978", "Второй зал", "6 месяцев", "Очень редкая"),
    new Catalog("1978-2004", "Первый зал", "3 месяца", "Не редкая"),
    new Catalog("2004-2022", "Третий зал", "Годовой", "Редкая")
};
Console.WriteLine("Список комамнд");
Console.WriteLine("1 - Вывести информацию о всех каталогах");
Console.WriteLine("2 - Информация о конкретных каталогах");
Console.WriteLine("3 - Добавить новый каталог");
Console.WriteLine("4 - Удалить конкретные каталоги");
while (true)
{
    Console.Write("Введите команду из списка - ");
    int i = int.Parse(Console.ReadLine());
    switch (i)
    {
        case 1:
            foreach (Catalog catalog in list)
            {
                catalog.InfoCatalog();
                Console.WriteLine("------------------------------");
            }
            break;
        case 2:
            Console.WriteLine("Введите периодику каталога");
            string periodika = Console.ReadLine();
            var Iskom = from cat in list
                        where cat.periogika == periodika
                        select cat;
            foreach (Catalog catalog in Iskom)
            {
                catalog.InfoCatalog();
                Console.WriteLine("------------------------------");
            }
            break;
        case 3:
            Console.WriteLine("Введите данные нового каталога");
            string periogika = Console.ReadLine();
            string readHall = Console.ReadLine();
            string abonement = Console.ReadLine();
            string rareLiteratyre = Console.ReadLine();
            list.Add(new Catalog(periogika, readHall, abonement, rareLiteratyre));
            break;
        case 4:
            Console.WriteLine("Введите периодику каталога");
            string periodikaDel = Console.ReadLine();
            var IskomDel = from cat in list
                        where cat.periogika == periodikaDel
                        select cat;
            foreach (Catalog catalog in list)
            {
                bool abc = true;
                for (int j = 0; j < list.Count; j++)
                {
                    foreach (Catalog delCatalog in IskomDel)
                    {
                        if (catalog.periogika == delCatalog.periogika)
                        {
                            list.RemoveAt(j);
                            Console.WriteLine("Каталог удалён");
                            abc = false;
                            break;
                        }
                    }
                    if (abc == true)
                    {
                        abc = true;
                        continue;
                    }
                    else 
                        break;
                }
                if (abc == true)
                {
                    Console.WriteLine("Не удалось удалить каталог");
                    break;
                }
                else
                    continue;
            }
                
                    
            break;
        default:
            Console.WriteLine("Ввод некорректных данных");
        break;
    }
}

        