using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.Repositories
{
    public interface ILocalAndExternalRepo
    {
        Item GetItem(int id);
        IEnumerable<Item> GetItems();
        void CreateNewItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}