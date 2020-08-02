using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace API.HTTP.Controllers
{
    [Route("payments")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsDomain;

        public PaymentsController(IPaymentsService paymentsDomain)
        {
            _paymentsDomain = paymentsDomain ?? throw new ArgumentNullException(nameof(paymentsDomain));
        }

        /// <summary>
        /// Get All Payments done by Store.
        /// </summary>
        /// <param name="storeId">Store Id for which it has to be fetched</param>
        [HttpGet("{storeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<PaymentEntity>>> GetAllPaymenetsDoneByStore(int storeId)
        {
            var result = await _paymentsDomain.GetAllPaymenetsDoneByStore(storeId).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Total amount Recieved till Date
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> GetTotalPaymenetsRecieved()
        {
            var result = _paymentsDomain.GetTotalPaymenetsRecieved();
            return Ok(result);
        }

        /// <summary>
        /// Get Total amount Recieved on Date
        /// </summary>
        /// <param name="date">Date for which total is to be retrieved</param>
        [HttpGet("{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> GetTotalPaymenetsRecievedOnDate(string date)
        {
            var result = await _paymentsDomain.GetTotalPaymenetsRecievedOnDate(date).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Get Total Payment A particular store has given on a date
        /// </summary>
        /// <param name="storeId">Store Id for which it has to be fetched</param>
        /// <param name="date">Date for which it has to be fetched</param>
        [HttpGet("{storeId}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> GetTotalPaymenetsRecievedByStoreOnDate(int storeId, string date)
        {
            var result = await _paymentsDomain.GetTotalPaymenetsRecievedByStoreOnDate(storeId, date).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Add Payment given by the store
        /// </summary>
        /// <param name="payment">Payment details recieved</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> AddPaymentForStoreOnDate([FromBody] PaymentEntity payment)
        {
            var result = await _paymentsDomain.AddPaymentForStoreOnDate(payment).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update Payment Recieved on a Date
        /// </summary>
        /// <param name="payment">Payment details to be updated</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> UpdatePaymentForStoreOnDate([FromBody] PaymentEntity payment)
        {
            var result = await _paymentsDomain.UpdatePaymentForStoreOnDate(payment).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("~/store/{storeId}/leftpayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> GetStoreLeftPayment(int storeId)
        {
            var result = await _paymentsDomain.GetStorePaymentLeft(storeId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}