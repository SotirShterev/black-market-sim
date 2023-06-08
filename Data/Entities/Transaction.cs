using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Transaction : BaseEntity
    {
        private DateTime dateOfTrans;
        public DateTime DateOfTrans
        {
            get { return dateOfTrans; }
            set { dateOfTrans = value; }
        }
        private string countryOfTrans;
        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(30)]
        public string CountryOfTrans
        {
            get { return countryOfTrans; }
            set { countryOfTrans = value; }
        }
        private double transFee;
        public double TransFee
        {
            get { return transFee; }
            set { transFee = value; }
        }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int ArtifactId { get; set; }

        public virtual Dealer Buyer { get; set; }
        public virtual Dealer Seller { get; set; }
        public virtual Artifact Artifact { get; set; }
    }
}
