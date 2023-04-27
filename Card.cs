public class Card
{
    public string Suit { get; set; }
    public string FaceValue { get; set; }
    public int Value { get; set; }

    public Card(string suit, string faceValue, int value)
    {
        Suit = suit;
        FaceValue = faceValue;
        Value = value;
    }
}
