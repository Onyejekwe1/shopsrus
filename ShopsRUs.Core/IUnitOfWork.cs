using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopsRUs.Core.Repositories;

namespace ShopsRUs.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        Task BeginAsync();
        Task CommitAsync();
        void Rollback();
        Task<int> Complete();   
    }
}
