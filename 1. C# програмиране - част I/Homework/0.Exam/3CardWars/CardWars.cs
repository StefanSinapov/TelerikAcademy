using System;
using System.Numerics;
class CardWars
{
	static void Main()
	{
		checked
		{
			int gamesInMatch = int.Parse(Console.ReadLine());
			const int cardInGame = 3;
			int gamesWonByPlayerOne = 0;
			int gamesWonByPlayerTwo = 0;
			BigInteger playerOneGlobalScore = 0;
			BigInteger playerTwoGlobalScore = 0;
			bool xCardByPlayerOne = false;
			bool xCardByplayerTwo = false;

			for (int i = 0; i < gamesInMatch; i++)
			{
				int playerOneLocalScore = 0;
				int playerTwoLocalScore = 0;
				for (int j = 0; j < cardInGame; j++)
				{
					string card = Console.ReadLine();
					switch (card)
					{
						case "A": playerOneLocalScore += 1;
							break;
						case "J": playerOneLocalScore += 11;
							break;
						case "Q": playerOneLocalScore += 12;
							break;
						case "K": playerOneLocalScore += 13;
							break;
						case "Z": playerOneGlobalScore *= 2;
							break;
						case "Y": playerOneGlobalScore -= 200;
							break;
						case "X": xCardByPlayerOne = true;
							break;
						default: playerOneLocalScore += (12 - int.Parse(card));
							break;
					}
				}
				for (int p = 0; p < cardInGame; p++)
				{
					string card = Console.ReadLine();
					switch (card)
					{
						case "A": playerTwoLocalScore += 1;
							break;
						case "J": playerTwoLocalScore += 11;
							break;
						case "Q": playerTwoLocalScore += 12;
							break;
						case "K": playerTwoLocalScore += 13;
							break;
						case "Z": playerTwoGlobalScore *= 2;
							break;
						case "Y": playerTwoGlobalScore -= 200;
							break;
						case "X": xCardByplayerTwo = true;
							break;
						default: playerTwoLocalScore += (12 - int.Parse(card));
							break;
					}
				}

				if (xCardByPlayerOne && xCardByplayerTwo)
				{
					playerOneGlobalScore += 50;
					playerTwoGlobalScore += 50;

					xCardByPlayerOne = false;
					xCardByplayerTwo = false;
				}
				else if (xCardByPlayerOne)
				{
					break;
				}
				else if (xCardByplayerTwo)
				{
					break;
				}

				if (playerOneLocalScore > playerTwoLocalScore)
				{
					playerOneGlobalScore += playerOneLocalScore;
					gamesWonByPlayerOne++;
				}
				else if (playerOneLocalScore < playerTwoLocalScore)
				{
					playerTwoGlobalScore += playerTwoLocalScore;
					gamesWonByPlayerTwo++;
				}
			}

			if (xCardByPlayerOne)
			{
				Console.WriteLine("X card drawn! Player one wins the match!");
			}
			else if (xCardByplayerTwo)
			{
				Console.WriteLine("X card drawn! Player two wins the match!");
			}
			else if (playerOneGlobalScore > playerTwoGlobalScore)
			{
				Console.WriteLine("First player wins!");
				Console.WriteLine("Score: {0}", playerOneGlobalScore);
				Console.WriteLine("Games won: {0}", gamesWonByPlayerOne);
			}
			else if (playerOneGlobalScore < playerTwoGlobalScore)
			{
				Console.WriteLine("Second player wins!");
				Console.WriteLine("Score: {0}", playerTwoGlobalScore);
				Console.WriteLine("Games won: {0}", gamesWonByPlayerTwo);
			}
			else if (playerOneGlobalScore == playerTwoGlobalScore)
			{
				Console.WriteLine("It's a tie!");
				Console.WriteLine("Score: {0}", playerOneGlobalScore);
			}
		}
	}
}

