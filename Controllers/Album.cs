namespace wemusic.Controllers
{
    public class Album
    {
        public string Id { get; set; }
        public string name {  get; set; } 
        public int totalSongs {get; set;}
        public string releaseDate {  get; set; }    
        public string Image {  get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Artist> Artists { get; set; }


    }
}
