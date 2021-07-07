using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandeler;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Bus;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.IoC
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {


            //Domain InMemoryBus MeduatiR
            services.AddScoped<IMediatorHandler, InMEmoryBus>();

            //Domain Handeler
            services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CategoryCommadHandeler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, bool>, ProductCommadHandeler>();



            //Application Layer
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            //Infra Data Layer=> Repositry iin infradata ...(courserepo) to Domain (IcourseRepo)
            services.AddScoped<ICategoryRepository, CategoryRepositry>();
            services.AddScoped<IProductRepository, ProductRepositry>();


            services.AddScoped<ECommerceDBContext>();
        }
    }
}
