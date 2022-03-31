using ApiProject.DataTransferObjects;
using ApiProject.Domains.Commands;
using ApiProject.Extensions;
using ApiProject.Models;
using ApiProject.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Handlers
{
    public class CreateNewItemHandler : IRequestHandler<CreateItemCommand, ItemDTO>
    {
        private readonly ILocalAndExternalRepo _repository;
        public CreateNewItemHandler(ILocalAndExternalRepo loaclAndExternalRepoInterface) 
        {
            // DI in ctor
            _repository = loaclAndExternalRepoInterface;
        }


        public async Task<ItemDTO> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {

            Item _i = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };
            _repository.CreateNewItem(_i);
            return _i.convert_to_DTO();
        }
    }
}
