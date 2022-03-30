using ApiProject.Models;
using ApiProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ApiProject.DataTransferObjects;
using System.Linq;
using ApiProject.Extensions;

namespace ApiProject.Controllers
{
    [ApiController] 
    [Route("[Controller]")] // Optional
    public class ItemsController : ControllerBase
    {

        private readonly ILocalMemoryItemsRepo _repository;

        public ItemsController(ILocalMemoryItemsRepo repo) 
        {
            this._repository = repo; // DI
        }

        /// <summary>
        /// GET query: returns all the listed items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems() 
        {
            var itemslist = _repository.GetItems().Select( i => i.convert_to_DTO());
            return itemslist;
        }

        /// <summary>
        /// GET query: returns onr item details by given id
        /// </summary>
        /// <param name="id">Item key</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(int id) 
        {
            var item = _repository.GetItem(id);
            if (item == null) { return NotFound(); }
            return item.convert_to_DTO();
        }

        /// <summary>
        /// POST command: Creates a new Item and post it into the repository
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ItemDTO> CreateNewItem(CreateItemDTO item) 
        {
            Item _i = new()
            {
                Name = item.Name,
                Description = item.Description
            };
            _repository.CreateNewItem(_i);
            // By convergence, HttpPost command returns the created object
            return CreatedAtAction(nameof(GetItem), new { id = _i.Id }, _i.convert_to_DTO());
        }

        /// <summary>
        /// PUT command: update existing item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, Item item) 
        {
            var existingItem = _repository.GetItem(id) as Item;
            if (existingItem == null) { return NotFound(); }
            Item updatedItem = existingItem with
            {
                Name = existingItem.Name,
                Description = existingItem.Description
            };
            _repository.UpdateItem(updatedItem);
            return NoContent();
        }

        /// <summary>
        /// DELETE command: deletes item if exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletes</returns>
        [HttpDelete]
        public ActionResult DeleteItem(int id) 
        {
            var existingItem = _repository.GetItem(id) as Item;
            if (existingItem == null) { return NotFound(); }
            _repository.DeleteItem(id);
            return NoContent();
        }
    }
}
