using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechTask.Models
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? OriginalURL { get; set; }

        [Required]
        public string? Code {  get; set; }

        [Required]
        public string? ShortURL { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public UserModel? CreatedBy { get; set; }
        
        [Required]
        public DateTime? CreatedDate { get; set; }
    }
}
