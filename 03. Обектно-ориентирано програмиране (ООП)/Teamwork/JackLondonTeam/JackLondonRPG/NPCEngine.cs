using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
	public class NPCEngine
	{
		public List<GameEvent> GenerateNPC(NPC npc, Ship ship)
		{
			if(npc as Merchant != null) 
			{
				return this.ShowMenu("Upgrade",npc, ship);//been here
			}
			else if(npc as Repairman != null)
			{
				return this.ShowMenu("Repair", npc, ship);//been here
			}
			else 
			{
				throw new ArgumentException("Invalid npc object");
			}
		}

		
		private List<GameEvent> ShowMenu(string operation, NPC npc, Ship ship) 
		{
			List<GameEvent> gameEvents = new List<GameEvent>();

			Console.WriteLine(String.Format("1. {0} Cannon", operation));
			Console.WriteLine(String.Format("2. {0} Wall", operation));
			Console.WriteLine("3. Exit");

			while(true) {

				var input = Console.ReadLine();
				int choise;
				if(!int.TryParse(input, out choise))//been here
				{
					Console.WriteLine("Please enter number");
				}

				switch(choise)
				{
					case 1:
						var cannonIndex = this.GetEntityIndex("cannon");
						this.validateEntityIndex(cannonIndex,ship.Cannons.Count);//been here
 						gameEvents.Add(npc.ExecuteOperationForCannon(ship.Cannons.ElementAt(cannonIndex)));
						break;
					case 2: 
						var wallIndex = this.GetEntityIndex("wall");
						this.validateEntityIndex(wallIndex,ship.Walls.Count);//been here
						gameEvents.Add(npc.ExecuteOperationForWall(ship.Walls.ElementAt(wallIndex)));
						break;
					case 3:
						Environment.Exit(0);
						break;
				}
			}

			return gameEvents;
		}

		private void validateEntityIndex(int entityIndex, int len)
		{
			if(entityIndex >= len)
			{
				throw new Exception(String.Format("Invalid index. Please enter index between 0 and {0}", len));
			}
		}

		private int GetEntityIndex(string entity)
		{
			Console.WriteLine(String.Format("Enter the {0} number: ", entity));
			string line = Console.ReadLine();

			int entityNumber;
			if(!int.TryParse(line, out entityNumber))
			{
				Console.WriteLine("Please enter number");
			}

			return entityNumber;
		}
	}
}
