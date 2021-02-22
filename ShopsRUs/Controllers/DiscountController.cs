using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopsRUs.Service.Handlers.CommandHandlers;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Web.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("discounts/all", Name = "GetAllDiscounts")]
        [ProducesResponseType(typeof(List<DiscountDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var result = await Mediator.Send(new GetAllDiscountsQuery());
            return Ok(result);
        }

        [HttpGet("discount/{type}", Name = "GetDiscountByType")]
        [ProducesResponseType(typeof(DiscountDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDiscountByType(string type)
        {
            var result = await Mediator.Send(new GetDiscountByTypeQuery(type));
            return Ok(result);
        }

        [HttpPost("discount/add", Name = "CreateDiscount")]
        [ProducesResponseType(typeof(DiscountDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
