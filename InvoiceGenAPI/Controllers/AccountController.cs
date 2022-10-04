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
        [Route("CreateUser")]
        public IActionResult PostUser(User user)
        {
            if (_accountService.CheckIfUserNameExist(user.UserName))
            {
                return BadRequest("UserName already in Use");
            }
            else if (_accountService.CheckIfEmailExist(user.UserEmail))
            {
                return BadRequest("Email already in Use");
            }

            if (_accountService.RegisterUserToDb(user) is not null)
            {
                Console.WriteLine("Usuario Creado");
                return Ok(user);
            }
            else
            {
                return BadRequest("Something went Wrong");
            }
        }

        [HttpPost("login")]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                User? userDb = (from user in _context.Users
                                where user.UserEmail == userLogin.UserEmail && user.UserPassword == userLogin.UserPassword
                                select user).FirstOrDefault();

                if (userDb is null)
                {
                    return BadRequest("Wrong Credentials");
                }

                return Ok(JwtHelpers.GenTokenKey(userDb, _jwtSettings));

            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            var searchAllUsers = from user in _context.Users select user;

            return Ok(searchAllUsers);
        }
    }
}
