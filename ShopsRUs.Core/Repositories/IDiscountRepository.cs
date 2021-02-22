using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;

namespace ShopsRUs.Core.Repositories
{
    public interface IDiscountRepository: IRepository<Discount>
    {
        decimal CalculateDiscount(decimal amount, Discount discount);   
        ///decimal CalculateDiscountForEvery100(decimal amount, Discount discount);    
    }
}
