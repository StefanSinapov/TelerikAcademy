namespace BullsAndCows.Web.DataModels
{
    public class JoinGameResultDataModel
    {
        public JoinGameResultDataModel(string result)
        {
            this.Result = result;
        }
        public string Result { get; set; } 
    }
}