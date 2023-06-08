using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryBlackMarket
{
    public class TransactionService : ITransactionService
    {
        private TransactionManagementService transactionService = new TransactionManagementService();
        public List<TransactionDTO> GetTransactions()
        {
            return transactionService.Get();
        }
        public IEnumerable<TransactionDTO> GetTransactionsByCountry(string country)
        {
            return transactionService.GetTransactionsByCountry(country);
        }
        public TransactionDTO GetTransactionById(int id)
        {
            return transactionService.GetById(id);
        }
        public string PostTransaction(TransactionDTO transactionDTO)
        {
            if (!transactionService.Save(transactionDTO))
            {
                return "Transaction is not saved!";
            }
            else
            {
                return "Transaction is saved!";
            }
        }
        public string PutTransaction(TransactionDTO transactionDTO)
        {
            if (!transactionService.Edit(transactionDTO))
            {
                return "Transaction is not edited!";
            }
            else
            {
                return "Transaction is edited!";
            }
        }
        public string DeleteTransaction(int id)
        {
            if (!transactionService.Delete(id))
            {
                return "Transaction is not deleted!";
            }
            else
            {
                return "Transaction is deleted!";
            }
        }
    }
}
