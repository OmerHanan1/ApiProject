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
using ApiProject.Domains.Commands;

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


        private readonly ILocalAndExternalRepo _repository;
        private readonly IMediator _mediator;

        public ItemsController(ILocalAndExternalRepo repo, IMediator mediator) 
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
            // Query
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
        public async Task<IActionResult> GetItem(Guid id) 
        {
            // Query
            var query = new GetItemByIdQuery(id);
            // Send method
            var result = await _mediator.Send(query);
            // Result
            if(result == null) { return NotFound(); }
            return Ok(result);
        }

        /// <summary>
        /// POST command: Creates a new Item and post it into the repository
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Action result - In type item</returns>
        [HttpPost]
        public async Task<IActionResult> CreateNewItem(CreateItemCommand command) 
        {
            // Send method
            var result = await _mediator.Send(command);
            // Result
            return CreatedAtAction(nameof(GetItem), new { id = result.Id }, result);
        }

        /// <summary>
        /// PUT command: update existing item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>Action result - NoContent</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, ItemDTO item) 
        {
            // Command
            var command = new UpdateItemCommand(id, item);
            // Send method
            var result = await _mediator.Send(command);
            // Result
            if (result == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// DELETE command: deletes item if exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Action result - NoContent</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(Guid id) 
        {
            var command = new DeleteItemCommand(id);
            var result = await _mediator.Send(command);
            if (result == null) { return NotFound(); }
            return NoContent();
        }
    }
}
