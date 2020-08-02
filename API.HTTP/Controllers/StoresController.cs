using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace API.HTTP.Controllers
{
    [Route("stores")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesDomain;

        public StoresController(IStoresService storesDomain)
        {
            _storesDomain = storesDomain ?? throw new ArgumentNullException(nameof(storesDomain));
        }

        /// <summary>
        /// Get All Stores entered
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<StoreEntity>>> GetAllStores()
        {
            var result = await _storesDomain.GetAllStores().ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Store By Name.
        /// </summary>
        /// <param name="storeId">Store id to be Fetched</param>
        [HttpGet("{storeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StoreEntity>> GetStoreById(int storeId)
        {
            var result = await _storesDomain.GetStoreById(storeId).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Add Store to List
        /// </summary>
        /// <param name="store">Store to be Entered</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AddStore([FromBody]StoreEntity store)
        {
            var result = await _storesDomain.AddStore(store).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update Store By Id
        /// </summary>
        /// <param name="store">Store to be Updated</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdateStore([FromBody]StoreEntity store)
        {
            var result = await _storesDomain.UpdateStore(store).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
