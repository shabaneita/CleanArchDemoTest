using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{
    public class ProductController : Controller
    {


        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IWebHostEnvironment hostEnvironment, ICategoryService categoryService)
        {
            _productService = productService;
            _hostEnvironment = hostEnvironment;
            _categoryService = categoryService;
        }

        // GET: productController
        public ActionResult Index()
        {
            ProductViewModel model = _productService.GetProducts();

            return View(model);
        }

        // GET: productController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var model = _productService.GetProductDetails(id);
            //CategoryViewModel model = _categoryService.GetCategoryDetails(id);

            return View(model);
        }

        // GET: productController/Create
        [HttpGet]

        public ActionResult Create()
        {
            var model = new ProductViewModel
            {
                Categories = _categoryService.GetCategories().Categories.ToList()
            };
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");

            return View(model);
        }

        // POST: productController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productviewmodel)
        {
            if (ModelState.IsValid)
            {
                string filename = UploadedFile(productviewmodel.File);
                if (filename == null)
                {
                    ModelState.AddModelError("", "Please Select image");
                }
                productviewmodel.Image = filename;
                _productService.Create(productviewmodel);
                return RedirectToAction(nameof(Index));
            }
            return View(productviewmodel);
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = _productService.GetProductDetails(id);
            var model = new ProductViewModel
            {
                ProductId=product.ProductId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price=product.Price,
                Description = product.Description,
                Image = product.Image,
                Categories = _categoryService.GetCategories().Categories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                string filename = UploadFile(productViewModel.File, productViewModel.Image);
                productViewModel.Image = filename;
                _productService.Update(productViewModel, id);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = _categoryService.GetCategories().Categories.ToList();
            return View(productViewModel);

        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            else
            {
                uniqueFileName = "100c4b49-f8ab-4272-988e-1739500fc52e_No-Photo-Available.jpg";
            }
            return uniqueFileName;

        }
        string UploadFile(IFormFile File, string ImageUrl)
        {
            string uniqueFileName = null;
            if (File != null)
            {
                string Uploads = Path.Combine(_hostEnvironment.WebRootPath, "images");
                string UniqueFileName = Guid.NewGuid() + "_" + File.FileName;
                string NewPath = Path.Combine(Uploads, UniqueFileName);
                string OldFileName = ImageUrl;
                string OldPath = Path.Combine(Uploads, OldFileName);
                if (NewPath != OldPath)
                {
                    System.IO.File.Delete(OldPath);
                    File.CopyTo(new FileStream(NewPath, FileMode.Create));

                }
                return UniqueFileName;
            }
            else
            {
                uniqueFileName = "100c4b49-f8ab-4272-988e-1739500fc52e_No-Photo-Available.jpg";
            }
            return ImageUrl;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _productService.GetProductDetails(id);
            var model = new ProductViewModel
            {
                ProductId=product.ProductId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price=product.Price,
                Description = product.Description,
                Image = product.Image
            };
            return View(model);
        }

        // POST: Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
