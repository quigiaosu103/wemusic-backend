namespace wemusic.Controllers
{
    public class Playlist
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string UserId { get; set; }
        public string  AlbumType { get; set; }
        public int  TotalSong { get; set; }
        public ICollection<Song> Songs { get; set;}
        
    }
}
