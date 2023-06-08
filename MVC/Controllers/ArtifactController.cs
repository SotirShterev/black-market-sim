using ApplicationService.DTOs;
using MVC.Utilities;
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
    public class ArtifactController : Controller
    {
        // GET: Artifact
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<ArtifactVM> artifactVM = new List<ArtifactVM>();
            using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
            {
                foreach (var item in service.GetArtifacts())
                {
                    artifactVM.Add(new ArtifactVM(item));
                }
            }
            IPagedList<ArtifactVM> pagedArtifactVM = artifactVM.ToPagedList(pageNumber, pageSize);
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            return View(pagedArtifactVM);
        }
        [HttpGet]
        // GET: Artifact/Create
        public ActionResult Create()
        {
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            return View();
        }
        // POST: Artifact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtifactVM artifactVM)
        {
            try
            {
                using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
                {
                    ArtifactDTO artifactDto = new ArtifactDTO
                    {
                        Name = artifactVM.Name,
                        Price = artifactVM.Price,
                        DateOfDiscovery = artifactVM.DateOfDiscovery,
                        IsInGoodCondition = artifactVM.IsInGoodCondition,
                        DealerId = artifactVM.DealerId,
                    };
                    service.PostArtifact(artifactDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                return View();
            }
        }
        // GET: Artifact/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
            ArtifactVM artifactVM = new ArtifactVM();
            using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
            {
                var artifactDTO = service.GetArtifactById(id);
                artifactVM = new ArtifactVM(artifactDTO);
            }
            return View(artifactVM);
        }
        // POST: Artifact/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtifactVM artifactVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
                    {
                        ArtifactDTO artifactDTO = new ArtifactDTO
                        {
                            Id = artifactVM.Id,
                            Name = artifactVM.Name,
                            Price = artifactVM.Price,
                            DateOfDiscovery = artifactVM.DateOfDiscovery,
                            IsInGoodCondition = artifactVM.IsInGoodCondition,
                            DealerId = artifactVM.DealerId
                        };
                        service.PutArtifact(artifactDTO);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                return View();
            }
            catch
            {
                ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                return View();
            }
        }
        // GET: Artifact/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
            {
                service.DeleteArtifact(id);
            }
            return RedirectToAction("Index");
        }
        // GET: Artifact/SearchByPrice
        [HttpGet]
        public ActionResult SearchByPrice(double? price, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            try
            {
                if (price.HasValue)
                {
                    using (ArtifactService.ArtifactServiceClient service = new ArtifactService.ArtifactServiceClient())
                    {
                        IEnumerable<ArtifactDTO> artifacts = service.GetArtifactsByPrice(price.Value);
                        if (artifacts.Any())
                        {
                            IEnumerable<ArtifactVM> artifactVMs = artifacts.Select(artifact => new ArtifactVM
                            {
                                Name = artifact.Name,
                                Price = artifact.Price,
                                DateOfDiscovery = artifact.DateOfDiscovery,
                                IsInGoodCondition = artifact.IsInGoodCondition,
                                DealerId = artifact.DealerId
                            });
                            IPagedList<ArtifactVM> pagedArtifactVMs = artifactVMs.ToPagedList(pageNumber, pageSize);
                            ViewBag.Dealers = LoadDataUtilities.LoadDealersData();
                            return View("Index", pagedArtifactVMs);
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