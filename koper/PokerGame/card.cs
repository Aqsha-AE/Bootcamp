


class Cardtu
{
    public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum CardValue
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack = 11,
    Queen = 12,
    King = 13,
    Ace = 14
}

public class Card
{
    public Suit Suit { get; }
    public CardValue Value { get; }

    public Card(Suit suit, CardValue value)
    {
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}
    static void Main(string[] args)
    {
        Card myCard = new Card(Suit.Hearts, CardValue.Ace);
        Console.WriteLine(myCard.ToString());
    }
}
