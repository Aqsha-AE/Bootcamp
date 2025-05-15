public class Room
{
    public string Name;
    // nilai default dari field adalah null
    //public string Name = "tes";
}

public class Bedroom : Room
{
    public string BedCover;
    public int BedSize;
}

public class RumahSakit : Room
{

    public string JenisKamar;
    public int NomorKamar;
    public int JumlahKasur;
}

public class Program
{
    static void Main(string[] args)
    {
        Bedroom nisa = new Bedroom { Name = "Nisa", BedCover = "Bantal", BedSize = 2 };
        Console.WriteLine($"Name: {nisa.Name} tertidur di atas {nisa.BedCover} dengan ukuran {nisa.BedSize} m2");

        RumahSakit hermina = new RumahSakit { Name = "pakboy", JenisKamar = "VIP", NomorKamar = 101, JumlahKasur = 2 };
        Console.WriteLine($"Name: {hermina.Name} dirawat di rumah sakit dengan jenis kamar {hermina.JenisKamar} dengan nomor kamar {hermina.NomorKamar} dan jumlah kasur {hermina.JumlahKasur}");

        // upcasting
        Bedroom kiki = new Bedroom { Name = "Kiki" };
        Room c = kiki; // upcasting
        Console.WriteLine($"Name: {c.Name}"); // Name: Kiki

        /*
        // downcasting Invalid 
        Room room_1 = new Room();
        Bedroom bedroom_1 = (Bedroom)room_1; 
        Console.WriteLine($"Name: {bedroom_1.Name}"); // InvalidCastException
        */

        // downcasting
        Room room_2 = new Bedroom { Name = "Eka" };
        Bedroom bedroom_2 = (Bedroom)room_2;
        Console.WriteLine($"Name: {bedroom_2.Name}"); // Name: Eka

        // safer downcasting 
        Room room_3 = new Bedroom { Name = "Jaya" };
        Bedroom bedroom_3 = room_3 as Bedroom;
        Console.WriteLine($"Name: {bedroom_3.Name}"); // Name: Jaya

        // safer downcasting
        Room z = new Bedroom ();
        Bedroom u = z as Bedroom;
        if (u != null) {
            Console.WriteLine(z.Name);
        } else {
            Console.WriteLine("The Cast is not valid.");
        }
    }
}