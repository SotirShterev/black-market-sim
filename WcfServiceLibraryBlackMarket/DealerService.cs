using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryBlackMarket
{
    public class DealerService : IDealerService
    {
        private DealerManagementService dealerService = new DealerManagementService();
        public List<DealerDTO> GetDealers()
        {
            return dealerService.Get();
        }
        public IEnumerable<DealerDTO> GetDealersByAge(int age)
        {
            return dealerService.GetDealersByAge(age);
        }
        public DealerDTO GetDealerById(int id)
        {
            return dealerService.GetById(id);
        }
        public string PostDealer(DealerDTO dealerDTO)
        {
            if (!dealerService.Save(dealerDTO))
            {
                return "Dealer is not saved!";
            }
            else
            {
                return "Dealer is saved!";
            }
        }
        public string PutDealer(DealerDTO dealerDTO)
        {
            if (!dealerService.Edit(dealerDTO))
            {
                return "Dealer is not edited!";
            }
            else
            {
                return "Dealer is edited!";
            }
        }
        public string DeleteDealer(int id)
        {
            if (!dealerService.Delete(id))
            {
                return "Dealer is not deleted!";
            }
            else
            {
                return "Dealer is deleted!";
            }
        }
    }
}
