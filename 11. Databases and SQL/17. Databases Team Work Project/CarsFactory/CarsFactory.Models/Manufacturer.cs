namespace CarsFactory.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class Manufacturer
    {
        private ICollection<Expense> expenses;

        public Manufacturer()
        {
            this.expenses = new HashSet<Expense>();
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses
        {
            get
            {
                return this.expenses;
            }
            set
            {
                this.expenses = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
