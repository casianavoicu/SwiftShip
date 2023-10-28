using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftShip.Database.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [InverseProperty("Customer")]
        public Parcel Parcel { get; set; }
    }
}
