using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepositry;
        private readonly IMediatorHandler _bus;
        private readonly ECommerceDBContext _ctx;
        public ProductService(IProductRepository productRepositry, ECommerceDBContext ctx, IMediatorHandler bus)
        {
            _productRepositry = productRepositry;
            _bus = bus;
            _ctx = ctx;
        }
        public void Create(ProductViewModel productViewModel)
        {
            var createProductCommand=new CreateProductCommand(

                productViewModel.Name,
                productViewModel.Description,
                productViewModel.Image,
                productViewModel.Price,
                productViewModel.CategoryId

                );
            _bus.SendCommand(createProductCommand);
        }

        public ProductViewModel GetProducts()
        {
            return new ProductViewModel()
            {
                Products = _productRepositry.GetProducts()
            };
        }
    }
}
