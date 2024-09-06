using System.ComponentModel.DataAnnotations;

namespace TechTask.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;
    }
}
