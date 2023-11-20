using System.ComponentModel.DataAnnotations;

namespace wemusic.Controllers
{
    public class User
    {
        //public string Id { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Image {  get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
