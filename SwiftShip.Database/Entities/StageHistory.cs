using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SwiftShip.Database.Entities
{
    public class StageHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        [NotNull]
        public Stage Stage { get; set; }

        public string Address { get; set; }
    }
}
