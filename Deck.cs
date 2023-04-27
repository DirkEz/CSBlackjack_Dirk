public class Deck
{
    private List<Card> _cards = new List<Card>();

    public Deck()
    {
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] faceValues = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            for (int i = 0; i < faceValues.Length; i++)
            {
                int value = i + 1;

                if (i >= 9)
                {
                    value = 10;
                }
                if (i == 0)
                {
                    value = 11;
                }

                Card card = new Card(suit, faceValues[i], value);
                _cards.Add(card);
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();

        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            Card temp = _cards[i];
            _cards[i] = _cards[j];
            _cards[j] = temp;
        }
    }

    public Card DealCard()
    {
        Card card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }
}
