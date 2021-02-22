using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ShopsRUs.Core.Entities;
using ShopsRUs.Service.Commands;
using ShopsRUs.Service.Handlers.CommandHandlers;
using ShopsRUs.Service.Queries;
using ShopsRUs.Service.Response;

namespace ShopsRUs.Service.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountCommand>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<Invoice, GetDiscountByTypeQuery>().ReverseMap();
            CreateMap<Invoice, GetDiscountByTypeQuery>().ReverseMap();
            CreateMap<InvoiceDto, GetDiscountByTypeQuery>().ReverseMap();

        }
    }
}
