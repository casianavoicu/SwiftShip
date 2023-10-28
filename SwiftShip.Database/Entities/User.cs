using System.ComponentModel.DataAnnotations;

namespace SwiftShip.Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; } 
    }
}
