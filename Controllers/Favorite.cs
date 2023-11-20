namespace wemusic.Controllers
{
    public class Favorite
    {
        public int Id { get; set; }
        public bool IsFavorite { get; set; }
        public User User { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
