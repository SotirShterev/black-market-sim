using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryBlackMarket
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        List<TransactionDTO> GetTransactions();
        [OperationContract]
        IEnumerable<TransactionDTO> GetTransactionsByCountry(string country);

        [OperationContract]
        TransactionDTO GetTransactionById(int id);

        [OperationContract]
        string PostTransaction(TransactionDTO transactionDTO);

        [OperationContract]
        string PutTransaction(TransactionDTO transactionDTO);

        [OperationContract]
        string DeleteTransaction(int id);
    }
}
