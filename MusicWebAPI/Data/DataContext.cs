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
            // SongEntity har två FK nyklar
            modelBuilder.Entity<SongEntity>()
              .HasOne(x => x.Artist)
              .WithMany(x => x.Songs)
              .HasForeignKey(x => x.ArtistId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongEntity>()
                .HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

           
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
                    Name = "Diana Krall"
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
                    Name = "When I Look in Your Eyes",
                    ArtistId = 4
                },
                new AlbumEntity
                {
                    Id = 8,
                    Name = "Body Talk",
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
                    AlbumId = 1,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 2,
                    Name = "Lost",
                    Length = "2:52",
                    AlbumId = 1,
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
                },
                new SongEntity
                {
                    Id = 6,
                    Name = "Let's Face the Music and Dance",
                    Length = "5:18",
                    AlbumId = 7,
                    ArtistId = 4
                },
                new SongEntity
                {
                    Id = 7,
                    Name = "I've Got You Under My Skin",
                    Length = "6:10",
                    AlbumId = 7,
                    ArtistId = 4
                },
                new SongEntity
                {
                    Id = 8,
                    Name = "Because It's In The Music",
                    Length = "4:34",
                    AlbumId = 3,
                    ArtistId = 2
                },
                new SongEntity
                {
                    Id = 9,
                    Name = "Dancing on My Own",
                    Length = "4:48",
                    AlbumId = 8,
                    ArtistId = 2
                },
                new SongEntity
                {
                    Id = 10,
                    Name = "Missing U",
                    Length = "4:57",
                    AlbumId = 3,
                    ArtistId = 2
                },
                new SongEntity
                {
                    Id = 11,
                    Name = "Best 4 U",
                    Length = "3:59",
                    AlbumId = 2,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 12,
                    Name = "What Lovers Do",
                    Length = "3:19",
                    AlbumId = 2,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 13,
                    Name = "Let's Groove",
                    Length = "5:39",
                    AlbumId = 9,
                    ArtistId = 5
                },
                new SongEntity
                {
                    Id = 14,
                    Name = "September",
                    Length = "3:35",
                    AlbumId = 9,
                    ArtistId = 5
                },
                new SongEntity
                {
                    Id = 15,
                    Name = "Maps",
                    Length = "3:09",
                    AlbumId = 5,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 16,
                    Name = "Sugar",
                    Length = "3:55",
                    AlbumId = 5,
                    ArtistId = 1
                },
                new SongEntity
                {
                    Id = 17,
                    Name = "Lost Stars",
                    Length = "4:27",
                    AlbumId = 5,
                    ArtistId = 1
                }
            );
            #endregion
        }



    }
}
