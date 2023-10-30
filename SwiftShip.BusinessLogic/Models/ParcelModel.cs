using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwiftShip.BusinessLogic.Models
{
    public class ParcelModel
    {
        public int? Id { get; set; }

        public CustomerModel Customer { get; set; }

        public StageType StageType { get; set; }

        [Required]
        public string Address { get; set; }

        public Guid Identifier { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
