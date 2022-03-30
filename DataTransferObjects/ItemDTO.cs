using System.ComponentModel.DataAnnotations;

namespace ApiProject.DataTransferObjects
{
    public record ItemDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
