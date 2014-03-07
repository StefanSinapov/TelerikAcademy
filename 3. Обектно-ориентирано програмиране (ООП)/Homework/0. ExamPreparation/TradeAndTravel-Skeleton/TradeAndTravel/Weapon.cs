using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
	public class Weapon : Item
	{
		private const int GeneralWeaponValue = 10;

		public Weapon(string name, Location location = null)
			: base(name, GeneralWeaponValue, ItemType.Weapon, location)
		{

		}

		static List<ItemType> GetComposingItems()
		{
			return new List<ItemType>() { ItemType.Iron , ItemType.Wood };
		}
	}
}
