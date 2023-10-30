namespace SwiftShip.BusinessLogic.Models
{
    public class CustomerParcelModel
    {
        public int Id { get; set; }
        public DateTime RegisteredDate { get; set; }

        public List<BaseStageHistoryModel> Stages { get; set; }
        public Guid Identifier { get; set; }
    }
}
