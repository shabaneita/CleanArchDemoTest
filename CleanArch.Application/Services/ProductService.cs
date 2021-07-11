using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
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

        private readonly IHostingEnvironment _hostingEnvironment;


        public ProductService(IProductRepository productRepositry, ECommerceDBContext ctx, IMediatorHandler bus, IHostingEnvironment hostingEnvironment)
        {
            _productRepositry = productRepositry;
            _bus = bus;
            _ctx = ctx;
            _hostingEnvironment = hostingEnvironment;

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

        public void Delete(int id)
        {

            Product product = _productRepositry.GetDetails(id);
            _productRepositry.Delete(product.ProductId);

        }

        public Product GetProductDetails(int id)
        {
            var product = _productRepositry.GetDetails(id);
            return product;
        }

        public ProductViewModel GetProducts()
        {
            return new ProductViewModel()
            {
                Products = _productRepositry.GetProducts()
            };
        }

        public void Update(ProductViewModel productViewModel, int id)
        {
            Product product = _productRepositry.GetDetails(id);
            var updateProductCommand = new UpdateProductCommand(
                product.ProductId=productViewModel.ProductId,
                product.Name = productViewModel.Name,
                product.Description = productViewModel.Description,
                product.Image = productViewModel.Image,
                product.Price=productViewModel.Price,
                product.CategoryId=productViewModel.CategoryId
                );
            _bus.SendCommand(updateProductCommand);
        }
    }
}
