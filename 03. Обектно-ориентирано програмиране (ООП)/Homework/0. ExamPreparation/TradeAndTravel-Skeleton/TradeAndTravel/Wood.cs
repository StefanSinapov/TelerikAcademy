using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
	public class Wood : Item
	{
		private const int GeneralWoodValue = 2;

		public Wood(string name, Location location = null)
			: base(name, GeneralWoodValue, ItemType.Wood, location)
		{

		}

		public override void UpdateWithInteraction(string interaction)
		{
			base.UpdateWithInteraction(interaction);
			switch (interaction)
			{
				case "drop":
					if (this.Value > 0)
					{
						this.Value--;
					}
					break;
				default:
					break;
			}
		}
	}
}
