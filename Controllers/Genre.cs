namespace wemusic.Controllers
{
    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }

    }
}
