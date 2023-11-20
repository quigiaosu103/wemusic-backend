using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ArtistController : ControllerBase
    {
        private WeMusicDbContext _wemusicDbContext;
        public ArtistController(WeMusicDbContext context)
        {
            _wemusicDbContext = context;
        }



        [HttpGet]
        public IActionResult GetDepartment()
        {
            var department = _wemusicDbContext.Artists.ToList();
            if (department == null)
            {
                return NotFound($"Department with id  is not found");
            }
            return Ok(department);
        }


        [HttpGet("{id}")]
        public IActionResult GetArtistById(string id)
        {
            var artist = _wemusicDbContext.Artists.Find(id);
            if (artist == null)
            {
                return NotFound($"Artist with id  is not found");
            }
            return Ok(artist);
        }

        [HttpGet("more")]
        public IActionResult GetMoreArtists() {
            var artists = _wemusicDbContext.Artists.Take(30).ToList();
            if(artists == null)
            {
                return NotFound("Artists not found");
            }

            return Ok(artists);
        
        }

        [HttpGet("topfamous")]
        public IActionResult GetTopSongsStream() { 
            var songs = _wemusicDbContext.Artists.OrderBy(s => s.Followers).Take(20).ToList();
            if(songs == null)
            {
                return NotFound("song not found");
            }          
            return Ok(songs);
        }


    }
}
