namespace Tesat;

public struct Demo
{
    public string c = "huru";
    public string d;
    public Demo() => d = "hara";
}

public class Program
{
    public static void Main(string[] args)
    {
        Demo jakarta = new Demo();
        Demo surabaya = default;    
        Console.WriteLine(jakarta.c + jakarta.d);
        Console.WriteLine(surabaya.c + surabaya.d);
    }
}
