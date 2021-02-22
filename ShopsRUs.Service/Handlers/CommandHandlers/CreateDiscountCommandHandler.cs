using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Handlers.CommandHandlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountDto>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DiscountDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            if (!_discountRepository.IsExist(x => x.DiscountType.ToLower() == request.DiscountType.ToLower()))
                return null;

            var discount = _mapper.Map<Discount>(request);

            _discountRepository.Add(discount);

            await _unitOfWork.Complete();

            return _mapper.Map<DiscountDto>(discount);
        }
    }
}
