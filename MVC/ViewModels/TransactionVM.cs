using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class TransactionVM
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
        public virtual DealerVM BuyerVm { get; set; }
        public virtual DealerVM SellerVm { get; set; }
        public virtual ArtifactVM ArtifactVm { get; set; }
        public TransactionVM() { }
        public TransactionVM(TransactionDTO transactionDTO)
        {
            Id = transactionDTO.Id;
            dateOfTrans = transactionDTO.dateOfTrans;
            countryOfTrans = transactionDTO.countryOfTrans;
            transFee = transactionDTO.transFee;
            BuyerId = transactionDTO.BuyerId;
            SellerId = transactionDTO.SellerId;
            ArtifactId = transactionDTO.ArtifactId;
        }
    }
}