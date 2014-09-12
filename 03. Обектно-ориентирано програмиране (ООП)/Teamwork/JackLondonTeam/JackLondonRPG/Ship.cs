using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class Ship : IAttackable, IDamageable, IDrawable
	{
        private string name;
        private Captain captain;
        private int currHealth;
        private IList<Wall> wall;
        private IList<Cannon> cannon;
        public Stat<int> MaxHealth { get; set; }

        public Ship(string name, Captain captain, int currHealth, List<Wall> wall, List<Cannon> cannon)
        {
            this.Name = name;
            this.Captain = captain;
            this.CurrHealth = currHealth;
            this.Walls = new List<Wall>(wall);
            this.Cannons = new List<Cannon>(cannon);
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be empty or null!");
                }
                this.name = value;
            }
        }

        public int CurrHealth
        {
            get
            {
                return this.currHealth;
            }

            set
            {
                this.currHealth = value;
            }
        }

        public Captain Captain
        {
            get
            {
                return this.captain;
            }

            private set
            {
                this.captain = value;
            }
        }

        //public Stat<int> Mobility
        //{
        //    get
        //    {
        //        return this.mobility;
        //    }

        //    private set
        //    {
        //        this.mobility = value;
        //    }
        //}

		public List<Cannon> Cannons
		{
			get
			{
                return new List<Cannon>();
			}

			private set
			{
                this.cannon = value;
			}
		}

		public List<Wall> Walls
		{
			get
			{
				return new List<Wall>();
			}

			private set
			{
                this.wall = value;
			}
		}

		public IEnumerable<GameEvent> GetAttacked(IAttacker attacker)
		{
            List<GameEvent> events = new List<GameEvent>();
            events.Add(new AttackEvent(attacker, this, true));
            events.Add(GetDamaged(attacker.GetDamage()).First());

            return events;
		}  

        public IEnumerable<GameEvent> GetDamaged(int damage)
        {
            int finalHealth = currHealth - damage;

            if (finalHealth > MaxHealth.CurrValue)
            {
                finalHealth = MaxHealth.CurrValue;
            }

            if (finalHealth < 0)
            {
                finalHealth = 0;
            }

            currHealth = finalHealth;
            List<GameEvent> events = new List<GameEvent>();
            events.Add(new DamageEvent(this, damage));
            return events;
        }

		public char[,] GetImage()
		{
            char[,] ship = new char[6, 3] { 
                                            { '#', '#', '#' },
                                            { '#', 'S', '#' },
                                            { '#', 'H', '#' },
                                            { '#', 'I', '#' },
                                            { '#', 'P', '#' },
                                            { '#', '#', '#' },                                                     
                                           };
            return ship;
		}
	}
}
