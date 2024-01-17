using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<IdentityRole> roleManager;
        public authenticationController(UserManager<Applicationuser> userManager, SignInManager<Applicationuser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        // add role 
        [HttpPost]
        [Authorize(Roles ="Employee")]
        public async Task<IActionResult> addrole(NewRoleDTO newRoleDTO)
        {
            if(ModelState.IsValid)
            {
                IdentityRole modelrole = new()
                {
                    Name = newRoleDTO.RoleName
                };
               IdentityResult result =  await roleManager.CreateAsync(modelrole);
                if (result.Succeeded)
                {
                    
                    return Ok(result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty ,"sorry this name already saved " );
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok();
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
                        // add role 
                        await userManager.AddToRoleAsync(user,"applicant");
                       // await userManager.AddToRoleAsync(user, "Employee");

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
