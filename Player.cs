public class Player
{
    private Hand _hand = new Hand();
    private string _name;

    public Player(string name)
    {
        _name = name;
    }

    public void AddCardToHand(Card card)
    {
        _hand.AddCard(card);
    }

    public bool WantsToHit()
    {
        Console.Write("{0}, do you want to hit (y/n)? ", _name);
        string input = Console.ReadLine();

        return input.ToLower() == "y";
    }

    public Hand GetHand()
    {
        return _hand;
    }

    public string GetName()
    {
        return _name;
    }
}
