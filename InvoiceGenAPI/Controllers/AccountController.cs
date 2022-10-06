using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Helpers;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;
using InvoiceGenAPI.Services.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly IAccountService _accountService;

        public AccountController(InvoiceGenDBContext context, JwtSettings jwtSettings, IAccountService accountService)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("AccountCreate")]
        public IActionResult PostUser(User user)
        {
            if (_accountService.CheckIfUserNameExist(user.UserNickName))
            {
                return BadRequest("Nickname already in Use");
            }
            else if (_accountService.CheckIfEmailExist(user.UserEmail))
            {
                return BadRequest("Email already in Use");
            }

            if (!_accountService.RegisterUserToDb(user))
            {
                return BadRequest("Error creating user");

            }

            return Ok();
        }

        [HttpPost("AccountLogin")]
        public IActionResult GetToken(UserLogin userLogin)
        {
            UserToken token = _accountService.UserLogin(userLogin);

            if (token is null)
            {
                return BadRequest("Wrong credentials");
            }
            return Ok(token);
        }

        [HttpGet] // TODO: Mejorar logica y poderes administrador. 
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            var searchAllUsers = from user in _context.Users select user;

            return Ok(searchAllUsers);
        }
    }
}
