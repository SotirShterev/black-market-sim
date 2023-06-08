using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class ArtifactVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(40)]
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateOfDiscovery { get; set; }
        public bool IsInGoodCondition { get; set; }
        public int DealerId { get; set; }
        public virtual DealerVM DealerVm { get; set; }

        public ArtifactVM() { }
        public ArtifactVM(ArtifactDTO artifactDTO)
        {
            Id = artifactDTO.Id;
            Name = artifactDTO.Name;
            Price = artifactDTO.Price;
            DateOfDiscovery = artifactDTO.DateOfDiscovery;
            IsInGoodCondition = artifactDTO.IsInGoodCondition;
            DealerId = artifactDTO.DealerId;
        }
    }
}