/*
 * Suppose you are creating a simple engine for an ATM machine. 
 * Create a new database "ATM" in SQL Server to hold the accounts
 * of the card holders and the balance (money) for each account. 
 * Add a new table CardAccounts with the following fields: 
		Id (int)
		CardNumber (char(10))
		CardPIN (char(4))
		CardCash (money)
	Add a few sample records in the table.
 */
namespace ATM.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        [Index(IsUnique = true)]
        public string CardNumber { get; set; }

        [StringLength(4)]
        [Required]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
