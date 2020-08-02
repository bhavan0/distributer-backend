using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.HTTP.Controllers
{
    [Route("store/items")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class StoreItemsController : ControllerBase
    {
        private readonly IStoreItemsService _storeItemsDomain;

        public StoreItemsController(IStoreItemsService storeItemsDomain)
        {
            _storeItemsDomain = storeItemsDomain ?? throw new ArgumentNullException(nameof(storeItemsDomain));
        }

        /// <summary>
        /// Get All Items bought by store
        /// </summary>
        /// <param name="storeId">Store Id to be fetched</param>
        [HttpGet("{storeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StoreDetails>> GetAllItemBoughtByStore(int storeId)
        {
            var result = await _storeItemsDomain.GetAllItemBoughtByStore(storeId).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get all Items Bought by Store on a particular date
        /// </summary>
        /// <param name="storeId">Store Id for which Data is to be fetched</param>
        /// <param name="date">Date for which it has to be fetched (YYYY-MM-DD)</param>
        [HttpGet("{storeId}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StoreDetails>> GetAllItemBoughtByStoreOnDate(int storeId, string date)
        {
            var result = await _storeItemsDomain.GetAllItemBoughtByStoreOnDate(storeId, date).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Add Items Bought by the store on a particular date
        /// </summary>
        /// <param name="storeItemEntity">Store Item Entity that has to be inserted</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AddItemBoughtByStoreOnDate([FromBody] StoreItemEntity storeItemEntity)
        {
            var result = await _storeItemsDomain.AddItemBoughtByStoreOnDate(storeItemEntity).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update the Items Bought by the Store on a particular date
        /// </summary>
        /// <param name="storeItemEntity">Store Item Entity that has to be updated</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateItemBoughtByStoreOnDate([FromBody] StoreItemEntity storeItemEntity)
        {
            var result = await _storeItemsDomain.UpdateItemBoughtByStoreOnDate(storeItemEntity).ConfigureAwait(false);
            return Ok(result);
        }
    }
}