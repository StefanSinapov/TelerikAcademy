using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Wolf : Animal, ICarnivore
	{
		private const int DefaultWolfSize = 4;

		public Wolf(string name, Point position)
			: base(name, position, DefaultWolfSize)
		{

		}

		//public override void Update(int timeElapsed)
		//{
		//	if (this.State == AnimalState.Sleeping)
		//	{
		//		if (timeElapsed >= sleepRemaining)
		//		{
		//			this.Awake();
		//		}
		//		else
		//		{
		//			this.sleepRemaining -= timeElapsed;
		//		}
		//	}

		//	base.Update(timeElapsed);
		//}

		

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
	}
}
