using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
	public class AdvancedInteractionManager : InteractionManager
	{
		public AdvancedInteractionManager()
			: base()
		{ }

		protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
		{
			switch (itemTypeString)
			{

				case "weapon":
					item = new Weapon(itemNameString, itemLocation);
					break;
				case "wood":
					item = new Wood(itemNameString, itemLocation);
					break;
				case "iron":
					item = new Iron(itemNameString, itemLocation);
					break;
				default:
					return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
			}
			return item;
		}

		protected override Location CreateLocation(string locationTypeString, string locationName)
		{
			Location location = null;
			switch (locationTypeString)
			{
				case "mine":
					location = new Mine(locationName);
					break;
				case "forest":
					location = new Forest(locationName);
					break;
				default:
					return base.CreateLocation(locationTypeString, locationName);
			}
			return location;
		}

		protected override void HandlePersonCommand(string[] commandWords, Person actor)
		{
			switch (commandWords[1])
			{
				case "gather":
					HandleGatherInteraction(actor, commandWords[2]);
					break;
				case "craft":
					HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
					break;
				default:
					base.HandlePersonCommand(commandWords, actor);
					break;
			}
		}

		protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
		{
			Person person = null;
			switch (personTypeString)
			{
				case "merchant":
					person = new Merchant(personNameString, personLocation);
					break;
				default:
					return base.CreatePerson(personTypeString, personNameString, personLocation);
			}
			return person;
			
		}

		private void HandleCraftInteraction(Person actor, string craftedItemType, string craftedItemName)
		{


			switch (craftedItemType)
			{
				case "armor":
					this.CraftArmor(actor, craftedItemName);
					break;
				case "weapon":
					this.CraftWeapon(actor, craftedItemName);
					break;
				default:
					break;
			}
		}

		private void CraftWeapon(Person actor, string craftedItemName)
		{
			var actorInventory = actor.ListInventory();
			bool haveIron = actorInventory.Any((item) => item.ItemType == ItemType.Iron);
			bool haveWood = actorInventory.Any((item) => item.ItemType == ItemType.Wood);
			if (haveIron && haveWood)
			{
				this.AddToPerson(actor, new Weapon(craftedItemName));
			}
		}

		private void CraftArmor(Person actor, string craftedItemName)
		{

			var actorInventory = actor.ListInventory();
			bool haveIron = actorInventory.Any((item) => item.ItemType == ItemType.Iron);

			if (haveIron)
			{
				this.AddToPerson(actor, new Armor(craftedItemName));
			}
		}

		private void HandleGatherInteraction(Person actor, string gatheredItemName)
		{
			var gatheringLocation = actor.Location as IGatheringLocation;
			if (gatheringLocation != null)
			{
				bool haveRequiredItem = actor.ListInventory().Any(
											(item) => item.ItemType == gatheringLocation.RequiredItem);
				if (haveRequiredItem)
				{
					var producedItem = gatheringLocation.ProduceItem(gatheredItemName);
					this.AddToPerson(actor, producedItem);
				}

				//foreach (var item in actor.ListInventory())
				//{
				//	if (item.ItemType == gatheringLocation.RequiredItem)
				//	{
				//		var producedItem = gatheringLocation.ProduceItem(gatheredItemName);
				//		//actor.AddToInventory(producedItem);
				//		this.AddToPerson(actor, producedItem);
				//		break;
				//	}
				//}
			}
		}

	}
}
