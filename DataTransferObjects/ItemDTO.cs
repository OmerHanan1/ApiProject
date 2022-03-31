using System;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.DataTransferObjects
{
    public record ItemDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
