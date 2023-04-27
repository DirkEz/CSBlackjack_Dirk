public class Hand
{
    private List<Card> _cards = new List<Card>();

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public int GetTotalValue()
    {
        int totalValue = 0;
        int numberOfAces = 0;

        foreach (Card card in _cards)
        {
            if (card.Value == 11)
            {
                numberOfAces++;
            }

            totalValue += card.Value;
        }

        while (numberOfAces > 0 && totalValue > 21)
        {
            totalValue -= 10;
            numberOfAces--;
        }

        return totalValue;
    }

    public List<Card> GetCards()
    {
        return _cards;
    }
}
