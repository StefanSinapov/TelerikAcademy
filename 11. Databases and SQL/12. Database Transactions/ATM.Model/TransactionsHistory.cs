namespace ATM.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Ammount { get; set; }
    }
}