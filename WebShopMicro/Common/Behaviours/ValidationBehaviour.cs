﻿using Common.CQRS;
using FluentValidation;
using MediatR;

namespace Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var errors = validationResults
                .Where(v => v.Errors.Any())
                .SelectMany(v => v.Errors)
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
