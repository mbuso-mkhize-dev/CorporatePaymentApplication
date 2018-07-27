
using CorporatePaymentApplication.ApplicationLogic.Models;
using CorporatePaymentApplication.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorporatePaymentApplication.ApplicationLogic.Service.Interface
{
    public interface ITransactionService
    {
        Task AddPayments(List<CorporatePayments> models);

        Task<List<PaymentEntity>> GetPaymentTransactions(DateTime transactionDate);
    }
}