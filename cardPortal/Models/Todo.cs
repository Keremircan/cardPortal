using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cardPortal.Models
{
    public class Todo
    {
        [Key]
        public int TodoID { get; set; }
        [Required(ErrorMessage = "Please type a task!")]
        public string Description { get; set; } = string.Empty;
        public int AdminID { get; set; }
    }
}
