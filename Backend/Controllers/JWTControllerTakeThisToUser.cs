using Backend.Microservice.JWT;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JWTControllerTakeThisToUser:ControllerBase
    {
        private readonly LoginUser loginUser;
        private readonly IUser user;

        public JWTControllerTakeThisToUser(LoginUser loginUser, IUser user)
        {
            this.loginUser = loginUser;
            this.user = user;
        }

        [HttpPost]
        [Route("login-jwt")]
        public IActionResult Login([FromBody] LoginUser.Request request)
        {
            try
            {
                var token = loginUser.Handle(request);
                return Ok(new
                {
                    Token = token
                });
            }
            catch(Exception ex)
            {
                return Unauthorized(
                    new
                    {
                        Message = ex.Message,
                    }
                );
            }
        }

        [HttpGet]
        [Route("profile-jwt")]
        [Authorize]// This makes the endpoint require authentication
        public IActionResult GetUserProfile()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(
                        new 
                        { 
                            message = "Invalid token" 
                        });
                }

                //Get user from repository
                int Id = int.Parse(userId);
                var userRecord =  user.GetSingleRecord(Id);
                if (userRecord == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                var profile = new 
                {
                    UserId = userRecord.Id,
                    Email = userRecord.Email,
                    FirstName = userRecord.FirstName,
                    LastName = userRecord.LastName,
                    Password = userRecord.Password,
                    Driver = userRecord.Driver ?? null,
                    Customer = userRecord.Customer ?? null
                };

                return Ok(profile);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}
