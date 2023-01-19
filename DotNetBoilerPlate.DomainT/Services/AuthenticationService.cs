using DotNetBoilerPlate.Domain.DTOs;
using DotNetBoilerPlate.Domain.Interfaces;
using DotNetBoilerPlate.EF.Common.Entities;
using DotNetBoilerPlate.EF.Common.Interfaces;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace DotNetBoilerPlate.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IGenericRepository _genericRepository;

        public AuthenticationService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            Expression<Func<User, bool>> predicate = m => m.UserName == username;
            var userEntity = await _genericRepository.FindByFilter(predicate);
            if (userEntity == null || !VeriyfPassword(password, userEntity.PasswordKey, userEntity.PasswordHash))
            {
                return new ServiceResponse<string>()
                {
                    Message = "Username or password is wrong",
                    Success = false
                };
            }           

            return new ServiceResponse<string>()
            {
                Data = GenerateToken()
            };
        }

        public async Task<ServiceResponse<int>> Register(UserDto user)
        {
            if (await UserExist(user.UserName))
            {
                return new ServiceResponse<int>() 
                {
                    Message = "Username exist",
                    Success = false
                };
            }

            CreateHashForPassword(user.Password, out byte[] passwordKey, out byte[] passwordHash);

            var newUser = await _genericRepository.Add(new User()
                        {
                            UserName = user.UserName,
                            PasswordHash = passwordHash,
                            PasswordKey = passwordKey,
                            Email = user.Email,
                        });

            return new ServiceResponse<int>()
            {
                Data = newUser.Id            
            };
        }

        public async Task<bool> UserExist(string username)
        {
            Expression<Func<User, bool>> predicate = m => m.UserName == username;
            if (await _genericRepository.FindByFilter(predicate) == null)
            {
                return false;
            }
            return true;
        }

        private void CreateHashForPassword(string password, out byte[] passwordKey, out byte[] passwordHash)
        {
            var hmac = new HMACSHA512();
            passwordKey = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VeriyfPassword(string password, byte[] passwordKey, byte[] passwordHash)
        {
            var hmac = new HMACSHA512(passwordKey);
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return passwordHash.SequenceEqual(hash);
        }

        private string GenerateToken()
        {
            return string.Empty;
        }
    }
}
