using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Boar : Animal, ICarnivore, IHerbivore
	{
		private const int DefaultBoarSize = 4;
		private const int DefaultBoarBiteSize = 2;
		public int BiteSize { get; private set; }

		public Boar(string name, Point position)
			: base(name, position, DefaultBoarSize)
		{
			this.BiteSize = DefaultBoarBiteSize;
		}

		public int TryEatAnimal(Animal animal)
		{
			if (animal != null)
			{
				if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
				{
					return animal.GetMeatFromKillQuantity();
				}
			}

			return 0;
		}

		public int EatPlant(Plant plant)
		{
			if (plant != null)
			{
				this.Size++;
				return plant.GetEatenQuantity(this.BiteSize);
			}

			return 0;
		}
	}
}
