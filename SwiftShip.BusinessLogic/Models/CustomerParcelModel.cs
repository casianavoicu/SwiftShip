namespace SwiftShip.BusinessLogic.Models
{
    public class CustomerParcelModel
    {
        public int Id { get; set; }
        public DateTime RegisteredDate { get; set; }

        public List<BaseStageModel> Stages { get; set; }
        public Guid Identifier { get; set; }
    }
}
