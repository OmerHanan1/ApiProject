using System.ComponentModel.DataAnnotations;

namespace ApiProject.DataTransferObjects
{
    public record CreateItemDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
