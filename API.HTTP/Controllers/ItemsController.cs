using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.HTTP.Controllers
{
    [Route("items")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsDomain;

        public ItemsController(IItemsService itemsDomain)
        {
            _itemsDomain = itemsDomain ?? throw new ArgumentNullException(nameof(itemsDomain));
        }
           
        /// <summary>
        /// Get All Items Of Distributer.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ItemEntity>>> GetAllItems()
        {
            var result = await _itemsDomain.GetAllItems().ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Item By Name
        /// </summary>
        /// <param name="itemId">Id of item to be fetched</param>
        [HttpGet("{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ItemEntity>> GetItemById(int itemId)
        {
            var result = await _itemsDomain.GetItemById(itemId).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Add Item to Catalog.
        /// </summary>
        /// <param name="item">Item To be Entered</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AddItem([FromBody]ItemEntity item)
        {
            var result = await _itemsDomain.AddItem(item).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update An Item in the Catalog
        /// </summary>
        /// <param name="item">Item to be Updated.</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateItem([FromBody]ItemEntity item)
        {
            var result = await _itemsDomain.UpdateItem(item).ConfigureAwait(false);
            return Ok(result);
        }
    }
}