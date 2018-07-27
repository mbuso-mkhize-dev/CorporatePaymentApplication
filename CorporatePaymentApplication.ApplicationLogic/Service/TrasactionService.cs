using CorporatePaymentApplication.ApplicationLogic.Models;
using CorporatePaymentApplication.ApplicationLogic.Models.Mapper;
using CorporatePaymentApplication.ApplicationLogic.Service.Interface;
using CorporatePaymentApplication.Repository.Models;
using CorporatePaymentApplication.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorporatePaymentApplication.ApplicationLogic.Service
{
    public class TrasactionService : ITransactionService
    {
        private IRepository<CorporatePayment> _paymentRepository;

        public TrasactionService(IRepository<CorporatePayment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task AddPayments(List<CorporatePayments> models)
        {
            try
            {
                foreach (var payment in models)
                {
                    _paymentRepository.Add(DBModelMapper.MapToDBModel(payment));
                }
                await _paymentRepository.SaveAsync();
            }
            catch (Exception e)
            {
            }
        }

        public async Task<List<PaymentEntity>> GetPaymentTransactions(DateTime transactionDate)
        {
            var parameters = new SqlParameter[] { new SqlParameter("@trasactiondate", transactionDate.ToString("yyyy-MM-dd HH:mm:ss.fff")) };

            var payments = await _paymentRepository.GetAccountTransactions(parameters);
            return payments.Select(DBModelMapper.MapToViewModel).ToList();
        }
    }
}