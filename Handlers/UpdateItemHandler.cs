using ApiProject.DataTransferObjects;
using ApiProject.Domains.Commands;
using ApiProject.Extensions;
using ApiProject.Models;
using ApiProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Handlers
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, ItemDTO>
    {
        private readonly ILocalAndExternalRepo _repository;

        public UpdateItemHandler(ILocalAndExternalRepo loaclAndExternalRepoInterface) 
        {
            // DI in ctor
            _repository = loaclAndExternalRepoInterface;
        }

        public async Task<ItemDTO> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var existingItem = _repository.GetItem(request.id);
            if (existingItem == null) { return null; }
            Item updatedItem = existingItem with
            {
                Name = request.item.Name,
                Description = request.item.Description
            };
            _repository.UpdateItem(updatedItem);
            return updatedItem.convert_to_DTO();
        }
    }
}
