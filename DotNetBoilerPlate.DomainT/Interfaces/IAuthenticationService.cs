using DotNetBoilerPlate.Domain.DTOs;

namespace DotNetBoilerPlate.Domain.Interfaces
{
    public interface IAuthenticationService
    {

        public int Register(UserDto user);
        public string Login(string username, string password);
        public bool UserExist(string username);
    }
}
