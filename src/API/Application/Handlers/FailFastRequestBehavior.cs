using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IResponse, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var failures = _validators.Select(v => v.Validate(request)).SelectMany(result => result.Errors).Where(f => f != null).ToList();

        return failures.Any() ? Errors(failures) : next(); 
    }

    private static Task<TResponse> Errors(List<ValidationFailure> failures)
    {
        var response = new TResponse();

        foreach (var failure in failures)
        {
            response.AddError(failure.ErrorMessage);
        }

        return Task.FromResult(response);
    }
}
