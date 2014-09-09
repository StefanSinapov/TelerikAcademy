namespace CarsFactory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Month
    {
        private ICollection<Expense> expenses;

        public Month()
        {
            this.expenses = new HashSet<Expense>();
        }

        [Key]
        public int MonthId { get; set; }

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
    }
}
