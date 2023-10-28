using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Models
{
    public class ParcelModel
    {
        public string Id { get; set; }

        public string Address { get; set; }

        public CustomerModel Customer { get; set; }

        public StageType StageType { get; set; }
    }
}
