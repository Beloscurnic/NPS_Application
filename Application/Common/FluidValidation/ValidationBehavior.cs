using FluentValidation;
using MediatR;
using Serilog;

namespace Application.Common.FluidValidation
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            // Выполнить предобработку

            // Создание контекста валидации для запроса
            var context = new ValidationContext<TRequest>(request);

            // Выполнение валидации запроса с использованием всех валидаторов
            var failures = _validators
                .Select(v => v.Validate(context)) // Применение каждого валидатора к контексту
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null) // Фильтрация ошибок (удаление null значений)
                .ToList();

            if (failures.Count != 0)
            {            
                throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
