using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsAffiliate { get; set; }
    }
}
