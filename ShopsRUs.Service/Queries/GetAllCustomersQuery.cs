using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
