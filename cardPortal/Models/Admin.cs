﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cardPortal.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required, MaxLength(50)]
        public string AdminName { get; set; } = string.Empty;
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public int CompanyID { get; set; }
        public DateTime AddDate { get; set; }
        
    }
}
