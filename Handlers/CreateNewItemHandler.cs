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
        private readonly LoaclAndExternalRepoInterface _repository;
        public CreateNewItemHandler(LoaclAndExternalRepoInterface loaclAndExternalRepoInterface) 
        {
            _repository = loaclAndExternalRepoInterface;
        }


        public async Task<ItemDTO> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {

            Item _i = new()
            {
                Name = request.Name,
                Description = request.Description
            };
            _repository.CreateNewItem(_i);
            return _i.convert_to_DTO();
        }

        private ItemDTO CreatedAtAction(string v, object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }
}
