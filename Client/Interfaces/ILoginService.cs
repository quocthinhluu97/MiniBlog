using MiniBlog.Shared;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiniBlog.Client.Services
{
    public interface ILoginService
    {
        Task Login(LoginDetails loginDetails);
        Task Logout();
        Task SaveToken(HttpResponseMessage response);
        Task SetAuthorizationHeader();
        bool IsLoggedIn {get;set;}
    }
}