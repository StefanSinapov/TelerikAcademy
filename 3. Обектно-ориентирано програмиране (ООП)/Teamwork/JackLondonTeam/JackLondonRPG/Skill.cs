using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    public abstract class Skill
    {
        private string name;
        private string description;

        public Skill(string name, string description)
        {
            this.Name = name;
            this.Descripion = description;
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



        public abstract void Apply(object obj);


        public string Descripion 
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

    }
}
