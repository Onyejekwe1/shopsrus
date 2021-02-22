using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ShopsRUs.Core.Enums;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Queries
{
    public class GetDiscountByTypeQuery : IRequest<DiscountDto>
    {
        public string DiscountType { get; set; }

        public GetDiscountByTypeQuery(string discountType)
        {
            DiscountType = discountType;
        }
    }
}
