using Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest>: IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly IUser _user;
        private readonly ICustomIdentity _identity;

        public LoggingBehaviour(ILogger logger, IUser user, ICustomIdentity identity)
        {
            _logger = logger;
            _user = user;
            _identity = identity;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.Id ?? string.Empty;
            string? userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identity.GetUserNameAsync(userId);
            }
            _logger.LogInformation("Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName , request);
        }
    }
}
