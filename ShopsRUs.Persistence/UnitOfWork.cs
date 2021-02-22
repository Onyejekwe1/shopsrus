using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ShopsRUs.Core;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Data;

namespace ShopsRUs.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopsRUsDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ICustomerRepository customerRepository, ShopsRUsDbContext context, IDiscountRepository discountRepository, IInvoiceRepository invoiceRepository)
        {
            CustomerRepository = customerRepository;
            _context = context;
            DiscountRepository = discountRepository;
            InvoiceRepository = invoiceRepository;
        }

        public ICustomerRepository CustomerRepository { get; }
        public IDiscountRepository DiscountRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }

        public async Task BeginAsync()
        {
            if (_transaction != null)
            {
                return;
            }

            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }

        public async Task CommitAsync()
        {
            try
            {
                await Complete().ConfigureAwait(false);

                _transaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public Task<int> Complete()
        {
            try
            {
               return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Task.FromResult(0);
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
