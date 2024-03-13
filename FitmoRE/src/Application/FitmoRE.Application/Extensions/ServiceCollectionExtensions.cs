using FitmoRE.Application.Services;
using FitmoRE.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FitmoRE.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IPaymentService, PaymentService>();
        collection.AddScoped<IRoomService, RoomService>();
        collection.AddScoped<ISubscriptionService, SubscriptionService>();
        collection.AddScoped<ITrainingService, TrainingService>();
        collection.AddScoped<IUserService, UserService>();
        return collection;
    }
}