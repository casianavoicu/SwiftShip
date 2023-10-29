using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftShip.Database.Entities
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime EndDate { get; set; }

        [InverseProperty("Parcel")]
        public ICollection<StageHistory> StageHistory { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Parcel")]
        public Customer Customer { get; set; } 

        public int CustomerId { get; set; }
    }
}
