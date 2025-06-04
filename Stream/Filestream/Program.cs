using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Aqsha\OneDrive\Documents\Bootcamp\Stream\Filestream\nyumnyum.txt";

        var file = File.Create(filePath);
        file.Close();
        Console.WriteLine("File berhasil dibuat!");

        File.WriteAllText(filePath, "Bandingkan rasa eskrim vanila antara mixue, momoyo dan godiva");

        string[] rates = { "\nmixue enak", "momoyo hambar", "godiva enak yang coklat" };
        File.AppendAllLines(filePath, rates);
        Console.WriteLine("amjattt");

        /*byte[] bahan = new byte[300];
        File.WriteAllBytes(filePath, bahan);*/
        
        Console.WriteLine(File.ReadAllLines(filePath));
        Console.WriteLine("1");
        /*
        File.ReadAllBytes(filePath);
        System.Console.WriteLine("2");
        */ 

        System.Console.Write(File.ReadAllText(filePath));
        System.Console.WriteLine("3");
    }
}