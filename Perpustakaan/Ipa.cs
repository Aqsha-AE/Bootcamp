namespace buku; 
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
