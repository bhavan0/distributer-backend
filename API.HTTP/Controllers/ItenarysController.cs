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
    [Route("itenary")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ItenarysController : ControllerBase
    {
        private readonly IItenaryService _itenaryDomain;

        public ItenarysController(IItenaryService itenaryDomain)
        {
            _itenaryDomain = itenaryDomain ?? throw new ArgumentNullException(nameof(itenaryDomain));
        }

        /// <summary>
        /// Add Items Bought for Date
        /// </summary>
        /// <param name="itemDate"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AddItemsBoughtForDate([FromBody]ItenaryEntity itemDate)
        {
            var result = await _itenaryDomain.AddItemsBoughtForDate(itemDate).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update Items Bought for Date
        /// </summary>
        /// <param name="itemDate"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateItemsBoughtForDate([FromBody]ItenaryEntity itemDate)
        {
            var result = await _itenaryDomain.UpdateItemsBoughtForDate(itemDate).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update The Itenary sold for a date
        /// </summary>
        /// <param name="itenaryId">Itenary to be updated</param>
        /// <param name="soldCount">New Sold Count</param>
        [HttpPut("{itenaryId}/{soldCount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateItemsSoldForDate(int itenaryId, int soldCount)
        {
            var result = await _itenaryDomain.UpdateItemsSoldForDate(itenaryId, soldCount).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Itenary for a Day
        /// </summary>
        /// <param name="date">Date for which itenary is to be fetched</param>
        [HttpGet("{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ItenaryEntity>>> GetItenaryForDay(string date)
        {
            var result = await _itenaryDomain.GetItenaryForDay(date).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Total Itenary fetched till date
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ItenaryEntity>>> GetTillDateItenary()
        {
            var result = await _itenaryDomain.GetTillDateItenary().ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Till Date Itenary of one Item.
        /// </summary>
        /// <param name="itemId">Item Id for which itenary is to be fetched</param>
        [HttpGet("{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ItenaryEntity>>> GetTillDateItenaryOfOneItem(int itemId)
        {
            var result = await _itenaryDomain.GetTillDateItenaryOfOneItem(itemId).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Itenary of a date of an Item
        /// </summary>
        /// <param name="itemId">Item id for which itenary is to fetched</param>
        /// <param name="date">date for which itenary is to be fetched</param>
        [HttpGet("{itemId}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<ItenaryEntity>>> GetOnDateItenaryOfOneItem(int itemId, string date)
        {
            var result = await _itenaryDomain.GetOnDateItenaryOfOneItem(itemId, date).ConfigureAwait(false);
            return Ok(result);
        }
    }
}