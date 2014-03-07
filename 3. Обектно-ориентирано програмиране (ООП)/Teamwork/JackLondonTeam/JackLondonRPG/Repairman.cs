using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public class Repairman : NPC
    {
        private int pricePerPointRepair;

        public Repairman(string name, int price)
			: base(name)
        {
            this.PricePerPointRepair = price;
        }

        public int PricePerPointRepair
        {
            get
            {
                return this.pricePerPointRepair;
            }
            set
            {
                this.pricePerPointRepair = value;
            }
        }

		public override GameEvent ExecuteOperationForCannon(Cannon cannon)
		{
			cannon.Damage.RankChange(1);
            return new UpgradeEvent<int>(cannon.Damage);
		}

		public override GameEvent ExecuteOperationForWall(Wall wall)
		{
            wall.MaxHealth.RankChange(1);
            return new UpgradeEvent<int>(wall.MaxHealth);
		}
    }
}
