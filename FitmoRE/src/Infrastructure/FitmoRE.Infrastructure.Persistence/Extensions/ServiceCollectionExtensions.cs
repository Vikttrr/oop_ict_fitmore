using FitmoRE.Application.Abstractions.Persistence;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using FitmoRE.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitmoRE.Infrastructure.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        AddContext(collection, configuration);

        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        collection.AddScoped<IPaymentRepository, PaymentRepository>();
        collection.AddScoped<IRoomRepository, RoomRepository>();
        collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        collection.AddScoped<ITrainingRegistrationRepository, TrainingRegistrationRepository>();
        collection.AddScoped<ITrainingRepository, TrainingRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        return collection;
    }

    private static IServiceCollection AddContext(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));

        return collection;
    }
}