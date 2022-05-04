namespace MusicWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ArtistEntity> Artists { get; set; } = null!;
        public DbSet<AlbumEntity> Albums { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Artist Data
            modelBuilder.Entity<ArtistEntity>().HasData(
                new ArtistEntity
                {
                    Id = 1,
                    Name = "Maroon 5",
                },
                new ArtistEntity
                {
                    Id = 2,
                    Name = "Robyn"
                },
                new ArtistEntity
                {
                    Id = 3,
                    Name = "Justin Timberlake"
                },
                new ArtistEntity 
                { 
                    Id = 4, 
                    Name = "SIRUP"
                },
                new ArtistEntity
                {
                    Id = 5,
                    Name = "Earth, Wind & Fire"
                }
            );

            #endregion

            #region Album Data
            modelBuilder.Entity<AlbumEntity>().HasData(
                new AlbumEntity
                {
                    Id = 1,
                    Name = "JORDI",
                    ArtistId = 1,
                },
                new AlbumEntity
                {
                    Id = 2,
                    Name = "Red Pill Blues",
                    ArtistId = 1,
                },
                new AlbumEntity
                {
                    Id = 3,
                    Name = "Honey",
                    ArtistId = 2
                },
                new AlbumEntity
                {
                    Id = 4,
                    Name = "Do It Again",
                    ArtistId = 2
                },
                new AlbumEntity
                {
                    Id = 5,
                    Name = "V",
                    ArtistId = 1
                },
                new AlbumEntity
                {
                    Id = 6,
                    Name = "The 20/20 Experience",
                    ArtistId = 3
                },
                new AlbumEntity
                {
                    Id = 7,
                    Name = "cure",
                    ArtistId = 4
                },
                new AlbumEntity
                {
                    Id = 8,
                    Name = "Dancing on My Own",
                    ArtistId = 2
                },
                new AlbumEntity
                {
                    Id = 9,
                    Name = "Raise!",
                    ArtistId = 5
                }
            );
            #endregion

            #region Song Data

            #endregion
        }



    }
}
