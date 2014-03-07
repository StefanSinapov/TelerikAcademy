using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public abstract class NPC
    {
        private string name;
        private string job;

        public NPC(string name)
        {
            this.Name = name;
            this.Job = job;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Job
        {
            get
            {
                return this.job;
            }
            set
            {
                this.job = value;
            }
        }

		public abstract GameEvent ExecuteOperationForCannon(Cannon cannon);
		public abstract GameEvent ExecuteOperationForWall(Wall wall);
    }
}
