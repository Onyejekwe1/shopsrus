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
    public class GetDiscountByTypeQueryHandler : IRequestHandler<GetDiscountByTypeQuery, DiscountDto>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetDiscountByTypeQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<DiscountDto> Handle(GetDiscountByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _discountRepository.FirstOrDefaultAsync(x => x.DiscountType.ToLower() == request.DiscountType.ToLower());

            return _mapper.Map<DiscountDto>(result);
        }
    }
}
