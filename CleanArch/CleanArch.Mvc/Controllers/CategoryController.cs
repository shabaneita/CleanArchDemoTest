using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            CategoryViewModel model = _categoryService.GetCategories();

            return View(model);
        }
       //Get : Categories/Details/5
        public IActionResult Details(int id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var model = _categoryService.GetCategoryDetails(id);
            //CategoryViewModel model = _categoryService.GetCategoryDetails(id);
            
            return View(model);
        }

        // Get : Categories/create
        public IActionResult Creat() 
        {
            return View();
        }

        //// POST: Categories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoriesEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = UploadedFile(model);

        //        Category category = new Category
        //        {
        //            Name = model.Name,
        //            Content = model.Content,
        //            Image = uniqueFileName,
        //            Products = model.Products,
        //        };
        //        _context.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

    }
}
