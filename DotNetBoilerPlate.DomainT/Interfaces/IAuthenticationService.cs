using DotNetBoilerPlate.Domain.DTOs;

namespace DotNetBoilerPlate.Domain.Interfaces
{
    public interface IAuthenticationService
    {

        public Task<int> Register(UserDto user);
        public Task<bool> Login(string username, string password);
        public Task<bool> UserExist(string username);
    }
}
