using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using paysky_task.Dataidentity;
using paysky_task.DTOs;

namespace paysky_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly SignInManager<Applicationuser> signInManager;

        public authenticationController(UserManager<Applicationuser> userManager, SignInManager<Applicationuser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }






        // register 
        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegisterDTO RGSDTO)
        {
            if (ModelState.IsValid)
            {
                Applicationuser user = new Applicationuser();
                {
                    user.UserName = RGSDTO.UserName;
                    user.Email = RGSDTO.Email;
                    user.PasswordHash = RGSDTO.Password;
                    
                        IdentityResult result =  await userManager.CreateAsync(user);
                    if(result.Succeeded == true)
                    {
                        // create taken
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("something is wrong"); 
                    }
                

            };


            }
            else
            {
                return BadRequest("something wrong please check");
            }

           
        }



        // login
        [HttpPost("Login")]
        public async Task<IActionResult> Checklogin(LoginDTO LGDTO)
        {
           Applicationuser user =  await userManager.FindByEmailAsync(LGDTO.Email);
            if (user == null)
            {
                return Unauthorized();
            }
           bool result =  await userManager.CheckPasswordAsync(user,LGDTO.Password);
            if(result == true)
            {
                // create token 
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

            
        }


    }
}
