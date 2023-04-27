public class Dealer
{
    private Deck _deck = new Deck();
    private Hand _hand = new Hand();

    public void ShuffleDeck()
    {
        _deck.Shuffle();
    }

    public void DealCards(Player[] players)
    {
        foreach (Player player in players)
        {
            Card card = _deck.DealCard();
            player.AddCardToHand(card);
        }

        Card dealerCard = _deck.DealCard();
        _hand.AddCard(dealerCard);

        foreach (Player player in players)
        {
            Card card = _deck.DealCard();
            player.AddCardToHand(card);
        }

        dealerCard = _deck.DealCard();
        dealerCard.FaceValue = "UNKNOWN";
        _hand.AddCard(dealerCard);
    }

    public void Play(Player[] players)
    {
        while (true)
        {
            bool allPlayersStand = true;

            foreach (Player player in players)
            {
                if (player.GetHand().GetTotalValue() < 21 && player.WantsToHit())
                {
                    Card card = _deck.DealCard();
                    player.AddCardToHand(card);
                    Console.WriteLine("{0} drew {1} of {2}", player.GetName(), card.FaceValue, card.Suit);
                    allPlayersStand = false;
                }
            }

            if (allPlayersStand)
            {
                break;
            }
        }

        Console.WriteLine("Dealer's turn:");

        while (_hand.GetTotalValue() < 17)
        {
            Card card = _deck.DealCard();
            _hand.AddCard(card);
            Console.WriteLine("Dealer drew {0} of {1}", card.FaceValue, card.Suit);
        }

        Console.WriteLine("Dealer stands.");
    }

    public string DetermineWinner(Player[] players)
    {
        string winner = "";
        int highestTotalValue = 0;

        foreach (Player player in players)
        {
            int totalValue = player.GetHand().GetTotalValue();

            if (totalValue > highestTotalValue && totalValue <= 21)
            {
                highestTotalValue = totalValue;
                winner = player.GetName();
            }
        }

        if (_hand.GetTotalValue() > highestTotalValue && _hand.GetTotalValue() <= 21)
        {
            winner = "Dealer";
        }

        return winner;
    }

    public void ShowHands(Player[] players)
    {
        Console.WriteLine("Dealer's hand:");

        foreach (Card card in _hand.GetCards())
        {
            Console.WriteLine("{0} of {1}", card.FaceValue, card.Suit);
        }

        Console.WriteLine();

        foreach (Player player in players)
        {
            Console.WriteLine("{0}'s hand:", player.GetName());

            foreach (Card card in player.GetHand().GetCards())
            {
                Console.WriteLine("{0} of {1}", card.FaceValue, card.Suit);
            }

            Console.WriteLine();
        }
    }
}



