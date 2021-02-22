using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enums;
using ShopsRUs.Core.Enums_and_Constants;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Handlers.QueryHandlers
{
    public class GetInvoiceAmountQueryHandler : IRequestHandler<GetInvoiceAmountQuery, InvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetInvoiceAmountQueryHandler(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, IDiscountRepository discountRepository, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceAmountQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            var amountAfterDiscount = request.Amount;
            Discount discount;
            if (!request.IsGrocery)
            {
                
                if (customer.IsAffiliate)
                {
                    
                    discount = await _discountRepository.FirstOrDefaultAsync(x => x.DiscountType.ToLower() == DiscountTypeConstant.DiscountForAffiliate);    
                    amountAfterDiscount = _discountRepository.CalculateDiscount(request.Amount, discount);
                }
                else if (customer.IsEmployee)
                {
                    discount = await _discountRepository.FirstOrDefaultAsync(x => x.DiscountType.ToLower() == DiscountTypeConstant.DiscountForEmployees);
                    amountAfterDiscount = _discountRepository.CalculateDiscount(request.Amount, discount);
                }
                else if (customer.DateCreated <= DateTime.Now.AddYears(-2))
                {
                    discount = await _discountRepository.FirstOrDefaultAsync(x => x.DiscountType.ToLower() == DiscountTypeConstant.DiscountForLoyalCustomers);
                    amountAfterDiscount = _discountRepository.CalculateDiscount(request.Amount, discount);
                }
            }

            //Determine discount for every 100 dollars
            discount = await _discountRepository.FirstOrDefaultAsync(x => x.DiscountType.ToLower() == DiscountTypeConstant.Every100DollarDiscount);
            var _100DollarDiscount = _discountRepository.CalculateDiscount(request.Amount, discount);
            amountAfterDiscount = amountAfterDiscount - _100DollarDiscount;
            var invoice = new Invoice
            {
                Amount = amountAfterDiscount,
                CustomerId = request.CustomerId
            };
            _invoiceRepository.Add(invoice);

            await _unitOfWork.Complete();

            return new InvoiceDto
            {
                Amount = amountAfterDiscount,
                CustomerName = $"{customer.FirstName} {customer.LastName}"
            };
        }
    }
}
