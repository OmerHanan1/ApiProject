using ApiProject.DataTransferObjects;
using ApiProject.Domains.Queries;
using ApiProject.Extensions;
using ApiProject.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Handlers
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ItemDTO>
    {
        private readonly ILocalAndExternalRepo _repository;

        public GetItemByIdHandler(ILocalAndExternalRepo localAndExternalRepoInterface) 
        {
            // DI in ctor
            _repository = localAndExternalRepoInterface;
        }

        public async Task<ItemDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = _repository.GetItem(request.Id);
            if (item == null) { return null; }
            return item.convert_to_DTO();
        }
    }
}
