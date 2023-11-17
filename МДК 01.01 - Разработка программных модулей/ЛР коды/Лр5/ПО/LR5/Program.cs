using LR5;
using static LR5.NonOpenSoftware;
DateTime dateOfUse = new DateTime(2022, 11, 15);

Software[] n = new Software[3];
n[0] = new OpenSourceSoftware("PuTTy", "0x2526", true, "Mikhail Z.");
n[1] = new NonOpenSoftware("Battle.net", "0x0012", false, "Danile A.", dateOfUse);
n[2] = new CommercialSoftware("BurpSuit", "0x0001", false, "Mezerya A.", 35000, dateOfUse);
foreach (Software soft in n)
{
    soft.InfoSoftware();
    Console.WriteLine("----------------------------------------------");
}

var sortN = Software.CompareTo(n);
Console.WriteLine("----------------------------------------------");
Console.WriteLine("Отсортированный список ПО");
Console.WriteLine("----------------------------------------------");
foreach (Software soft in sortN)
{
    soft.InfoSoftware();
    Console.WriteLine("----------------------------------------------");
}
FindSoft(sortN, dateOfUse);

static void FindSoft(Software[] n, DateTime dateOfUse)
{
    int count = 0;
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("Программное обеспечение, которое допустимо использовать на текущую дату");
    Console.WriteLine("----------------------------------------------");
    foreach (Software soft in n)
    {
        if (soft.GetType() == typeof(NonOpenSoftware) || soft.GetType() == typeof(CommercialSoftware))
        {
            if(CheckDate(dateOfUse) == true)
            soft.InfoSoftware();
            Console.WriteLine("----------------------------------------------");
            count++;
        }
    }
    if (count == 0)
        Console.WriteLine("Такого ПО не существует.");
}