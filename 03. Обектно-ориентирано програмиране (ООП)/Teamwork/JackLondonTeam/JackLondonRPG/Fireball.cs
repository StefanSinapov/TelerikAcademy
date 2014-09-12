using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public class Fireball:ActiveSkill
    {
        private const int maxUses = 2;
        private const int damage = 3;
        public Fireball()
            : base("Fireball", "Damages a specific wall", 2)
        {
            this.NumberOfUses = maxUses;
        }

        public override void Apply(object obj)
        {
            if (this.NumberOfUses>0)
            {
                try
                {
                    object ob=ValidateItem(obj);
                    (ob as Wall).GetDamaged(damage);
                    this.NumberOfUses--;
                }
                catch(InvalidTargetException)
                {
                    Console.WriteLine("The object you have selected is not a wall.Select a wall!"); ; 
                }
            }
            else
            {
                Console.WriteLine("You have already used up this skill."); ;
            }
        }

        public object ValidateItem(object obj)
        {
            if(obj is Wall)
            {
                return obj;
            }
            else
            {
                throw new InvalidTargetException("The target is not a wall");
            }
        }

    }
}
