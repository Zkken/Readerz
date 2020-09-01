using System.Threading.Tasks;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Models;

namespace Reader.Application.CardSets.Commands.IncrementCardSetCommand.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
        Task<string> GetUserNameAsync(string userId);
        Task<string> GetUserIdByUserNameAsync(string userName);
    }
}