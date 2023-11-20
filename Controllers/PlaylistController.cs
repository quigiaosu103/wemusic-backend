using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController:ControllerBase
    {
        private WeMusicDbContext _wemusicDbContext;

        public PlaylistController(WeMusicDbContext wemusicDbContext)
        {
            _wemusicDbContext = wemusicDbContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserPlaylist(string id)
        {
            var playlists = _wemusicDbContext.Playlists.Where(playlist => playlist.user.UserName == id).ToList();
            return Ok(playlists);
        }


        [HttpGet("songof/{id}")]
        public IActionResult GetPlaylistSongs(string id) {
            var playlist = _wemusicDbContext.Playlists.Find(id);
            if(playlist == null)
            {
                return NotFound("playlist not found");
            }
            var playlistWithSongs = _wemusicDbContext.Playlists
                .Where(pl => pl.Id == id)
                .SelectMany(playlist => playlist.Songs
                .Join(_wemusicDbContext.Albums, song => song.album.Id, ab => ab.Id, (song, ab) => new
                {
                    id = song.Id,
                    name = song.Name,
                    stream = song.Stream,
                    type = song.Type,
                    image = ab.Image,
                    src = song.Src,
                    artist = _wemusicDbContext.Albums
                        .Where(album => album.Id == ab.Id)
                        .SelectMany(album => album.Artists)
                        .ToList()
                })).ToList();
                
            if (playlistWithSongs == null)
            {
                return NotFound("songs not found");
            }
                return Ok(playlistWithSongs);
        }

        [HttpPost("{id}")]
        public IActionResult AddNewPlaylist(string id, Playlist playlist) {
            var user = _wemusicDbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound("User is not exist");
            }
            var pl = _wemusicDbContext.Playlists.Find(playlist.Id);
            
            if(pl != null)
            {
                return NotFound("id is existed");
            }

            playlist.user = user;
            _wemusicDbContext.Add(playlist);
            _wemusicDbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("/addsong{id}")]
        public IActionResult AddSongToPlaylist(string id, string songId)
        {
            var playlist = _wemusicDbContext.Playlists
            .Include(p => p.Songs)
            .FirstOrDefault(p => p.Id == id);

            if (playlist == null)
            {
                return NotFound("Playlist not found");
            }

            var song = _wemusicDbContext.Songs.Find(songId);

            if (song == null)
            {
                return NotFound("Song not found");
            }

            playlist.Songs.Add(song);
            playlist.TotalSong += 1;
            _wemusicDbContext.SaveChanges();
            return Ok();
        }


    }
}
