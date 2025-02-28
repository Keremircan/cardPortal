using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int CompanyID { get; set; }

    }
}
