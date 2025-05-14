using fungsi; 


class Program{
    static void Main () 
    {
        Kalkulator mei = new Kalkulator(); 
        Console.WriteLine (mei.tambah(5, 10)); 
        Console.WriteLine (mei.bagi(4.3m, 1.2m)); 

        Kalkulator rahma = new Kalkulator(); 
        Console.WriteLine (rahma.kurang (3, 1)); 
        Console.WriteLine (rahma.kurang (3, 9)); 
    }
}