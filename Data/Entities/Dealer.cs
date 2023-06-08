using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Dealer : BaseEntity
    {
        private string username;
        [MaxLength(15)]
        [Required(ErrorMessage = "Username is required.")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        [MaxLength(15)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string name;
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(30)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string gender;
        [MaxLength(6)]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private bool hasCriminalRecord;
        public bool HasCriminalRecord
        {
            get { return hasCriminalRecord; }
            set { hasCriminalRecord = value; }
        }
        private DateTime dateOfJoiningMarket;
        public DateTime DateOfJoiningMarket
        {
            get { return dateOfJoiningMarket; }
            set { dateOfJoiningMarket = value; }
        }
        public virtual ICollection<Transaction> Buyers { get; set; }
        public virtual ICollection<Transaction> Sellers { get; set; }
    }
}
