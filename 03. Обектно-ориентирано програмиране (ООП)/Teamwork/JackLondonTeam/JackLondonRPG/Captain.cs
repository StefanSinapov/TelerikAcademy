using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class Captain :IIdentifiable
	{      

        public string Name
        {
            get
            {
                return this.Name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be empty or null!");
                }
                this.Name = value;
            }
        }
        public List<Skill> Abilities { get; set; }

        public Captain(string name)
        {
            this.Name = name;
            Abilities = new List<Skill>();
        }

        public void UseAbility(int skillIndex, object target)
        {
            Abilities[skillIndex].Apply(target);
        }
    }
}
