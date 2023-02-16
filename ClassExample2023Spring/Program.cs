using ClassExample2023Spring;

Deck myDeck = new Deck();

Console.Write("Enter your name: ");

Player currentPlayer = new(Console.ReadLine()!);

currentPlayer.Hand.Cards = myDeck.DealCards(5);
currentPlayer.ShowHand();

Console.WriteLine($"Player has Ace in Hand? {currentPlayer.CheckForRank("A")}" );
Console.WriteLine($"Player has a pair? {currentPlayer.Hand.CheckForPairs()}");




