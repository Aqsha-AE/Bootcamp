namespace koleksi; 
public class Book
{
    public string Title {get; set;}
    public string Penulis {get; set;}
    public string Colour {get; set;} 
    public Book (string title, string penulis, string colour)
    {
        Title = title; 
        Penulis = penulis; 
        Colour = colour;
    }
    public void InfoBuku()
	{
		Console.WriteLine($" Buku berjudul {Title} ditulis oleh {Penulis} dengan warna {Colour}");
	}
}
