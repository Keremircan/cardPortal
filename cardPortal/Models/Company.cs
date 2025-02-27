using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace cardPortal.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Required, MaxLength(100)]
        public string CompanyName { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string CompanyAddress { get; set; } = string.Empty;
        public DateTime AddDate { get; set; }

        
    }
}
