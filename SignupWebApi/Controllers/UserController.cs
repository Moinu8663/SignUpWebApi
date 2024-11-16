using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignupWebApi.Data;
using SignupWebApi.Exceptions;
using SignupWebApi.Modals;
using SignupWebApi.Token;

namespace SignupWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService service;
        private readonly ITokenGenerator tokenservice;
        public UserController(IService service, ITokenGenerator tokenservice)
        {
            this.service = service;
            this.tokenservice = tokenservice;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody] UserModel user)
        {
            service.RegisterUser(user);
            return Ok("Registration Successfully");

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser([FromBody] UserModel user)
        {

            var obj = service.LoginUser(user);
            if (obj != null)
            {
                return Ok(tokenservice.GenerateToken(user));
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }

        [HttpGet("{Mobile_No}")]
        public IActionResult Get(string Mobile_No)
        {
            try
            {
                return Ok(service.GetUserByMobileNo(Mobile_No));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAllUser());
        }
        [HttpPut("{Mobile_No}")]
        public IActionResult Put(string Mobile_No, UserModel user)
        {
            try
            {
                service.UpdateUser(Mobile_No, user);
                return StatusCode(200, "User Updated successfully");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpDelete("{Mobile_No}")]
        public IActionResult Delete(string Mobile_No)
        {
            try
            {
                service.DeleteUser(Mobile_No);
                return StatusCode(200, "Account delete successfully");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
