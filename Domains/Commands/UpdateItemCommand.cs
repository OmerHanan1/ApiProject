using ApiProject.DataTransferObjects;
using MediatR;

namespace ApiProject.Domains.Commands
{
    public class UpdateItemCommand:IRequest<ItemDTO>
    {
        public int id { get; set; }
        public ItemDTO item { get; set; }

        public UpdateItemCommand(int id, ItemDTO item)
        {
            this.id = id;
            this.item = item;

        }
    }
}
