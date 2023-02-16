using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patterson.Application.Interfaces.Services;
using Patterson.Application.Services;
using Patterson.Domain.Interfaces;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Infrastructure.Persistence;
using Patterson.Infrastructure.Persistence.Repositories;
using System.Reflection;

namespace Patterson.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var usersDbConnectionString = configuration.GetConnectionString("usersDbConnection");

            if (usersDbConnectionString == "InMemory")
            {
                services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase(databaseName: "UsersDatabase"));
            } else if (usersDbConnectionString == "InMemoryNewRoot")
            {
                services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase(databaseName: "UsersDatabase", new InMemoryDatabaseRoot()));
            }
            else
            {
                services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(usersDbConnectionString,
                b => b.MigrationsAssembly(typeof(IUserDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            }

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IUserDbContext>(provider => provider.GetService<UserDbContext>());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IFormRepository, FormRepository>();

            return services;
        }
    }
}