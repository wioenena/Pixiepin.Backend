using FluentValidation;
using MediatR;

namespace Pixiepin.Backend.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class {
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        ArgumentNullException.ThrowIfNull(next);
        if (validators.Any()) {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.Where(r => r.Errors.Count > 0)
                .SelectMany(r => r.Errors)
                .Select(e => new Exceptions.ValidationException(e.ErrorMessage, null))
                .ToList();

            if (failures.Count > 0)
                throw new Exceptions.ValidationException($"Command Validation Errors for type {typeof(TRequest).Name}", failures);
        }

        return await next();
    }
}
