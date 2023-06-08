using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class ArtifactDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(40)]
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateOfDiscovery { get; set; }
        public bool IsInGoodCondition { get; set; }
        public int DealerId { get; set; }
        public virtual DealerDTO Dealer { get; set; }
    }
}
