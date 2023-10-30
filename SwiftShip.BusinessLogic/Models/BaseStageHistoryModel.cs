using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Models
{
    public class BaseStageHistoryModel
    {
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public StageType Stage { get; set; }
    }
}
