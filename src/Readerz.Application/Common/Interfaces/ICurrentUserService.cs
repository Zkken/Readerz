namespace Readerz.Application.Common.Interfaces
{
    /// <summary>
    /// Represents a service that handles information about a user who sends a request.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Id of the user that sent a request.
        /// </summary>
        string UserId { get; }
        /// <summary>
        /// Is the user is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }
    }
}