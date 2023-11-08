using wemusic.Controllers;

namespace wemusic.Controllers
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Followers { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}

