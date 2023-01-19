using DotNetBoilerPlate.Domain.DTOs;

namespace DotNetBoilerPlate.Domain.Interfaces
{
    public interface IAuthenticationService
    {

        public Task<ServiceResponse<int>> Register(UserDto user);
        public Task<ServiceResponse<string>> Login(string username, string password);
        public Task<bool> UserExist(string username);
    }
}
