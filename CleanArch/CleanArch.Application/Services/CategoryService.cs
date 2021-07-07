using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
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
        public CategoryService(ICategoryRepository categoryRepository, ECommerceDBContext ctx, IMediatorHandler bus)
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
            _ctx = ctx;
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
    }
}
