using truk; 
abstract class Kendaraan
{
    public string Name;  
    public abstract void berhenti(); //abstract method yang dioverride
    public void info()
    {
        Console.WriteLine("Kendaraan ini adalah " + Name);
    }
}

class Mobil : Kendaraan
{
    public override void berhenti()
    {
        Console.WriteLine("Mobil berhenti saat lampu merah");
    }
}
class Motor : Kendaraan
{
    public override void berhenti()
    {
        Console.WriteLine("Motor berhenti saat lampu merah");
    }

}
class Program
{
    static void Main(string[] args)
    {
        Kendaraan kendaraan1 = new Mobil();
        kendaraan1.Name = "Mobil";
        kendaraan1.info();
        kendaraan1.berhenti();

        Kendaraan kendaraan2 = new Motor();
        kendaraan2.Name = "Motor";
        kendaraan2.info();
        kendaraan2.berhenti();

        // Membuat objek dari kelas Truk
        Truk truk1 = new Truk("Truk");
        truk1.Suara();
    }
}