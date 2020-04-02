using ContactAPI.Domain.Request;
using ContactAPI.Domain.Response;
using ContactAPI.Models;
using ContactAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("/identity/register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authRespone = await _identityService.RegisterAsync(request.Email, request.Password, request.ConfirmPassword);

            if (!authRespone.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    ErrorMessages = authRespone.ErrorMessages
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authRespone.Token
            });
        }

        [HttpPost("identity/login")]
        public async Task<IActionResult> UserLoginRequest([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    ErrorMessages = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    ErrorMessages = authResponse.ErrorMessages
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}
