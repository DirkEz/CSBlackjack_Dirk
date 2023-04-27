class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack!");

        Dealer dealer = new Dealer();
        Player[] players = GetPlayers();
        dealer.ShuffleDeck();
        dealer.DealCards(players);
        dealer.ShowHands(players);
        dealer.Play(players);
        dealer.ShowHands(players);
        string winner = dealer.DetermineWinner(players);

        if (winner == "")
        {
            Console.WriteLine("It's a tie!");
        }
        else
        {
            Console.WriteLine("{0} wins!", winner);
        }
        System.Threading.Thread.Sleep(500);
        Console.Clear();
        
    }

    static Player[] GetPlayers()
    {
        Console.Write("Enter the number of players: ");
        int numberOfPlayers = int.Parse(Console.ReadLine());
        Player[] players = new Player[numberOfPlayers];

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.Write("Enter player {0}'s name: ", i + 1);
            string playerName = Console.ReadLine();
            players[i] = new Player(playerName);
        }

        return players;
    }
}
