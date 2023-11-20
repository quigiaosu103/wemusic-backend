namespace wemusic.Controllers
{
    public class Album
    {
        public string Id { get; set; }
        public string Name {  get; set; } 
        public int TotalSongs {get; set;}
        public string ReleaseDate {  get; set; }    
        public string Type { get; set; }
        public string Image {  get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Artist> Artists { get; set; }


    }
}
