//hewan apa aja 

using System;

public class HewanPeliharaan
{
    public const int UmurMax = 20;
    private string _nama;
    private string _jenis;
    private int _umur;

    public string Nama { get; set; }
    public string Jenis { get; set; }
    public int Umur
    {
        get { return _umur; }
        set
        {
            _umur = value;
        }
    }

    public HewanPeliharaan(string nama, string jenis, int umur)
    {
        Nama = nama;
        Jenis = jenis;
        Umur = umur;
    }

    public HewanPeliharaan(string nama) : this(nama, "husky", 5)
    {
        // Constructor ini memanggil constructor lain dengan umur default 
    }

    public void InfoHewan()
    {
        Console.Write($"Nama: {Nama}\n Jenis: {Jenis}\n Umur: {Umur} tahun\n");
    }
}

public class KataKunci
{
    private string[] word = "Tempat Penitipan Hewan Peliharaan".Split();

    public string this[int wordNum]
    {
        get { return word[wordNum]; }
        set { word[wordNum] = value; }
    }
}

public static class MaksimumHewan
{
    public static double AddHewan(double a, double b) => a + b;
}
public class Program
{
    public static void Main(string[] args)
    {
        HewanPeliharaan hewan1 = new HewanPeliharaan("Kucing", "anggora", 2);
        HewanPeliharaan hewan2 = new HewanPeliharaan("Anjing");
        HewanPeliharaan hewan3 = new HewanPeliharaan("Anjing", "Bulldog", 30);

        hewan1.InfoHewan();
        hewan2.InfoHewan();
        hewan3.InfoHewan();

        Console.Write("Testing KataKunci :");
        KataKunci test = new KataKunci();
        Console.WriteLine(test[0]);

        double max = MaksimumHewan.AddHewan(100, 10);
        Console.WriteLine($"Kapasitas maksimum hewan peliharaan adalah {max} ekor");
    }
}