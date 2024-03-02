using FluentValidation;
using MediatR;

namespace ContentManager.Infrastructure.MediatR;

public class Validator<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures =
            validators
                .Select(x => x.Validate((request)))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .ToList();

        if (failures.Count is not 0)
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}