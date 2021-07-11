using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandeler
{

    public class ProductCommadHandeler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommadHandeler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price=request.Price,
                Image = request.Image,
                CategoryId=request.CategoryId
                
            };
            _productRepository.Add(product);
            return Task.FromResult(true);
        }
    }


    public class UpdateProductCommandHandeler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandeler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetDetails(request.Id);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Image = request.Image;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            _productRepository.update(product);
            return Task.FromResult(true);
        }
    }




    public class DeleteProductCommandHandeler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandeler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var product = _productRepository.GetDetails(request.Id);
            _productRepository.Delete(product.ProductId);
            return Task.FromResult(true);
        }
    }






}
