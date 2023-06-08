using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime dateOfTrans { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(30)]
        public string countryOfTrans { get; set; }
        public double transFee { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ArtifactId { get; set; }
        public virtual DealerDTO Buyer { get; set; }
        public virtual DealerDTO Seller { get; set; }
        public virtual ArtifactDTO Artifact { get; set; }

    }
}
