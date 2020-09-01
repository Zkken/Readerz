using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Exceptions;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Interfaces;
using Reader.Application.CardSets.Commands.IncrementCardSetCommand.Models;

namespace Readerz.Web.Infrastructure.Translator.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }

            var res = await _userManager.DeleteAsync(user);

            return res.ToApplicationResult();
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }

            return user.UserName;
        }

        public async Task<string> GetUserIdByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userName);
            }

            return user.Id;
        }
    }

    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}