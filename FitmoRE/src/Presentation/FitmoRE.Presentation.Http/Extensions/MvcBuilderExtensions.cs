using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace FitmoRE.Presentation.Http.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddPresentationHttp(this IMvcBuilder builder)
    {
        builder.Services.AddControllers(opts =>
            opts.Conventions.Add(new RouteTokenTransformerConvention(new ToKebabParameterTransformer())));
        return builder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);
    }
}