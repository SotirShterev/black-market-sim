using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Artifact : BaseEntity
    {
        private string name;
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(40)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private DateTime dateOfDiscovery;
        public DateTime DateOfDiscovery
        {
            get { return dateOfDiscovery; }
            set { dateOfDiscovery = value; }
        }
        private bool isInGoodCondition;
        public bool IsInGoodCondition
        {
            get { return isInGoodCondition; }
            set { isInGoodCondition = value; }
        }
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
