namespace wemusic.Controllers
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public string Image {  get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
