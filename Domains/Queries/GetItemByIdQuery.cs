using ApiProject.DataTransferObjects;
using MediatR;
using System;

namespace ApiProject.Domains.Queries
{
    public class GetItemByIdQuery: IRequest<ItemDTO>
    {
        public Guid Id { get; set; }

        public GetItemByIdQuery(Guid id) 
        { 
            this.Id = id;
        }
    }
}
