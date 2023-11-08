namespace wemusic.Controllers
{
    public class Song
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Stream {  get; set; }
        public string albumType {  get; set; }
        public string Src { get; set; }
        public string img { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<Album> Albums { get; set; }

    }

}
