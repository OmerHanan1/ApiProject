using ApiProject.Models;
using System;
using System.Collections.Generic;

namespace ApiProject.Repositories
{
    public interface ILocalAndExternalRepo
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateNewItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}