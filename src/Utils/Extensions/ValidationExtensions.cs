using FluentValidation.Results;
using System.Text;

namespace Utils.Extensions;

public static class ValidationExtensions
{
    public static Response.Response ToResponse(this ValidationResult result)
    {
        if (result.IsValid)
        {
            return new Response.Response(true, "Validado com sucesso");
        }

        var sb = new StringBuilder();

        foreach (ValidationFailure item in result.Errors)
        {
            sb.AppendLine(item.ErrorMessage);
        }

        return new Response.Response(false, sb.ToString());
    }
}
