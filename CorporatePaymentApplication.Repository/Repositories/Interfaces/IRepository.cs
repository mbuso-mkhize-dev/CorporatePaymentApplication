using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CorporatePaymentApplication.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAccountTransactions(SqlParameter[] parameters);

        T Add(T item);

        Task<int> SaveAsync();
    }
}