using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public abstract class PassiveSkill : Skill
    {

        public PassiveSkill(string name,string description):base(name,description)
        {
        }

        public override void Apply(object obj)
        {
        }
    }
}
