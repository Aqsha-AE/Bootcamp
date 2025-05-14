namespace truk;
abstract class Mekanik
{
    public string Jenis { get; set; }
    public Mekanik(string jenis)
    {
        Jenis = jenis;
    }
    public abstract void Suara();
}

class Truk : Mekanik
{
    public Truk(string jenis) : base(jenis) // Memanggil konstruktor dari superclass
    {
    }
    public override void Suara()
    {
        Console.WriteLine($"Suara {Jenis}: vroom vroom");
    }
}