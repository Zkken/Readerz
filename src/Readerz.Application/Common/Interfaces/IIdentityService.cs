using System.Threading.Tasks;
using Readerz.Application.Common.Models;

namespace Readerz.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
        Task<string> GetUserNameAsync(string userId);
        Task<string> GetUserIdByUserNameAsync(string userName);
    }
}