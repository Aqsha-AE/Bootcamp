namespace DecoratePattern;

public class ClothingDecorator : BaseDecorator
{
    public enum CholthingType
    {
        Dress,
        TShirt,
        Jacket
    }
    private readonly CholthingType _cholthingType;
    public ClothingDecorator(IWomen women, CholthingType type) : base(women)
    {
        this._cholthingType = type;
    }

    public override IWomen Show()
    {
        //return concreate behavior
        women.Show();
        switch (_cholthingType)
        {
            case CholthingType.TShirt:
                AddTshirt(women);
                break;
            case CholthingType.Dress:
                AddDress(women);
                break;
            case CholthingType.Jacket:
                AddJacket(women);
                break;
        }
        return women;
    }

    public static void AddTshirt(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "T-Shirt MU";
            System.Console.WriteLine("Women showing a T-Shirt MU.");
        }
    }

    public static void AddDress(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "Black Dress";
            System.Console.WriteLine("Women showing a Black Dress.");
        }
    }
    
    public static void AddJacket(IWomen women)
    {
        if (women is Women cocok)
        {
            cocok.Deco = "Jacket Dress";
            System.Console.WriteLine("Women showing a Jacket.");
        }
    }
}