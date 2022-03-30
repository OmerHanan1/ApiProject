using ApiProject.DataTransferObjects;
using MediatR;

namespace ApiProject.Domains.Queries
{
    public class GetItemByIdQuery: IRequest<ItemDTO>
    {
        public int Id { get; set; }

        public GetItemByIdQuery(int id) 
        { 
            this.Id = id;
        }
    }
}
