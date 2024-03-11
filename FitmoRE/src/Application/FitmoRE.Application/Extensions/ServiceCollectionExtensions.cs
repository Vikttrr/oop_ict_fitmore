namespace FitmoRE.Application.Extensions;

using FitmoRE.Application.Services;
using Microsoft.Extensions.DependencyInjection;

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