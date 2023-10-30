using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftShip.Database.Entities
{
    public class StageHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("StageId")]
        public Stage Stage { get; set; }

        public string Address { get; set; }

        public int StageId { get; set; }

        public int ParcelId { get; set; }

        [ForeignKey("ParcelId")]
        [InverseProperty("StageHistory")]
        public Parcel Parcel { get; set; }
    }
}
