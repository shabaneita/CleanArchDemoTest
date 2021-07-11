using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        //IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel GetProducts();
        public Product GetProductDetails(int id);
        void Create(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel, int id);
        void Delete(int id);
    }
}
