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
 

    public class CategoryCommadHandeler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommadHandeler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.Name,
                Content = request.Content,
                Image = request.Image,
            };
            _categoryRepository.Add(category);
            return Task.FromResult(true);
        }
    }
}
