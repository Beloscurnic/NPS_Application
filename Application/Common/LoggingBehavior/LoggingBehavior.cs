using MediatR;
using Serilog;

namespace Application.Common.LoggingBehavior
{
    public class LoggingBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        public LoggingBehavior()
        {

        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            //Log.Information("Notes Request: {Name} {@Request}",
            //    requestName, request);

            var response = await next();

            return response;
        }
    }
}
