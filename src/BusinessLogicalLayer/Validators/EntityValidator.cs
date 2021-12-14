using FluentValidation;
using MetaData.Entities;
using Utils.Validators;

namespace BusinessLogicalLayer.Validators;

public class EntityValidator<T> : AbstractValidator<T> where T : Entity
{
    public void ValidateId()
    {
        RuleFor(x => x.ID).SetValidator(new IdValidator());
    }
}
