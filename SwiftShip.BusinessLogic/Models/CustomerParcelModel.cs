namespace SwiftShip.BusinessLogic.Models
{
    public class CustomerParcelModel
    {
        public string? Id { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<BaseStageModel> Stages { get; set; }
    }
}
