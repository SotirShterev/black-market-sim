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
    public class DealerManagementService
    {
        public List<DealerDTO> Get()
        {
            List<DealerDTO> dealersDto = new List<DealerDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.DealerRepository.Get())
                {
                    dealersDto.Add(new DealerDTO
                    {
                        Id = item.Id,
                        Username = item.Username,
                        Password = item.Password,
                        Name = item.Name,
                        Age = item.Age,
                        Gender = item.Gender,
                        HasCriminalRecord = item.HasCriminalRecord,
                        DateOfJoiningMarket = item.DateOfJoiningMarket
                    });

                }
            }
            return dealersDto;
        }
        public IEnumerable<DealerDTO> GetDealersByAge(int age)
        {
            List<DealerDTO> dealersDto = new List<DealerDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.DealerRepository.Get())
                {
                    dealersDto.Add(new DealerDTO
                    {
                        Id = item.Id,
                        Username = item.Username,
                        Password = item.Password,
                        Name = item.Name,
                        Age = item.Age,
                        Gender = item.Gender,
                        HasCriminalRecord = item.HasCriminalRecord,
                        DateOfJoiningMarket = item.DateOfJoiningMarket
                    });
                }
            }
            var filteredDealers = dealersDto.Where(dealer => dealer.Age == age);
            return filteredDealers;
        }
        public DealerDTO GetById(int id)
        {
            DealerDTO dealerDTO = new DealerDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Dealer dealer = unitOfWork.DealerRepository.GetByID(id);
                if (dealer != null)
                {
                    dealerDTO = new DealerDTO
                    {
                        Id = dealer.Id,
                        Username = dealer.Username,
                        Password = dealer.Password,
                        Name = dealer.Name,
                        Age = dealer.Age,
                        Gender = dealer.Gender,
                        HasCriminalRecord = dealer.HasCriminalRecord,
                        DateOfJoiningMarket = dealer.DateOfJoiningMarket
                    };
                }
            }
            return dealerDTO;
        }

        public bool Save(DealerDTO dealerDTO)
        {
            Dealer dealer = new Dealer
            {
                Username = dealerDTO.Username,
                Password = dealerDTO.Password,
                Name = dealerDTO.Name,
                Age = dealerDTO.Age,
                Gender = dealerDTO.Gender,
                HasCriminalRecord = dealerDTO.HasCriminalRecord,
                DateOfJoiningMarket = dealerDTO.DateOfJoiningMarket
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.DealerRepository.Insert(dealer);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(DealerDTO dealerDTO)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Dealer dealer = unitOfWork.DealerRepository.GetByID(dealerDTO.Id);
                    if (dealer == null)
                    {
                        return false;
                    }
                    dealer.Name = dealerDTO.Name;
                    dealer.Username = dealerDTO.Username;
                    dealer.Password = dealerDTO.Password;
                    dealer.Age = dealerDTO.Age;
                    dealer.Gender = dealerDTO.Gender;
                    dealer.HasCriminalRecord = dealerDTO.HasCriminalRecord;
                    dealer.DateOfJoiningMarket = dealerDTO.DateOfJoiningMarket;

                    unitOfWork.DealerRepository.Update(dealer);
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
                    Dealer dealer = unitOfWork.DealerRepository.GetByID(id);
                    unitOfWork.DealerRepository.Delete(dealer);
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
