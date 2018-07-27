using CorporatePaymentApplication.Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CorporatePaymentApplication.Repository.Repositories
{
    public class DBRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;

        public DBRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public T Add(T item)
        {
            Context.Set<T>().Add(item);
            return item;
        }

        public Task<List<T>> GetAccountTransactions(SqlParameter[] parameters)
        {
            return Context.Database.SqlQuery<T>("transactionFilterProc @trasactiondate", parameters).ToListAsync();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}