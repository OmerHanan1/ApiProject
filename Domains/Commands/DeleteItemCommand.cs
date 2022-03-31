using ApiProject.DataTransferObjects;
using MediatR;

namespace ApiProject.Domains.Commands
{
    public class DeleteItemCommand:IRequest<ItemDTO>
    {
        public int Id { get; set; }
        public DeleteItemCommand(int id) 
        {
            Id = id;
        }
    }
}
