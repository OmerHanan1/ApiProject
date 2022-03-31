using ApiProject.DataTransferObjects;
using MediatR;
using System;

namespace ApiProject.Domains.Commands
{
    public class DeleteItemCommand:IRequest<ItemDTO>
    {
        public Guid Id { get; set; }
        public DeleteItemCommand(Guid id) 
        {
            Id = id;
        }
    }
}
