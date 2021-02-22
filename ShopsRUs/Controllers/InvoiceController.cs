using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Web.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IMapper _mapper;

        public InvoiceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("invoice")]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalInvoice([FromQuery] GetInvoiceAmountQuery amountQuery)   
        {

            var result = await Mediator.Send(amountQuery);

            return Ok(result);
        }
    }
}
