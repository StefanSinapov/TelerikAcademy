using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public abstract class ActiveSkill:Skill
    {
        private int numberOfUses;

        public ActiveSkill(string name, string description, int numberOfUses):base(name, description)
        {
            this.NumberOfUses = numberOfUses;
        }

        public int NumberOfUses
        {
            get
            {
                return this.numberOfUses;
            }
            protected set
            {
                this.numberOfUses= value;
            }
        }

        public override void Apply(object obj)
        {
        }

    }
}
