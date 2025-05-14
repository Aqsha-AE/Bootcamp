using buku; 

namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        Console.Write("berapa umurnya ?"); 
        string colour = int.Parse(Console.ReadLine()); 
        Ipa biologi = new Ipa(); 
    }
}

public class Ipa
{
    public string name; 
    public string colour; 
    public Ipa (string Name, string Colour)
    {
        name = Name; 
        colour = Colour;
    }
    public void Read()
	{
		Console.WriteLine($" buku {name} dengan warna {colour} dibaca");
	}
}