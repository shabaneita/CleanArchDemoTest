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


    public class UpdateCategoryCommandHandeler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandeler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetDetails(request.Id);
            
            _categoryRepository.update(category);
            return Task.FromResult(true);
        }
    }

    public class DeleteCategoryCommandHandeler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandeler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = _categoryRepository.GetDetails(request.Id);
            _categoryRepository.Delete(category.CategoryId);
            return Task.FromResult(true);
        }
    }

}
