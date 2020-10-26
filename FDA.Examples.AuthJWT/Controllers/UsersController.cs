using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FDA.Examples.AuthJWT.Models;
using FDA.Examples.AuthJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FDA.Examples.AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            var response = _userService.Register(model);

            if (response == false)
                return BadRequest(new { message = "Error" });

            return Ok(response);
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

    }
}
