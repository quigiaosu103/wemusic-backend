namespace wemusic.Controllers
{
    public class Genre
    {
        public string Id { get; set; }
        public string genre { get; set; }
        public ICollection<Song> Songs { get; set; }

    }
}
