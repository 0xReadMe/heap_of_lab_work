using ConsoleApp3;

ACipher ciph = new ACipher("our text");
Console.WriteLine(ciph.Encode());
Console.WriteLine(ciph.Encode("abcdefghijklmnopqrstuvwxyz"));

BCipher ciph2 = new BCipher("our text");
Console.WriteLine(ciph2.Encode());
Console.WriteLine(ciph2.Encode("abcdefghijklmnopqrstuvwxyz"));