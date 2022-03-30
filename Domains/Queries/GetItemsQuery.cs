using ApiProject.DataTransferObjects;
using ApiProject.Models;
using MediatR;
using System.Collections.Generic;

namespace ApiProject.Domains.Queries
{
    public class GetItemsQuery :IRequest<IEnumerable<ItemDTO>>
    {
    }
}
