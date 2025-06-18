namespace DecoratePattern;

public class HairDecorator : BaseDecorator
{
    public HairDecorator(IWomen women) : base(women)
    {
    }

    public override IWomen Show()
    {
        //return concreate behavior
        women.Show();
        AddLongHair(women);
        AddShortHair(women);
        return women;
    }

    public void AddLongHair(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "Long hair";
            System.Console.WriteLine("Women Showing Long Hair");
        }
    }

    public void AddShortHair(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "Shot Hair";
            System.Console.WriteLine("Women Showing Long Hair");
        }
    }
}