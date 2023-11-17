using System.Collections.Generic;
using ConsoleApp1;

#region Задания Студенты
List<Student> list = new List<Student>()
{
    new Student("Иванов", 1),
    new Student("Антонов", 2),
    new Student("Истомина", 3),
    new Student("Жданов", 4),
    new Student("Михайлов", 5),
    new Student("Сатанов", 6),
    new Student("Слизнев", 7),
};


Console.WriteLine("=== Задание 1 ===");
var student =
    from n in list
    where n.name.ToCharArray()[0] == 'С' || n.name.ToCharArray()[0] == 'c'
    select n;
foreach(var x in student)
    Console.WriteLine($"{x.name} | {x.id}");

Console.WriteLine("=== Задание 2 ===");
var student2 =
    from n in list
    where (n.name.ToCharArray()[0] == 'С' || n.name.ToCharArray()[0] == 'c') && n.id % 2 == 0
    select n;
foreach (var x in student2)
    Console.WriteLine($"{x.name} | {x.id}");

Console.WriteLine("=== Задание 3 ===");
var student3 =
    from n in list
    orderby n.id ascending
    select n;
foreach (var x in student3)
    Console.WriteLine($"{x.name} | {x.id}");
#endregion

#region Файлы
Console.WriteLine("=== === === === ===");
DirectoryInfo dir = new DirectoryInfo(@"d:\");
var files = 
    from n in dir.GetFiles("*.docx")
    where n.Length < 10 * 1024
    select n;
foreach (var x in files) 
    Console.WriteLine($"{x.FullName} | {x.CreationTime}");
#endregion

#region Сортировка
Console.WriteLine("=== === === === ===");
int[] number = { 14, 0, 23, -3, 10, 19, 15 };
var sortedNums =
    from n in number
    orderby n
    select n / 2;
var descNums =
    from i in number
    orderby i descending
    where i > 0
    select i;
Console.WriteLine("= = = Задание 1 = = =");
foreach (var x in sortedNums) 
    Console.Write(x + " ");
Console.WriteLine("= = = Задание 2 = = =");
foreach (var i in descNums)
    Console.Write(i + " ");
#endregion