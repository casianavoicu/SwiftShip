using System.ComponentModel.DataAnnotations;

namespace SwiftShip.Database.Entities
{
    public class Parcel
    {
        [Key]
        public string? Id { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<StageHistory>? StageHistory { get; set; }

        public Customer Customer { get; set; } 
    }
}
