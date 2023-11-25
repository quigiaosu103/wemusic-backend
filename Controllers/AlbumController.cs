using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController: ControllerBase
    {
        private WeMusicDbContext _wemusicDbContext;
        public AlbumController(WeMusicDbContext context)
        {
            _wemusicDbContext = context;
        }

        [HttpGet]
        public IActionResult GetAlbum() {
            var albums = _wemusicDbContext.Albums.Take(20).ToList();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(string id)
        {
            var album = _wemusicDbContext.Albums.Find(id);
            return Ok(album);
        }

        [HttpGet("more")]
        public IActionResult GetMoreAlbums() {
            var albums = _wemusicDbContext.Albums.Take(30).ToList();
            if(albums == null)
            {
                return NotFound("Albums not found");
            }
            return Ok(albums);
        }


    }
}
