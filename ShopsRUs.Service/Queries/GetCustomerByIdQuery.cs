using System;
using MediatR;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
