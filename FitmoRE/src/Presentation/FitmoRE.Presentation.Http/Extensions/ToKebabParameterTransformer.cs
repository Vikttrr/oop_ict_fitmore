using System.Text.RegularExpressions;

namespace FitmoRE.Presentation.Http.Extensions;
public class ToKebabParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        // string newValue;
        // newValue = value.ToString();
        return value != null
            ? Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower()
            : null;
    }
}