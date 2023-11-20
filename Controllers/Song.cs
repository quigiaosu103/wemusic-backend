namespace wemusic.Controllers
{
    public class Song
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Stream {  get; set; }
        public string Src { get; set; }
        public string Type {  get; set; }
        public Album album { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

    }

}
