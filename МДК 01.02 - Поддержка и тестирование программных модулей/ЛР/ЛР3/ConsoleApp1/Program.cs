char[,] polybiy = {
    {'A', 'B', 'C', 'D', 'E'},
    {'F', 'G', 'H', 'I', 'J'},
    {'L', 'M', 'N', 'O', 'P'},
    {'Q', 'R', 'S', 'T', 'U'},
    {'V', 'W', 'X', 'Y', 'Z'},
    {'K', ' ', '2', '3', '4'}
};
Console.WriteLine("Enter a message:");
string msg = Console.ReadLine();
string new_message = "";
for (int i = 0; i < msg.Length; i++)
{
    for (int j = 0; j < polybiy.GetLength(0); j++)
        for (int k = 0; k < polybiy.GetLength(1); k++)
            if (Char.ToLower(polybiy[j, k]) == msg[i] || Char.ToUpper(polybiy[j, k]) == msg[i])
            {
                new_message += (Convert.ToString(j) + Convert.ToString(k));
                break;
            }
}
Console.WriteLine(new_message);
Console.WriteLine("Enter a code:");
string message1 = Console.ReadLine();
string new_message1 = "";
for (int a = 0; a < message1.Length; a += 2)
{
    new_message1 += polybiy[Convert.ToInt32(message1[a].ToString()), Convert.ToInt32(message1[a + 1].ToString())];
}
Console.WriteLine(new_message1);
