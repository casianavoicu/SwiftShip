using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Models
{
    public class BaseParcelModel
    {
        public int? Id { get; set; }

        public CustomerModel Customer { get; set; }

        public StageType StageType { get; set; }

        public string Address { get; set; } = string.Empty;
    }

    public class ParcelModel : BaseParcelModel
    {
        public Guid Identifier { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
