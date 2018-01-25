using Dashboard.API.Models;
using System.Threading.Tasks;
namespace Dashboard.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register (User user, string password);
        Task<User> Login (string username, string password);
        Task<bool> UserExits (string username);
        
    }
}