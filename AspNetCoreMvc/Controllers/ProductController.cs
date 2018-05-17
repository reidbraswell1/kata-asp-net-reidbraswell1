using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITB.Shared;

namespace AspNetCoreMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodRepo;

        public ProductController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }
        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _prodRepo.GetProducts();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var prod = _prodRepo.GetProduct(id);
            return View(prod);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            //_prodRepo.AddProduct(prod);
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var prod = new Product { Name=collection["Name"] };
                _prodRepo.AddProduct(prod);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id, string name)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var name = collection["Name"];
                Product prod = new Product { Id = id, Name = name };
                _prodRepo.UpdateProduct(prod);
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = _prodRepo.GetProduct(id);
            //var prodAsp = new AspNetCoreMvc.Models.Product();
            //prodAsp.Id = id;
            //prodAsp.Name = prod.Name;
            return View(prod);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var rowsAffected = _prodRepo.DeleteProduct(id);
                if(rowsAffected <= 0)
                {
                    throw new Exception();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}