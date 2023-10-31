using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Models
{
    public class ParcelStageModel
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }

        public StageType Stage { get; set; }

        public string Address { get; set; }
    }
}
