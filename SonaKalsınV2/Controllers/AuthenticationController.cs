using DotNetBoilerPlate.Domain.DTOs;
using DotNetBoilerPlate.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetBoilerPlate.API.Controllers
{
    [Route("api/[Authentication]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ServiceResponse<int>> Register(UserDto user)
        {
            return await _authenticationService.Register(user);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            return await _authenticationService.Login(username, password);
        }
    }
}
