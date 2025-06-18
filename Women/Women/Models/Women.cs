namespace DecoratePattern;

public class Women : IWomen
{
    public string? Name { get; set; }
    public int Hight { get; set; }
    public string Deco { get; set; } = "No Decoration";

    public Women(string name, int hight)
    {
        this.Name = name;
        this.Hight = hight;
    }
    public IWomen Show()
    {
        Console.WriteLine($"Name: {this.Name}, Hight: {this.Hight}");
        return this;
    }
}