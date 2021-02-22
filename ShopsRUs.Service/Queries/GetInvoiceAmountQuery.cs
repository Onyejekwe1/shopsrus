using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Queries
{
    public class GetInvoiceAmountQuery : IRequest<InvoiceDto>
    {

        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsGrocery { get; set; }
    }
}
