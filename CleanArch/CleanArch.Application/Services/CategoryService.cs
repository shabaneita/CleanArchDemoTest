using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _bus;
        private readonly ECommerceDBContext _ctx;



        private readonly IHostingEnvironment _hostingEnvironment;
        public CategoryService(ICategoryRepository categoryRepository, ECommerceDBContext ctx, IMediatorHandler bus, IHostingEnvironment hostingEnvironment)
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
            _ctx = ctx;
            _hostingEnvironment = hostingEnvironment;
           
        }
        public void Create(CategoryViewModel categoryViewModel)
        {
            var createCategoryCommand = new CreateCategoryCommand(

                categoryViewModel.Name,
                categoryViewModel.Content,
                categoryViewModel.Image
                );
            _bus.SendCommand(createCategoryCommand);
        }
        public void Update(CategoryViewModel categoryViewModel ,int id  )
        {
            Category category = _categoryRepository.GetDetails(id);
            var updateCategoryCommand = new UpdateCategoryCommand(

                category.CategoryId=categoryViewModel.CategoryId,
                category.Name=categoryViewModel.Name,
                category.Content=categoryViewModel.Content,
                category.Image=categoryViewModel.Image

                );
            _bus.SendCommand(updateCategoryCommand);
        }

        public CategoryViewModel GetCategories()
        {
            return new CategoryViewModel()
            {
                Categories = _categoryRepository.GetCategories()
            };
        }

        public Category GetCategoryDetails(int id)
        {

            var category = _categoryRepository.GetDetails(id);
            return category;

        }

        public void Delete(int id)
        {
            Category category = _categoryRepository.GetDetails(id);
            _categoryRepository.Delete(category.CategoryId);

        }
    }
}
