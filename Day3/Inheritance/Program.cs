class Room
{
    public string Name;
}

class Bedroom : Room
{
    public string BedCover;
    public int BedSize;
}

class RumahSakit : Room
{

    public string JenisKamar;
    public int NomorKamar;
    public int JumlahKasur;
}

class Program
{
    static void Main(string[] args)
    {
        Bedroom nisa = new Bedroom { Name = "Nisa", BedCover = "Bantal", BedSize = 2 };
        Console.WriteLine($"Name: {nisa.Name} tertidur di atas {nisa.BedCover} dengan ukuran {nisa.BedSize} m2");

        RumahSakit hermina = new RumahSakit { Name = "pakboy", JenisKamar = "VIP", NomorKamar = 101, JumlahKasur = 2 };
        Console.WriteLine($"Name: {hermina.Name} dirawat di rumah sakit dengan jenis kamar {hermina.JenisKamar} dengan nomor kamar {hermina.NomorKamar} dan jumlah kasur {hermina.JumlahKasur}");
    }
}