//tentukan suara hewa

class hewan {
    public virtual string Suara()
    {
        return "Suara hewan";
    }
}

class harimau : hewan {
    public override string Suara (){
        Console.WriteLine("Suara harimau: aaarrrggghhh");
        return "Suara harimau";
    }
}

class kucing : hewan {
    public override string Suara (){
        Console.WriteLine("Suara kucing: meow");
        return "Suara kucing";
    }
}
class anjing : hewan {
    public override string Suara (){
        Console.WriteLine("Suara anjing: guk guk");
        return "Suara anjing";
    }
}

class Program
{
    static void Main(string[] args)
    {
        hewan hewan1 = new harimau();
        hewan1.Suara();

        hewan hewan2 = new kucing();
        hewan2.Suara();

        hewan hewan3 = new anjing();
        hewan3.Suara();
    }
}