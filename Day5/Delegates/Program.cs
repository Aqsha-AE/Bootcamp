public class Program
{
    public static int averageData(int x, int y, int z) => (x * 2 + y * 6 + z) / 3;
    public delegate int myDelegateData(int num1, int num2, int num3);
    public static void Main()
    {
        
        myDelegateData kantor = new myDelegateData(averageData);

   
        Console.Write("Setiap divisi mengirimkan 2 orang untuk mewakili, maka berapa jumlah divisi yang hadir di ruang meeting 1 ? ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Setiap divisi mengirimkan 6 orang untuk mewakili, maka berapa jumlah divisi yang hadir di ruang meeting 2 ?");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Berapa jumlah manusia di ruang meeting 3 ?");
        int z = Convert.ToInt32(Console.ReadLine());
        
        int result = kantor(24, 35, 37);

        Console.WriteLine("Jumlah rata-rata manusia di ruang meeting adalah " + result);


    }
} 