using DecoratePattern;

public class Program
{
    static void Main(string[] args)
    {
        IWomen sarah = new Women("Sarah", 170);

        //calling the Show method without decoration
        sarah.Show();
        System.Console.WriteLine(sarah + "\n");

        //Adding decoration
        HairDecorator hairDecorator = new HairDecorator(sarah);
        hairDecorator.Show();
        System.Console.WriteLine();

        //Adding more decoration
        ClothingDecorator clothingDecorator = new ClothingDecorator(sarah, ClothingDecorator.CholthingType.Jacket);
        clothingDecorator.Show();
        System.Console.WriteLine();

        //Adding more decoration
        AccessoriesDecorator accessoriesDecorator = new AccessoriesDecorator(sarah);
        accessoriesDecorator.Show();
        System.Console.WriteLine();
    }
}
