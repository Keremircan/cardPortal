using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace cardPortal.Models
{
    public class Personnel
    {
        [Key]
        public int CardID { get; set; }
        public int? CardNo { get; set; }
        [Required]
        public int RollId { get; set; }
        [Required,MaxLength(50)]
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Type just letter!")]
        public string FullName { get; set; } = string.Empty;
        [Required,MaxLength(70)]
        public string Company { get; set; } = string.Empty;
        [Required]
        public int CompanyId { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{9,14}$", ErrorMessage = "Phone number is valid. '0' shouldn't be in beginning!")]
        public string MobileNumber { get; set; } = string.Empty;
        public string? PhoneNumber2 { get; set; } = string.Empty;
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%_*?&])[A-Za-z\d@$!%_*?&]{8,}$",
        ErrorMessage = "least 8 characters, include a letter, a number,a special character!")]
        public string Password { get; set; } = string.Empty;
        public string? JobTitle { get; set; } = string.Empty;
        public string? WorkAddress { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public DateTime AddDate { get; set; }
        public DateTime? UpdDate { get; set; }

    }
}
