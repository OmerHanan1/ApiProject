using ApiProject.DataTransferObjects;
using MediatR;
using System;

namespace ApiProject.Domains.Commands
{
    public class UpdateItemCommand:IRequest<ItemDTO>
    {
        public Guid id { get; set; }
        public ItemDTO item { get; set; }

        public UpdateItemCommand(Guid id, ItemDTO item)
        {
            this.id = id;
            this.item = item;

        }
    }
}
