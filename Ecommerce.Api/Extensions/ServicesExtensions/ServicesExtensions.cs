using Ecommerce.Contracts;
using Ecommerce.Repository;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Extensions;

public static class ServicesExtensions
{


    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(
            opts =>
                opts.AddDefaultPolicy(
                    policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                )
        );
    }

    public static void ConfigureApiBehaviorOptions(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(opts =>
        {
            // To enable our custom responses from the actions for validation
            opts.SuppressModelStateInvalidFilter = true;
        });
    }

    public static void ConfigureSqlServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SqlServerString");
            if (string.IsNullOrEmpty(connectionString))
                connectionString = Environment.GetEnvironmentVariable("SqlServerString");
            Console.WriteLine(connectionString);
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Ecommerce.Api"));
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                options.EnableSensitiveDataLogging();
        });

        using var sp = services.BuildServiceProvider();
        var context = sp.GetService<RepositoryContext>();
        context?.Database.Migrate();
        context?.Database.EnsureCreated();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection service) =>
       service.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureAutoMapper(this IServiceCollection services) =>
      services.AddAutoMapper(typeof(MapperProfile).Assembly);


}
