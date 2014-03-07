using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    class FortifyPrecision:PassiveSkill
    {
        private const int rankIncrease = 1;
        public FortifyPrecision()
            : base("Fortify Precision", "Increases the precision of all your cannons.")
        {
        }

        public override void Apply(object obj)
        {
            try
            {
                object ob = ValidateItem(obj);
                var cannons = (ob as Ship).Cannons;
                foreach (var cannon in cannons)
                {
                    cannon.Precision.RankChange(rankIncrease);
                }
            }
            catch (InvalidTargetException)
            {
                Console.WriteLine("The object you have selected is not a ship. Select a ship!"); ;
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
