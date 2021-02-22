using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopsRUs.Service.Commands;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("customers/all")]
        [ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("customer/{id:guid}", Name = "GetCustomerById")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerById(Guid id)   
        {
            var result = await Mediator.Send(new GetCustomerByIdQuery(id));

            return Ok(result);
        }

        [HttpGet("customer/{name}", Name = "GetCustomerByName")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var result = await Mediator.Send(new GetCustomerByNameQuery(name));

            return Ok(result);
        }

        [HttpPost("customer")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)  
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
