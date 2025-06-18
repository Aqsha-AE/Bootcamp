namespace DecoratePattern;

public class AccessoriesDecorator : BaseDecorator
{
    public AccessoriesDecorator(IWomen women) : base(women)
    {
    }

    public override IWomen Show()
    {
        //return concreate behavior
        women.Show();
        AddHeadBand(women);
        return women;
    }

    public void AddHeadBand(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "Head Band ";
            System.Console.WriteLine("Women Showing Head Band");
        }
    }
}