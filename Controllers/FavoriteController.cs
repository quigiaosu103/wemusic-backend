using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wemusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly WeMusicDbContext _wemusicDbContext;
        public FavoriteController(WeMusicDbContext context) {
            _wemusicDbContext = context;
        }
        [HttpGet]
        public IActionResult IsUserLiked(string songId, string username) {
            var result = _wemusicDbContext.Favorite
                .Where(favorite => favorite.User.UserName == username)
                .SelectMany(favorite => favorite.Songs.Where(song => song.Id == songId).ToList());
            if(result == null)
            {
                return BadRequest("Undefine");
            }
            if(result.Count() == 0 )
            {
                return Ok(false);
            }
            return Ok(true);
        
        }
    }
}
