using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment hostEnvironment)
        {
            _categoryService = categoryService;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            CategoryViewModel model = _categoryService.GetCategories();

            return View(model);
        }
        //Get : Categories/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _categoryService.GetCategoryDetails(id);
            //CategoryViewModel model = _categoryService.GetCategoryDetails(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryviewmodel)
        {
            if (ModelState.IsValid)
            {
                string filename = UploadedFile(categoryviewmodel.File);
                if (filename == null)
                {
                    ModelState.AddModelError("", "Please Select image");
                }
                categoryviewmodel.Image = filename;
                _categoryService.Create(categoryviewmodel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryviewmodel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = _categoryService.GetCategoryDetails(id);
            var model = new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Content = category.Content,
                Image = category.Image
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel categoryviewmodel)
        {
            if (ModelState.IsValid)
            {
                string filename = UploadFile(categoryviewmodel.File, categoryviewmodel.Image);
                categoryviewmodel.Image = filename;
                _categoryService.Update(categoryviewmodel, id);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryviewmodel);

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
            var category = _categoryService.GetCategoryDetails(id);
            var model = new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Content = category.Content,
                Image = category.Image
            };
            return View(model);
        }


        // POST: Categories/Delete/5
   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             
            _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
