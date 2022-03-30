using ApiProject.DataTransferObjects;
using ApiProject.Models;
using System.Runtime.CompilerServices;

namespace ApiProject.Extensions
{
    public static class Extension // Static class
    {
        public static ItemDTO convert_to_DTO(this Item item) 
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
        }
    }
}
