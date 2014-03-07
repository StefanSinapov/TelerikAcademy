using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class GameEngine
	{
		static readonly Stat<int> defaultCannonPrecision = new Stat<int>("Precision", new List<int>
			{
				50, 60, 70, 80, 90, 100
			});
		static readonly Stat<int> defaultCannonDamage = new Stat<int>("Damage", new List<int>
			{
				3, 6, 9, 12, 15, 18
			});
		static readonly Stat<int> defaultWallHealth = new Stat<int>("Health", new List<int> 
			{
				5, 10, 15, 20, 25, 30, 35, 40, 45, 50
			});
		static readonly List<Cannon> defaultCannons = new List<Cannon>
			{
				new Cannon("DefaultCannon 0",defaultCannonDamage,defaultCannonPrecision),
				new Cannon("DefaultCannon 1",defaultCannonDamage,defaultCannonPrecision),
				new Cannon("DefaultCannon 2",defaultCannonDamage,defaultCannonPrecision),
				new Cannon("DefaultCannon 3",defaultCannonDamage,defaultCannonPrecision),
				new Cannon("DefaultCannon 4",defaultCannonDamage,defaultCannonPrecision),
			};
		static readonly List<Wall> defaultWalls = new List<Wall> 
			{
				new Wall("DefaultWall 0",defaultWallHealth.CurrValue,defaultWallHealth),
				new Wall("DefaultWall 1",defaultWallHealth.CurrValue,defaultWallHealth),
				new Wall("DefaultWall 2",defaultWallHealth.CurrValue,defaultWallHealth),
				new Wall("DefaultWall 3",defaultWallHealth.CurrValue,defaultWallHealth),
				new Wall("DefaultWall 4",defaultWallHealth.CurrValue,defaultWallHealth)
			};
		static readonly int defaultHealth = 100;
		static readonly Captain defaultCaptain = new Captain("DefaultCaptainName");
		//static readonly Ship defaultShip = new Ship("DefaultShipName", defaultCaptain, defaultHealth, defaultWalls, defaultCannons);
		static readonly int defaultCannonUpgradePrice = 10;
		static readonly int defaultWallUpgradePrice = 10;
		static readonly int defaultRepairPrice = 5;

		private Ship playerShip;

		public GameEngine(string shipName, string captainName)
		{
			playerShip = new Ship(shipName, new Captain(captainName), defaultHealth, defaultWalls, defaultCannons);
		}

		public void Run()
		{
			while (true)
			{
				ConsoleVisualizer.ClearScreen();

				ConsoleVisualizer.VisualizeShip(playerShip);

				var merchantChoice = new Merchant("Pesho", defaultCannonUpgradePrice, defaultWallUpgradePrice);
				var repairmanChoice = new Repairman("Gosho", defaultRepairPrice);
				var enemyShip = new Ship("DefaultShipName", defaultCaptain, defaultHealth, defaultWalls, defaultCannons);

				ConsoleVisualizer.VisualizeMerchant(merchantChoice);
				ConsoleVisualizer.VisualizeRepairman(repairmanChoice);

				int choice;

				do
				{
					choice = GetChoice();
				}
				while (!(choice < 4 && choice > 0));

				if (choice == 1)
				{
					var npcengine = new NPCEngine();
					npcengine.GenerateNPC(merchantChoice, playerShip);
				}

				if (choice == 2)
				{
					var npcengine = new NPCEngine();
					npcengine.GenerateNPC(repairmanChoice, playerShip);
				}

				if (choice == 3)
				{
					var battleEngine = new BattleEngine(playerShip);
					var currBattleState = battleEngine.MakeMove();

					while (true)
					{
						ConsoleVisualizer.VisualizeBattleState(currBattleState.FirstShip,currBattleState.SecondShip);
						if (currBattleState.FirstShip.CurrHealth <= 0 || currBattleState.SecondShip.CurrHealth <= 0) break;
					}

					if (currBattleState.FirstShip.CurrHealth < 0)
					{
						Console.WriteLine("You lost.");
						Console.ReadKey();
						return;
					}

					else
					{
						playerShip.CurrHealth = 5;

						for (int i = 0; i < playerShip.Walls.Count; ++i)
						{
							playerShip.Walls[i].CurrHealth = currBattleState.FirstShip.Walls[i].CurrHealth;
						}

						Console.WriteLine("You won.");
						Console.ReadKey();
					}
				}
			}
		}

		static int GetChoice()
		{
			Console.WriteLine("1.Go to merchant");
			Console.WriteLine("2.Go to repairman");
			Console.WriteLine("3.Go to battle");
			return int.Parse(Console.ReadLine());
		}
	}
}
