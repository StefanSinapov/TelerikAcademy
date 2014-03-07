using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public class Merchant : NPC
    {
        private int pricePerRankCannon;
        private int pricePerRankWall;

        public Merchant(string name, int priceCannon, int priceWall)
			: base(name)
        {
            this.PricePerRankUpCannon = priceCannon;
            this.PricePerRankWall = priceWall;
        }


        public int PricePerRankUpCannon
        {
            get
            {
                return this.pricePerRankCannon;
            }
            set
            {
                this.pricePerRankCannon = value;
            }
        }


        public int PricePerRankWall
        {
            get
            {
                return this.pricePerRankWall;
            }
            set
            {
                this.pricePerRankWall = value;
            }
        }

        public void Upgrade(Stat<int> stat)
		{
			//wall.CurrHealth += (1 / 5) * (wall.MaxHealth);
			throw new NotImplementedException();
		}

		public override GameEvent ExecuteOperationForCannon(Cannon cannon)
		{
			this.Upgrade(cannon.Precision);
			this.Upgrade(cannon.Damage);
			return new UpgradeEvent<int>(cannon.Damage);
		}

		public override GameEvent ExecuteOperationForWall(Wall wall)
		{
			return new UpgradeEvent<int>(wall.MaxHealth);
		}
    }
}
