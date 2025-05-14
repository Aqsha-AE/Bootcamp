namespace Human;
class Program
{
	static void Main() 
	{
        Console.Write("siapa namanya ?"); 
        string name = Console.ReadLine();
        Console.Write("berapa umurnya ?"); 
        int age = int.Parse(Console.ReadLine()); 
        People petani = new People(name, age); 
        
        Console.Write("mau makan apa ?"); 
        string makanan = Console.ReadLine();
        petani.Eat(makanan); 
	}
}
public class People
{
	public string Name {get; set;}
	public int Age {get; set;}
    // panggil constructor 
    public People (string name, int age)
    {
        Name = name; 
        Age = age; 
    }
    public void Eat(string jenisMakanan)
	{
		Console.WriteLine($"{Name} dengan umur {Age} eat " + jenisMakanan);
	}

}
