using Sozluk.Common.Models.RequestModels;

namespace Sozluk.WebApp.Infrastructure.Service.Interfaces
{
    public interface IIdentityService
    {
        bool IsLoggedIn { get; }

        Guid GetUserId();
        string GetUserName();
        string GetUserToken();
        Task<bool> Login(LoginUserCommand command);
        void Logout();
    }
}