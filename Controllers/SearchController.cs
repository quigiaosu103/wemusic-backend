using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController: ControllerBase
    {
        private WeMusicDbContext _wemusicDbContext;

        public SearchController(WeMusicDbContext wemusicDbContext)
        {
            _wemusicDbContext = wemusicDbContext;
        }

        [HttpGet("{keyword}")]
        public IActionResult GetSearchResult(string keyword)
        {
            var songs = _wemusicDbContext.Songs.Where(song => song.Name.Contains(keyword)).Take(10)
                .Join(_wemusicDbContext.Albums, song => song.album.Id, album=> album.Id, (song, album)=> new
                {
                    song, album
                }).Select(combined => new
                {
                    id = combined.song.Id,
                    name = combined.song.Name,
                    stream = combined.song.Stream,
                    type = combined.song.Type,
                    src = combined.song.Src,
                    image = combined.album.Image,
                    artist = _wemusicDbContext.Albums
                        .Where(ab => ab.Id == combined.song.album.Id)
                        .SelectMany(album => album.Artists)
                        .ToList()
                })
                .Take(5).ToList();
            var artists = _wemusicDbContext.Artists.Where(artist => artist.Name.Contains(keyword)).Take(10).Select(artist => new
            {//
                id= artist.Id,
                name = artist.Name,
                image = artist.Image

            }).Take(5).ToList();
            var albums = _wemusicDbContext.Albums.Where(album => album.Name.Contains(keyword)).Take(10).Select(album => new
            {
                id= album.Id,
                name= album.Name,
                image= album.Image
            }).Take(5).ToList();
            return Ok(new {songs, artists, albums});
        }
    }
}
