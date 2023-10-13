using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAPI.Context;
using AngularAPI.Models;
using AngularAPI.Helpers;
using System.Text;
using System.Text.RegularExpressions;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authcontext;

        public UserController(AppDbContext appDbContext)
        {
            _authcontext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest("Invalid request. User object is null.");
            }

            var user = await _authcontext.Users.FirstOrDefaultAsync(x => x.Username == userObj.Username);

            if (user == null)
            {
                return NotFound(new
                {
                    Message = "User Not Found"
                });
            }

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is incorrect" });
            }

            return Ok(new
            {
                Message = "Login Success"
            });
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            //Check Username
            if (await CheckUserNameExistAsync(userObj.Username))
            {
                return BadRequest(new { Message = "Username already exists!!" });
            }



            //Check Email
            if (await CheckEmailExistAsync(userObj.Email))
            {
                return BadRequest(new { Message = "Email already exists!!" });
            }




            //Check Password Strength

            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });



            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            await _authcontext.Users.AddAsync(userObj);
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered"
            });
        }

        private Task<bool> CheckUserNameExistAsync(string username)
        => _authcontext.Users.AnyAsync(x => x.Username == username);


        private Task<bool> CheckEmailExistAsync(string email)
=> _authcontext.Users.AnyAsync(x => x.Email == email);


        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();

            // Minimum length check
            if (password.Length < 8)
                sb.Append("Minimum password length should be 8." + Environment.NewLine);

            // Alphanumeric requirement check
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should contain at least one lowercase letter, one uppercase letter, and one digit." + Environment.NewLine);

            // Special character requirement check
            string specialCharacters = "!@#$%^&*()_+-={}[]|\\:;\"'<>,.?/~`";
            if (!password.Any(c => specialCharacters.Contains(c)))
                sb.Append("Password should contain at least one special character: " + specialCharacters + Environment.NewLine);

            return sb.ToString();
        }





    }
}
