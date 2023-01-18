using DotNetBoilerPlate.Domain.DTOs;
using DotNetBoilerPlate.Domain.Interfaces;
using DotNetBoilerPlate.EF.Common.Interfaces;

namespace DotNetBoilerPlate.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IGenericRepository _genericRepository;

        public AuthenticationService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int Register(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool UserExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
