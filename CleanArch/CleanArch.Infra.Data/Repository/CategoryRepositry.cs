using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class CategoryRepositry : ICategoryRepository
    {
        private readonly ECommerceDBContext _ctx;

        public CategoryRepositry(ECommerceDBContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _ctx.Categories;
        }

        public Category GetDetails(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
        }
    }
}
