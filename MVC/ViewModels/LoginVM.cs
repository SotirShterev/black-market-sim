using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class LoginVM
    {
        [MaxLength(15)]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}