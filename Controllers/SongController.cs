using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private WeMusicDbContext _wemusicDbContext;

        public SongController(WeMusicDbContext context)
        {
            _wemusicDbContext = context;
        }

        [HttpGet("{id}")]
        public ActionResult GetSongById(string id) {
            var result = _wemusicDbContext.Songs
            .Where(song => song.Id == id)
            .Join(_wemusicDbContext.Albums, song => song.album.Id, album => album.Id, (song, album) => new { song, album })
            .Select(combined => new
            {
                id = combined.song.Id,
                name = combined.song.Name,
                image = combined.album.Image,
                src = combined.song.Src,
                artist = _wemusicDbContext.Albums.Where(album => album.Id == combined.album.Id).SelectMany(album => album.Artists).ToList()

            });
            return Ok(result);
        }

        [HttpGet("byAlbum/{id}")]
        public ActionResult GetSongsByAlbum(string id) {
            var songs = _wemusicDbContext.Albums
                .Where(album => album.Id == id)
                .SelectMany(album => album.Songs
                .Select(song => new
                    {
                        id = song.Id,
                        name = song.Name,
                        src = song.Src,
                        stream  =song.Stream,
                        type = song.Type,
                        image = song.album.Image,
                        artist = _wemusicDbContext.Albums
                        .Where(album => album.Id == id)
                        .SelectMany(album => album.Artists)
                        .ToList()
                    })
                )
                .ToList();
                
            if(songs == null)
            {
                return BadRequest("Album not found");
            }
            return Ok(songs);
        }

        [HttpGet]
        public ActionResult GetTopSongs(){
            var result = _wemusicDbContext.Songs
                .Join(_wemusicDbContext.Albums, song => song.album.Id, album => album.Id, (song, album) => new {
                    id = song.Id,
                    name = song.Name,
                    stream = song.Stream,
                    type = song.Type,
                    image = album.Image,
                    src = song.Src,
                    artist = _wemusicDbContext.Albums
                        .Where(ab => ab.Id == album.Id)
                        .SelectMany(album => album.Artists)
                        .ToList()
                }).OrderBy(song => song.stream)
                .Take(7)
                .ToList();
            if(result==null)
            {
                return NotFound("song not found");
            }
            return Ok(result);
        }


        [HttpGet("podcast")]
        public IActionResult GetPodcast()
        {
            var pcs = _wemusicDbContext.Songs
                .Where(song => song.Type == "podcast")
                 .Join(_wemusicDbContext.Albums, song => song.album.Id, album => album.Id, (song, album) => new {
                     id = song.Id,
                     name = song.Name,
                     stream = song.Stream,
                     type = song.Type,
                     image = album.Image,
                     src = song.Src,
                     artist = _wemusicDbContext.Albums
                        .Where(ab => ab.Id == album.Id)
                        .SelectMany(album => album.Artists)
                        .ToList()
                 }).OrderBy(song => song.stream)
                .Take(40)
                .ToList();
            if (pcs==null)
            {
                return NotFound("No podcast has found!");
            }
            return Ok(pcs);
        
        }

        [HttpGet("more")] 
        public ActionResult GetMoreSongs() {
            var songs = _wemusicDbContext.Songs.Take(30).ToList();
            if(songs == null)
            {
                return NotFound("songs not found");
            }
            return Ok(songs);
        }

        [HttpGet("byartist/{id}")]
        public IActionResult GetSongsByArtist(string id)
        {
            var songs = _wemusicDbContext.Artists.Where(artist => artist.Id == id)
                .SelectMany(artist => artist.Albums)
                .Join(_wemusicDbContext.Songs, album => album.Id, song => song.album.Id, (album, song) => new
                {
                    id = song.Id,
                    name = song.Name,
                    src = song.Src,
                    stream = song.Stream,
                    type = song.Type,
                    image = album.Image,
                    artist = _wemusicDbContext.Artists.Where(artist => artist.Id == id)
                        .ToList()
                })
                .ToList();


            

            if (songs == null)
            {
                return BadRequest("Artist is not exist");
            }
            return Ok(songs);
        }




    }
}


