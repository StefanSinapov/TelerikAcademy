using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Power
{
    public class Battery : IRechargable
    {
        public const byte MaxCharge = 100;
        public const byte MinCharge = 0;

        private int currentCharge;

        public Battery()
        {
            this.CurrentCharge = MaxCharge / 2;
        }

        public int CurrentCharge
        {
            get
            {
                return this.currentCharge;
            }

            private set
            {
                if (value > MaxCharge)
                {
                    value = MaxCharge;
                }

                if (value < MinCharge)
                {
                    value = MinCharge;
                }

                this.currentCharge = value;
            }
        }

        public void Charge(int powerInput)
        {
            this.CurrentCharge += powerInput;
        }
    }
}
