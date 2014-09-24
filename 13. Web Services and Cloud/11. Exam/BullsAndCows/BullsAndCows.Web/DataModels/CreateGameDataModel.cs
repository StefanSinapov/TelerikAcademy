namespace BullsAndCows.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameDataModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }
    }
}