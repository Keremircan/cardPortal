using System.ComponentModel.DataAnnotations;

namespace cardPortal.Models
{
    public class Change
    {
        [Key]
        public int ChangeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime ChangeTime { get; set; }
    }
}
