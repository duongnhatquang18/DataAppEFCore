using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string category = null, decimal? price = null, bool includeRelatedData = true)
        {
            var products = _repository.GetFilterProduct(category, price, includeRelatedData);
            ViewBag.includeRelated = includeRelatedData;
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", _repository.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            System.Console.Clear();
            _repository.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
