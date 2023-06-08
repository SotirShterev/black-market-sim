using ApplicationService.DTOs;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM,string ReturnUrl)
        {
            if (!this.ModelState.IsValid)
                return View(loginVM);
            using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
            {
                DealerDTO loggedDealer = service.GetDealers().Where(d => d.Username == loginVM.Username && d.Password == loginVM.Password).FirstOrDefault();
                if(loggedDealer == null)
                {
                    this.ModelState.AddModelError("authError", "Invalid username or password!");
                    return View(loginVM);
                }
                FormsAuthentication.SetAuthCookie(loggedDealer.Username, false);
                return Redirect(ReturnUrl);
            }
        }
        

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}