using _19070006008_midterm.Models;
using Microsoft.AspNetCore.Mvc;
using _19070006008_midterm.Logic.Abstract;

namespace _19070006008_midterm.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;  
        }

        
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var user = await _userManager.SignUp(model);
            return Ok(user);
        }

        
        [HttpPost]
        public IActionResult SignIn([FromBody] SignInModel model)
        {
            var user = _userManager.SignIn(model);
            return Ok(user);
        }
    }
}
