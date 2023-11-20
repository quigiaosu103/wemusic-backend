using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
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

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _wemusicDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("Account not found");
            }
            return Ok(user);
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

    }
}
