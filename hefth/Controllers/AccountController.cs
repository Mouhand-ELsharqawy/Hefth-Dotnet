using hefth.data.DTO;
using hefth.data.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hefth.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
        }


        //[HttpPost]
        //public async Task<IActionResult> Register(NewUserDto newUserDto)
        //{
        //if(ModelState.IsValid)
        //{
        //    User user = new()
        //    {
        //        UserName = newUserDto.UserName,
        //        Email = newUserDto.Email
        //    };

        //    IdentityResult res = await _userManager.CreateAsync(user, newUserDto.Password);

        //    if (res.Succeeded)
        //    {
        //        return Ok(res);
        //    }else
        //    {
        //        foreach(var item in res.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //    }
        //}

        //return BadRequest(ModelState);
        //}

        
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(NewUserDto newUserDto)
        {
            try
            {
                User user = new()
                {
                    UserName = newUserDto.UserName,
                    Email = newUserDto.Email
                };

                IdentityResult res = await _userManager.CreateAsync(user, newUserDto.Password);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            try
            {
                
                var user = await _userManager.FindByNameAsync(loginUserDto.UserName);
                
                if(user != null && await _userManager.CheckPasswordAsync(user, loginUserDto.Password))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var roles = await _userManager.GetRolesAsync(user);

                    foreach(var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                    }

                    // signingcredentials

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                    var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        issuer: configuration["JWT:Issuer"],
                        audience: configuration["JWT:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: sc
                        );

                    var _token = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Ok( _token );
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
