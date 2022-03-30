using System.ComponentModel.DataAnnotations;

namespace ApiProject.Models
{
    public record Item
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
