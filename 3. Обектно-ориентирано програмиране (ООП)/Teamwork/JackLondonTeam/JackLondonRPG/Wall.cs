using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class Wall : IAttackable, IDamageable, IDrawable
	{
        private string name;
        private int currHealth;
        public Stat<int> MaxHealth { get; private set; }
       
        public Wall(string name, int currHealth, Stat<int> maxHealth)
        {
            this.Name = name;
            this.CurrHealth = currHealth;
            this.MaxHealth = maxHealth;
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
                if (value < 0)
                {
                    throw new ArgumentException("Current health cannot be negative!");
                }
                this.currHealth = value;
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

            if (finalHealth>this.MaxHealth.CurrValue)
            {
                finalHealth = this.MaxHealth.CurrValue;
            }

            if (finalHealth<0)
            {
                finalHealth = 0;
            }

            this.currHealth = finalHealth;

            var events = new List<GameEvent>();

            events.Add(new DamageEvent(this, damage));

            return events;
		}

		public char[,] GetImage()
		{
            char[,] wall = new char[6, 3] { 
                                            { '|', ' ', '|' },
                                            { '|', ' ', '|' },
                                            { '|', ' ', '|' },
                                            { '|', ' ', '|' },
                                            { '|', ' ', '|' },
                                            { '|', ' ', '|' },                                                     
                                           };
            return wall;
		}
	}
}
