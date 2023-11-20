using System.ComponentModel.DataAnnotations;
using wemusic.Controllers;

namespace wemusic.Controllers
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public string Image { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}

