using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Controllers
{
    public class RelatedDataController : Controller
    {
        public ISupplierRepository _supplierRepositry;
        private IGenericRepository<ContactDetails> detailsRepo;
        private IGenericRepository<ContactLocation> locsRepo;

        public RelatedDataController(ISupplierRepository sRepo,
            IGenericRepository<ContactDetails> dRepo,
            IGenericRepository<ContactLocation> lRepo)
        {
            _supplierRepositry = sRepo;
            detailsRepo = dRepo;
            locsRepo = lRepo;
        }

        public IActionResult Index()
        {
            return View(_supplierRepositry.GetAll());
        }

        public IActionResult Contacts() => View(detailsRepo.GetAll());
        public IActionResult Locations() => View(locsRepo.GetAll());
    }
}
