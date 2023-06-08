using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class DealerVM
    {
        public int Id { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(6)]
        public string Gender { get; set; }
        public DateTime DateOfJoiningMarket { get; set; }
        public bool HasCriminalRecord { get; set; }
        public DealerVM() { }
        public DealerVM(DealerDTO dealerDTO)
        {
            Id = dealerDTO.Id;
            Name = dealerDTO.Name;
            Age = dealerDTO.Age;
            Gender = dealerDTO.Gender;
            DateOfJoiningMarket = dealerDTO.DateOfJoiningMarket;
            HasCriminalRecord = dealerDTO.HasCriminalRecord;
        }
    }
}