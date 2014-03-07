using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public static class Opponent 
	{
		private const double percentage = 0.10;

		public static Ship GenerateShip(Ship playerShip)
		{
			var captain = GetOpponentCaptain(playerShip.Captain);

			int healthPercentage = (int)(playerShip.CurrHealth * percentage);
			var currHeath = RandomGenerator.Random.Next(playerShip.CurrHealth - healthPercentage
				, playerShip.CurrHealth + healthPercentage + 1);
			var listOfWalls = GetOpponentWalls(playerShip.Walls);
			var listOfCannons = GetOpponentCannons(playerShip.Cannons);

			//double playerMobility = (Stat<double>)playerShip.Mobility ;
			//Stat<int> mobility = RandomGenerator.Random.Next(playerShip.Mobility-(playerShip.Mobility*percentage)
			//	,playerShip.Mobility+(playerShip.Mobility*percentage)+1);

            //var mobility = playerShip.Mobility;

			return new Ship("Oponent", captain, currHeath, listOfWalls, listOfCannons);//been here and on the upper row
		}


		private static Captain GetOpponentCaptain(Captain playerCaptain)
		{
			//TODO: add private readonly list with captain names and choose one with random
			//maybe captain can have list of abilities
			//TODO: add random different skills for oponent

			return new Captain("Opponent captain");//been here
		}

		private static List<Wall> GetOpponentWalls(List<Wall> playerWalls)
		{
			List<Wall> listOfWalls = new List<Wall>();
			int i = 0;
			foreach (var wall in playerWalls)
			{
				int wallCurrHeath = RandomGenerator.Random.Next(wall.CurrHealth - (int)(wall.CurrHealth * percentage), wall.CurrHealth + (int)(wall.CurrHealth * percentage));
				listOfWalls.Add(new Wall("ow" + i, wallCurrHeath, wall.MaxHealth.Clone() as Stat<int>));
			}

			return listOfWalls;
		}

		private static List<Cannon> GetOpponentCannons(List<Cannon> playerCannons)
		{
			List<Cannon> listOfCannons = new List<Cannon>();
			int i = 0;
			foreach (var cannon in playerCannons)
			{
				//TODO: add stats 

				var opponentPrecision = cannon.Precision;
				var opponentDamage = cannon.Damage;
				listOfCannons.Add(new Cannon("oc" + i, opponentDamage, opponentPrecision));
			}

			return listOfCannons;
		}
	}
}
