using MVC.ViewModels;
using PagedList;
using MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationService.DTOs;

namespace MVC.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction/Index
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<TransactionVM> transactionVM = new List<TransactionVM>();
            using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
            {
                foreach (var item in service.GetTransactions())
                {
                    transactionVM.Add(new TransactionVM(item));
                }
            }
            IPagedList<TransactionVM> pagedTransactionVM = transactionVM.ToPagedList(pageNumber, pageSize);
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
            return View(pagedTransactionVM);
        }
        [HttpGet]
        // GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
            return View();
        }
        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionVM transactionVM)
        {
            try
            {
                using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
                {
                    TransactionDTO transactionDTO = new TransactionDTO
                    {
                        dateOfTrans = transactionVM.dateOfTrans,
                        countryOfTrans = transactionVM.countryOfTrans,
                        transFee = transactionVM.transFee,
                        BuyerId = transactionVM.BuyerId,
                        SellerId = transactionVM.SellerId,
                        ArtifactId = transactionVM.ArtifactId
                    };
                    service.PostTransaction(transactionDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
                return View();
            }
        }
        // GET: Transaction/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
            TransactionVM transactionVM = new TransactionVM();
            using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
            {
                var transactionDTO = service.GetTransactionById(id);
                transactionVM = new TransactionVM(transactionDTO);
            }
            return View(transactionVM);
        }
        // POST: Transaction/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionVM transactionVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
                    {
                        TransactionDTO transactionDTO = new TransactionDTO
                        {
                            Id = transactionVM.Id,
                            dateOfTrans = transactionVM.dateOfTrans,
                            countryOfTrans = transactionVM.countryOfTrans,
                            transFee = transactionVM.transFee,
                            BuyerId = transactionVM.BuyerId,
                            SellerId = transactionVM.SellerId,
                            ArtifactId = transactionVM.ArtifactId
                        };
                        service.PutTransaction(transactionDTO);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
                return View();
            }
            catch
            {
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
                return View();
            }
        }
        // GET: Transaction/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
            {
                service.DeleteTransaction(id);
            }
            return RedirectToAction("Index");
        }
        // GET: Transaction/SearchByCountry
        [HttpGet]
        public ActionResult SearchByCountry(string country, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            try
            {
                    using (TransactionService.TransactionServiceClient service = new TransactionService.TransactionServiceClient())
                    {
                        IEnumerable<TransactionDTO> transactions = service.GetTransactionsByCountry(country);
                        if (transactions.Any())
                        {
                            IEnumerable<TransactionVM> transactionVMs = transactions.Select(transaction => new TransactionVM
                            {
                                dateOfTrans = transaction.dateOfTrans,
                                countryOfTrans = transaction.countryOfTrans,
                                transFee = transaction.transFee,
                                BuyerId = transaction.BuyerId,
                                SellerId = transaction.SellerId,
                                ArtifactId = transaction.ArtifactId
                            });
                        IPagedList<TransactionVM> pagedTransactionVMs = transactionVMs.ToPagedList(pageNumber, pageSize);
                        ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                        ViewBag.Artifacts = LoadDataUtilities.LoadArtifactsData();
                        return View("Index", pagedTransactionVMs);
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