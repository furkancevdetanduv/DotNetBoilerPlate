using DotNetBoilerPlate.Domain.DTOs;
using DotNetBoilerPlate.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetBoilerPlate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task Register(UserDto user)
        {
            await _authenticationService.Register(user);
        }

        [HttpGet]
        public async Task<bool> Login(string username, string password)
        {
            return await _authenticationService.Login(username, password);
        }
    }
}
