using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }
    
    private readonly ILogger<TRequest> _logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

		try
		{
            _logger.LogInformation("Executing command {command}", name);
            
            var result = await next();
            
            _logger.LogInformation("Command {command} processed successfully", name);
            
            return result;
		}
		catch (Exception exception)
		{
            _logger.LogError(exception, "Command {command} processing failed", name);

			throw;
		}
    }
}
