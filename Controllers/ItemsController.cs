using ApiProject.Models;
using ApiProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ApiProject.DataTransferObjects;
using System.Linq;
using ApiProject.Extensions;
using ApiProject.Domains.Queries;
using MediatR;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{
    [ApiController] 
    [Route("[Controller]")] // Optional
    public class ItemsController : ControllerBase
    {
        // Every endpoint should have those 3 lines of code:
        // Query/Command
        // Send method (mediatR)
        // Result


        private readonly LoaclAndExternalRepoInterface _repository;
        private readonly IMediator _mediator;

        public ItemsController(LoaclAndExternalRepoInterface repo, IMediator mediator) 
        {
            // DI in ctor
            this._repository = repo; 
            this._mediator = mediator;
        }

        /// <summary>
        /// GET query: returns all the listed items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetItems() 
        {
            // Query/Command
            var query = new GetItemsQuery();
            // Send method
            var result = await _mediator.Send(query);
            // Result
            return Ok(result);
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
        /// <returns>Action result - In type item</returns>
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
        /// <returns>Action result - NoContent</returns>
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
        /// <returns>Action result - NoContent</returns>
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
