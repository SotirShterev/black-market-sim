using ApplicationService.DTOs;
using MVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        // GET: Dealer
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<DealerVM> dealerVMs = new List<DealerVM>();
            using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
            {
                var dealerData = service.GetDealers();
                foreach (var item in service.GetDealers())
                {
                    var dealerVM = new DealerVM(item);
                    dealerVM.Username = item.Username;
                    dealerVMs.Add(dealerVM);
                }
            }
            IPagedList<DealerVM> pagedDealerVM = dealerVMs.ToPagedList(pageNumber, pageSize);
            return View(pagedDealerVM);
        }
        [HttpGet]
        // GET: Dealer/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Dealer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerVM dealerVM)
        {
            try
            {
                using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
                {
                    DealerDTO dealerDto = new DealerDTO
                    {
                        Username = dealerVM.Username,
                        Password = dealerVM.Password,
                        Name = dealerVM.Name,
                        Age = dealerVM.Age,
                        Gender = dealerVM.Gender,
                        DateOfJoiningMarket = dealerVM.DateOfJoiningMarket,
                        HasCriminalRecord = dealerVM.HasCriminalRecord
                    };
                    service.PostDealer(dealerDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Dealer/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DealerVM dealerVM = new DealerVM();
            using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
            {
                var dealerDto = service.GetDealerById(id);
                dealerVM.Id = dealerDto.Id;
                dealerVM.Username = dealerDto.Username;
                dealerVM.Password = dealerDto.Password;
                dealerVM.Name = dealerDto.Name;
                dealerVM.Age = dealerDto.Age;
                dealerVM.Gender = dealerDto.Gender;
                dealerVM.DateOfJoiningMarket = dealerDto.DateOfJoiningMarket;
                dealerVM.HasCriminalRecord = dealerDto.HasCriminalRecord;
            }
            return View(dealerVM);
        }
        // POST: Dealer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DealerVM dealerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
                    {
                        DealerDTO dealerDto = new DealerDTO
                        {
                            Id = dealerVM.Id,
                            Username = dealerVM.Username,
                            Password = dealerVM.Password,
                            Name = dealerVM.Name,
                            Age = dealerVM.Age,
                            Gender = dealerVM.Gender,
                            DateOfJoiningMarket = dealerVM.DateOfJoiningMarket,
                            HasCriminalRecord = dealerVM.HasCriminalRecord
                        };
                        service.PutDealer(dealerDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: Dealer/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
            {
                service.DeleteDealer(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SearchByAge(int? age, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            try
            {
                if (age.HasValue)
                {
                    using (DealerService.DealerServiceClient service = new DealerService.DealerServiceClient())
                    {
                        IEnumerable<DealerDTO> dealers = service.GetDealersByAge(age.Value);
                        if (dealers.Any())
                        {
                            IEnumerable<DealerVM> dealerVMs = dealers.Select(dealer => new DealerVM
                            {
                                Id = dealer.Id,
                                Username = dealer.Username,
                                Password = dealer.Password,
                                Name = dealer.Name,
                                Age = dealer.Age,
                                Gender = dealer.Gender,
                                DateOfJoiningMarket = dealer.DateOfJoiningMarket,
                                HasCriminalRecord = dealer.HasCriminalRecord
                            });
                            IPagedList<DealerVM> pagedDealerVMs = dealerVMs.ToPagedList(pageNumber, pageSize);
                            return View("Index", pagedDealerVMs);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}