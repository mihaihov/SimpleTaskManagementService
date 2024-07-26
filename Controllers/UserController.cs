using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TaskManagementService{

    [Route("[controller]")]
    public class UserController : Controller {

        private readonly UserManager<IdentityUser> _userManager;   

        public UserController(UserManager<IdentityUser> userManager) 
        {
            _userManager = userManager;
        }

        [HttpPost("getuserbyemail", Name="GetUserByEmail"), Authorize]
        public async Task<IActionResult> GetUserByEmail([FromBody] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null){
                return NotFound();
            }

            return Ok(user);
        }
    }
}