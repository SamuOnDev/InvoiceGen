using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly IUsersService _usersService;

        public UsersController(InvoiceGenDBContext context, IUsersService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        // GET: api/Users/5
        [HttpGet]
        [Route("GetUser/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User? user = await _usersService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut]
        [Route("UpdateUser/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> PutUser(int id, UserEdit user)
        {
            var passCheck = (from userCheck in _context.Users
                           where userCheck.UserId.Equals(id) && userCheck.UserPassword.Equals(user.UserPassword)
                           select userCheck).FirstOrDefault();

            if (passCheck is null) { return BadRequest("Wrong password"); }

            bool? isUpdated = await _usersService.UpdateUserAsync(id, user);

            if (isUpdated is null) { return NotFound("User not found"); }
            if (isUpdated is false) { return BadRequest("User not exist"); }

            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        [Route("CreateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public IActionResult PostUser(User user)
        {
            if (_usersService.CheckIfUserNameExist(user.UserNickName))
            {
                return BadRequest("Nickname already in Use");
            }
            else if (_usersService.CheckIfEmailExist(user.UserEmail))
            {
                return BadRequest("Email already in Use");
            }

            if (!_usersService.RegisterUserToDb(user))
            {
                return BadRequest("Error creating user");

            }

            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            if (tokenId != id)
            {
                return BadRequest("Users not match");
            }

            bool? deleted = await _usersService.DeleteUserByIdAsync(id);

            if (deleted is false)
            {
                return BadRequest("Something went wrong user not deleted");
            }

            return Ok();
        }
    }
}
