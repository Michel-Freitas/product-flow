using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductFlow.Core.Application.Model;
using ProductFlow.Core.Application.UseCase.Files.UploadFile;
using ProductFlow.Core.Domain.Interfaces.Repository;
using ProductFlow.Core.Domain.Interfaces.Service;
using ProductFlow.Core.Domain.Service.Service;
using ProductFlow.Core.Infra.Dao.Context;
using ProductFlow.Core.Infra.Dao.Repository;
using ProductFlow.Core.Infra.Dao.UnitOfWork;
using ProductFlow.Core.Infra.MessageBroker.DI;
using ProductFlow.Core.Infra.Storage.DI;

namespace ProductFlow.Core.Infra.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddDependencyDbContext(configuration);
            services.AddDependencyAppService();
            services.AddDependencyService();
            services.AddDependencyRepository();

            services.AddDependencyStorage(configuration);
            services.AddDependencyMessageBroker(configuration);
        }

        private static void AddDependencyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }

        private static void AddDependencyAppService(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<UploadFileCommand, DefaulResult>, UploadFileCommandHandler>();
        }

        private static void AddDependencyService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
        }

        private static void AddDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
