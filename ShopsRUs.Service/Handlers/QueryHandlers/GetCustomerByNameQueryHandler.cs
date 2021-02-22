using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Handlers.QueryHandlers
{
    public class GetCustomerByNameQueryHandler : IRequestHandler<GetCustomerByNameQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByNameQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(c => string.Equals(c.FirstName.ToLower(), request.Name.ToLower()) || string.Equals(c.LastName.ToLower(), request.Name.ToLower()));
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
