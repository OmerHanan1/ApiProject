using ApiProject.DataTransferObjects;
using ApiProject.Domains.Queries;
using ApiProject.Extensions;
using ApiProject.Models;
using ApiProject.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Handlers
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemDTO>>
    {
        private readonly LoaclAndExternalRepoInterface _repository;

        public GetItemsHandler(LoaclAndExternalRepoInterface localMemoryItemsRepo)
        {
            // DI in ctor
            _repository = localMemoryItemsRepo;
        }

        public async Task<IEnumerable<ItemDTO>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var itemslist = _repository.GetItems().Select(i => i.convert_to_DTO());
            return itemslist;
        }
    }
}
