using CleanArch.Application.ViewModels;
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
        void Create(ProductViewModel productViewModelViewModel);
    }
}
