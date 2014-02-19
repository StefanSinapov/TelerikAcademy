using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalFarm
{
	public class Dog : Animal, ISound
	{
		public Dog(string name, byte age, Gender sex)
			: base(name, age, sex)
		{
 
		}
		public override string Sound()
		{
			return string.Format("Dog: djaf-djaf");
		}
	}
}
