using CarRental.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRental.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationController( UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(string userName,string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user!= null && await _userManager.CheckPasswordAsync(user,password))
                {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userName),
                };
                foreach( var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7286/",
                    claims: authClaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(authSigInKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string firstName, string lastName, int age, string city, string email,string userName, string password)
        {
            var userExists = await _userManager.FindByNameAsync(userName);
            if (userExists != null)
                return BadRequest("User is already registered");
            User userReg = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                City = city,
                Email = email,
                UserName = userName
            };
          

            var result = await _userManager.CreateAsync(userReg, password);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user");
            }
            return Ok("User Created Succesfuly");
        }

        [HttpPost]
        [Route("assing-role")]

        public async Task<IActionResult> AddToRole(string userName,string roleName)
        {
            var userExists = await _userManager.FindByNameAsync(userName);
            if (userExists == null)
                return BadRequest("User is already registered");
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                var roleAdded = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
            var addRoleToUser = await _userManager.AddToRoleAsync(userExists, roleName);
            if (!addRoleToUser.Succeeded)
            {
                return BadRequest("Failed to add role to user");
            }
            return Ok($"User added to {roleName} role");
        }

    }
}
