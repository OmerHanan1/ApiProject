using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject.Repositories
{
    public class LocalMemoryItemsRepo : LoaclAndExternalRepoInterface
    {
        private readonly List<Item> _items = new()
        {
            new Item { Name = "First", Description = "First item" },
            new Item { Name = "Second", Description = "Second item" },
            new Item { Name = "Third", Description = "Third item" },
            new Item { Name = "Fourth", Description = "Fourth item" },
            new Item { Name = "Fifth", Description = "Fifth item" }
        };

        /// <summary>
        /// Returns all the items in the repository
        /// </summary>
        /// <returns>List of Item type objects</returns>
        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
        /// <summary>
        /// Returns specific item using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Item type object</returns>
        public Item GetItem(int id)
        {
            return _items.Where(i => i.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Creates new item in repository
        /// </summary>
        /// <param name="item"></param>
        public void CreateNewItem(Item item) 
        {
            _items.Add(item);
        }

        /// <summary>
        /// Updateing existing item in the repository
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Item item)
        {
            var index = _items.FindIndex(exist => exist.Id == item.Id);
            _items[index] = item;
        }

        /// <summary>
        /// Deletes item from repository by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            var index = _items.FindIndex(exist => exist.Id == id);
            _items.RemoveAt(index);
        }
    }
}
