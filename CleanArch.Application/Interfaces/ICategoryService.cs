using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel GetCategories();
        public Category GetCategoryDetails(int id);
        //IEnumerable<CategoryViewModel> GetCategories();
        void Create(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel,int id );
        void Delete(int id);
    }
}
