

using System.ComponentModel.DataAnnotations;

namespace cardPortal.Models
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public DateTime LoginDate { get; set; }

    }
}
