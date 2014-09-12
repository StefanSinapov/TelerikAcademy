using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    class HullBreaker:ActiveSkill
    {
        private const int maxUses = 2;
        private const int damage = 3;
        public HullBreaker()
            : base("Hull Breaker", "Damages the enemy ship's health.", 2)
        {
            this.NumberOfUses = maxUses;
        }

        public override void Apply(object obj)
        {
            if (this.NumberOfUses > 0)
            {
                try
                {
                    object ob = ValidateItem(obj);
                    (ob as Ship).GetDamaged(damage);
                    this.NumberOfUses--;
                }
                catch (InvalidTargetException)
                {
                    Console.WriteLine("The object you have selected is not a ship.Select a ship!"); ;
                }
            }
            else
            {
                Console.WriteLine("You have already used up this skill."); ;
            }
        }

        public object ValidateItem(object obj)
        {
            if (obj is Ship)
            {
                return obj;
            }
            else
            {
                throw new InvalidTargetException("The target is not a ship");
            }
        }
    }
}
