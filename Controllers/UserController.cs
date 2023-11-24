using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private String jwt="";
        private WeMusicDbContext _wemusicDbContext;
        

        public UserController(WeMusicDbContext context)
        {
            _wemusicDbContext = context;
        }


        [HttpGet]
        public IActionResult GetUser() {
            var users = _wemusicDbContext.Users.ToList();
            if (users == null)
            {
                return NotFound("List users not found");
            }
            return Ok(users);
        }

       
        [HttpPost]
        public IActionResult AddUser(User newUSer) {
            var user = _wemusicDbContext.Users.Find(newUSer.UserName);
            if (user != null) {
                return BadRequest("username is existed!");
            }
            _wemusicDbContext.Users.Add(newUSer);
            _wemusicDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserInfo(User newUser) {
            var user = _wemusicDbContext.Users.Find(newUser.UserName);
            if (user == null)
            {
                return NotFound("Users not found");
            }
            user.Name = newUser.Name;
            user.Image = newUser.Image;
            user.Name = newUser.Name;
            _wemusicDbContext.Update(user);
            _wemusicDbContext.SaveChanges();
            return Ok("Update successfully!");
        }

        [HttpPut("newpassword/{id}")]
        public IActionResult UpdateUser(User newUser)
        {
            var user = _wemusicDbContext.Users.Find(newUser.UserName);
            if (user == null)
            {
                return NotFound("Users not found");
            }
            user.PasswordHash = newUser.PasswordHash;
            _wemusicDbContext.Update(user);
            _wemusicDbContext.SaveChanges();
            return Ok("Update successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            //var user_laylist = _wemusicDbContext.

            var user = _wemusicDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("userId notfound");
            }
            _wemusicDbContext.Users.Remove(user);
            _wemusicDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("{username}")]
        public IActionResult login(string username, string password) {
            var user = _wemusicDbContext.Users.Find(username);
            if(user == null)
            {
                return NotFound("user not found");
            }

            if(user.PasswordHash != password) {
                return BadRequest("Invalid authen info");
            }

            if(user.UserName == "Admin")
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Access", "Admin")
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SIUUUUUUUUUUUUUUU"));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken("JWTAuthenticationServer",
                    "JWTServiceAccessToken",
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                jwt = new JwtSecurityTokenHandler().WriteToken(token);
                Response.Cookies.Append("jwtCookie", jwt, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddHours(1), // Set expiration time for the cookie
                    HttpOnly = true, // Make the cookie accessible only through HTTP requests
                    Secure = true, // Require HTTPS to send the cookie
                    SameSite = SameSiteMode.None // Set the SameSite attribute as needed
                });

            }

            return Ok(new
            {
                user, jwt
            });
        }


    }
}
