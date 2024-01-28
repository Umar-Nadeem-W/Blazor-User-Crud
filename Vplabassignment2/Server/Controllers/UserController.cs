using Vplabassignment2.Server.Interfaces;
using VpLabAssignment2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vplabassignment2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iuser) 
        {
           _IUser = iuser;
        }
        [HttpGet]

        public async Task<List<User>> Get()
        {
            return await Task.FromResult(_IUser.GetUserDetails());
        }
        [HttpGet("{id}")]

        public IActionResult Get(int id) 
        {
            User user = _IUser.GetUserData(id);
            if(user != null) { return Ok(user); }
            return NotFound();
        }
        [HttpPost]
        public void Post( User user) 
        {
            _IUser.AddUser(user);
        }
        [HttpPost]
        public void Put( User user ) 
        {
            _IUser.UpdateUserDetails(user);
        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id) 
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }

}
