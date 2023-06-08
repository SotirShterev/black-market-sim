using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class TransactionManagementService
    {
        public List<TransactionDTO> Get()
        {
            List<TransactionDTO> transactionsDto = new List<TransactionDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TransactionRepository.Get())
                {
                    transactionsDto.Add(new TransactionDTO
                    {
                        Id = item.Id,
                        dateOfTrans = item.DateOfTrans,
                        countryOfTrans = item.CountryOfTrans,
                        transFee = item.TransFee,
                        BuyerId = item.BuyerId,
                        SellerId = item.SellerId,
                        ArtifactId = item.ArtifactId
                    });
                }
            }
            return transactionsDto;
        }
        public IEnumerable<TransactionDTO> GetTransactionsByCountry(string country)
        {
            List<TransactionDTO> transactionsDto = new List<TransactionDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.TransactionRepository.Get())
                {
                    transactionsDto.Add(new TransactionDTO
                    {
                        Id = item.Id,
                        dateOfTrans = item.DateOfTrans,
                        countryOfTrans = item.CountryOfTrans,
                        transFee = item.TransFee,
                        BuyerId = item.BuyerId,
                        SellerId = item.SellerId,
                        ArtifactId = item.ArtifactId
                    });
                }
            }
            var filteredTransactions = transactionsDto.Where(transaction => transaction.countryOfTrans == country);
            return filteredTransactions;
        }
        public TransactionDTO GetById(int id)
        {
            TransactionDTO transactionDTO = new TransactionDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Transaction transaction = unitOfWork.TransactionRepository.GetByID(id);
                if (transaction != null)
                {
                    transactionDTO = new TransactionDTO
                    {
                        dateOfTrans = transaction.DateOfTrans,
                        countryOfTrans = transaction.CountryOfTrans,
                        transFee = transaction.TransFee,
                        BuyerId = transaction.BuyerId,
                        SellerId = transaction.SellerId,
                        ArtifactId = transaction.ArtifactId
                    };
                }
            }
            return transactionDTO;
        }
        public bool Save(TransactionDTO transactionDTO)
        {
            if (transactionDTO.BuyerId == 0)
            {
                return false;
            }
            if (transactionDTO.SellerId == 0)
            {
                return false;
            }
            if (transactionDTO.ArtifactId == 0)
            {
                return false;
            }
            Transaction transaction = new Transaction
            {
                DateOfTrans = transactionDTO.dateOfTrans,
                CountryOfTrans = transactionDTO.countryOfTrans,
                TransFee = transactionDTO.transFee,
                BuyerId = transactionDTO.BuyerId,
                SellerId = transactionDTO.SellerId,
                ArtifactId = transactionDTO.ArtifactId
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TransactionRepository.Insert(transaction);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(transaction);
                return false;
            }
        }
        public bool Edit(TransactionDTO transactionDTO)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Transaction transaction = unitOfWork.TransactionRepository.GetByID(transactionDTO.Id);
                    if (transaction == null)
                    {
                        return false;
                    }
                    transaction.DateOfTrans = transactionDTO.dateOfTrans;
                    transaction.CountryOfTrans = transactionDTO.countryOfTrans;
                    transaction.TransFee = transactionDTO.transFee;
                    transaction.BuyerId = transactionDTO.BuyerId;
                    transaction.SellerId = transactionDTO.SellerId;
                    transaction.ArtifactId = transactionDTO.ArtifactId;

                    unitOfWork.TransactionRepository.Update(transaction);
                    unitOfWork.Save();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Transaction transaction = unitOfWork.TransactionRepository.GetByID(id);
                    unitOfWork.TransactionRepository.Delete(transaction);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
