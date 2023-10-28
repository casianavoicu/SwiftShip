using SwiftShip.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwiftShip.Database.Entities
{
    public class Stage
    {
        [Key]
        public byte Id { get; set; }

        public StageType Description { get; set; }
    }
}
