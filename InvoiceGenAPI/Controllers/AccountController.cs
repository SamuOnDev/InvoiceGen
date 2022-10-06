using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.JwtModel;
using InvoiceGenAPI.Services.Account;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly IAccountService _accountService;

        public AccountController(InvoiceGenDBContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
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
