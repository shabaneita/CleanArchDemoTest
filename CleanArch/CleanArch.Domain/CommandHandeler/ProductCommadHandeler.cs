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

        public ProductCommadHandeler(IProductRepository courseRepository)
        {
            _productRepository = courseRepository;
        }
        public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
           
                Image = request.Image,
                CategoryId=request.CategoryId
                
            };
            _productRepository.Add(product);
            return Task.FromResult(true);
        }
    }
}
