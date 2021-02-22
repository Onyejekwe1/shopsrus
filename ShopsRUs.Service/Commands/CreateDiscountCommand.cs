using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.Handlers.CommandHandlers
{
    public class CreateDiscountCommand : IRequest<DiscountDto>
    {
        public string Name { get; set; }
        public string DiscountType { get; set; }    
        public double Percentage { get; set; }
    }
}
