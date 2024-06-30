using Application.Common.Models;

namespace Application.Common.Interfaces
{
    public interface ICustomIdentity
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
