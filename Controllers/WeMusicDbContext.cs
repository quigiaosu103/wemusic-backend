using Microsoft.EntityFrameworkCore;

namespace wemusic.Controllers
{
    public class WeMusicDbContext: DbContext
    {

        public WeMusicDbContext(DbContextOptions options) : base(options)
        {
        }


            
            public DbSet<Album> Albums { get; set; }
            public DbSet<Artist> Artists { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Playlist> Playlists { get; set; }
            public DbSet<Song> Songs { get; set; }
            public DbSet<User> Users { get; set; }

    }
   

}
