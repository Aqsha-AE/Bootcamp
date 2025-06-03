using System;

class Numberprinter
{
    Dictionary<int, string> rules;
    public Numberprinter()
    {
        rules = new Dictionary<int, string>();
    }

    public void AddRule(int input, string output)
    {
        rules[input] = output;
    }

    public void Print(int a)
    {
        for (int i = 1; i <= a; i++)
        {
            List<int> pembaginya = new List<int>();
            foreach (int d in rules.Keys)
            {
                if (i % d == 0)
                {
                    pembaginya.Add(d);
                }
            }

            if (pembaginya.Count > 0)
            {
                string detail = "";
                foreach (int d in pembaginya)
                {
                    detail += rules[d];
                }
                Console.Write(detail);

                if (i < a)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
class Latihan
{
    static void Main()
    {
        Console.Write("Masukkan nilai: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Numberprinter cek = new Numberprinter();

        cek.AddRule(3, "Foo");
        cek.AddRule(5, "Bar");
        cek.AddRule(7, "Jazz");
        cek.AddRule(4, "baz");
        cek.AddRule(9, "huzz");
        cek.AddRule(11, "Qux");
        
        cek.Print(a);
    }
}
