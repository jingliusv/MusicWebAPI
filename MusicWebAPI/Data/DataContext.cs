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
        public DbSet<SongEntity> Songs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SongEntity har två FK Key
            modelBuilder.Entity<SongEntity>()
              .HasOne(x => x.Artist)
              .WithMany(x => x.Songs)
              .HasForeignKey(x => x.ArtistId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongEntity>()
                .HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

           
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
            modelBuilder.Entity<SongEntity>().HasData(
                new SongEntity
                {
                    Id = 1,
                    Name = "Memories",
                    Length = "3:09",
                    AlbumId = 4,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 2,
                    Name = "Lost",
                    Length = "2:52",
                    AlbumId = 4,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 3,
                    Name = "Suit & Tie",
                    Length = "5:26",
                    AlbumId = 6,
                    ArtistId = 3
                },
                new SongEntity
                {
                    Id = 4,
                    Name = "Between the Lines",
                    Length = "4:05",
                    AlbumId = 3,
                    ArtistId = 2
                },
                new SongEntity
                {
                    Id = 5,
                    Name = "Boogie Wonderland",
                    Length = "4:48",
                    AlbumId = 1,
                    ArtistId = 5
                }
            );
            #endregion
        }



    }
}
