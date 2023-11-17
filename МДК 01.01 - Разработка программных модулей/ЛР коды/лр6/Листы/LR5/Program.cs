List<Member> all = new List<Member>();
string path = "C:/Users/SP4-IVC/Desktop/ПО/LR5/date.txt";
all = FillList(all, path);

Console.WriteLine("==================Мужчины==================\n");
foreach (Member member in all)
    if (member.Sex.Trim().ToLower() == "муж")
        Console.WriteLine(member);
Console.WriteLine("\n==================Женщины==================\n");
foreach (Member member in all)
    if (member.Sex.Trim().ToLower() == "жен")
        Console.WriteLine(member);
Console.ReadKey();

static List<Member> FillList(List<Member> members, string path) 
{
    string? line;
    StreamReader file = new StreamReader(path);
    while ((line = file.ReadLine()) != null)
    {
        Member m = new Member();
        string[] t = line.Split(' ');
        m.Surname = t[0];
        m.Name = t[1];
        m.Patronymic = t[2];
        m.Sex = t[3];
        m.Age = t[4];
        m.Salary = t[5];
        members.Add(m);
    }
    file.Close();
    return members;
}
struct Member
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Sex { get; set; }
    public string Age { get; set; }
    public string Salary { get; set; }
    public override string ToString()
    {
        return string.Format(
            $"\t{Surname}|{Name}|{Patronymic}|{Sex}|{Age}|{Salary}"
            );
    }
}