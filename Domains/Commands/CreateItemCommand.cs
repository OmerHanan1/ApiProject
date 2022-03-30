using ApiProject.DataTransferObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Domains.Commands
{
    public class CreateItemCommand:IRequest<ItemDTO>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
