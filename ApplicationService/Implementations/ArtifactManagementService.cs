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
    public class ArtifactManagementService
    {
        public List<ArtifactDTO> Get()
        {
            List<ArtifactDTO> artifactsDto = new List<ArtifactDTO>();
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.ArtifactRepository.Get())
                {
                    artifactsDto.Add(new ArtifactDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        DateOfDiscovery = item.DateOfDiscovery,
                        IsInGoodCondition = item.IsInGoodCondition,
                        DealerId = item.DealerId
                    });
                }
            }
            return artifactsDto;
        }
        public IEnumerable<ArtifactDTO> GetArtifactsByPrice(double price)
        {
            List<ArtifactDTO> artifactsDto = new List<ArtifactDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.ArtifactRepository.Get())
                {
                    artifactsDto.Add(new ArtifactDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        DateOfDiscovery = item.DateOfDiscovery,
                        IsInGoodCondition = item.IsInGoodCondition,
                        DealerId = item.DealerId
                    });
                }
            }
            var filteredArtifacts = artifactsDto.Where(artifact => artifact.Price == price);
            return filteredArtifacts;
        }
        public ArtifactDTO GetById(int id)
        {
            ArtifactDTO artifactDTO = new ArtifactDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Artifact artifact = unitOfWork.ArtifactRepository.GetByID(id);
                if (artifact != null)
                {
                    artifactDTO = new ArtifactDTO
                    {
                        Name = artifact.Name,
                        Price = artifact.Price,
                        DateOfDiscovery = artifact.DateOfDiscovery,
                        IsInGoodCondition = artifact.IsInGoodCondition,
                        DealerId = artifact.DealerId
                    };
                }
            }
            return artifactDTO;
        }
        public bool Save(ArtifactDTO artifactDTO)
        {
            if (artifactDTO.DealerId == 0)
            {
                return false;
            }
            Artifact artifact = new Artifact
            {
                Name = artifactDTO.Name,
                Price = artifactDTO.Price,
                DateOfDiscovery = artifactDTO.DateOfDiscovery,
                IsInGoodCondition = artifactDTO.IsInGoodCondition,
                DealerId = artifactDTO.DealerId
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.ArtifactRepository.Insert(artifact);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(artifact);
                return false;
            }
        }
        public bool Edit(ArtifactDTO artifactDTO)
        {
            if (artifactDTO.DealerId == 0)
            {
                return false;
            }
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Artifact artifact = unitOfWork.ArtifactRepository.GetByID(artifactDTO.Id);
                    if (artifact == null)
                    {
                        return false; 
                    }
                    artifact.Name = artifactDTO.Name;
                    artifact.Price = artifactDTO.Price;
                    artifact.DateOfDiscovery = artifactDTO.DateOfDiscovery;
                    artifact.IsInGoodCondition = artifactDTO.IsInGoodCondition;
                    artifact.DealerId = artifactDTO.DealerId;

                    unitOfWork.ArtifactRepository.Update(artifact);
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
                    Artifact artifact = unitOfWork.ArtifactRepository.GetByID(id);
                    unitOfWork.ArtifactRepository.Delete(artifact);
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
