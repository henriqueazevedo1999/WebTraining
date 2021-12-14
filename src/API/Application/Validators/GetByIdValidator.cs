using ClienteAPI.Application.Queries;
using FluentValidation;
using Utils.Validators;

namespace ClienteAPI.Application.Validators;

public class GetByIdValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdValidator()
    {
        RuleFor(x => x.Id).SetValidator(new IdValidator());
    }
}
