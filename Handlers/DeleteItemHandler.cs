using ApiProject.DataTransferObjects;
using ApiProject.Domains.Commands;
using ApiProject.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Handlers
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, ItemDTO>
    {
        private readonly LoaclAndExternalRepoInterface _repository;

        public DeleteItemHandler(LoaclAndExternalRepoInterface loaclAndExternalRepoInterface) 
        {
            // DI in ctor
            _repository = loaclAndExternalRepoInterface;
        }

        public async Task<ItemDTO> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            ItemDTO item = new ItemDTO();
            item.Id = request.Id;
            item.Description = request.ToString();
            var existingItem = _repository.GetItem(request.Id);
            if (existingItem == null) { return null; }
            _repository.DeleteItem(request.Id);

            return item;
        }
    }
}
