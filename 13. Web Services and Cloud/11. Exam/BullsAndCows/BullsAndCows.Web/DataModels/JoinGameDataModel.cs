namespace BullsAndCows.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class JoinGameDataModel
    {
        [Required]
        [MinLength(4), MaxLength(4)]
        public string Number { get; set; } 
    }
}