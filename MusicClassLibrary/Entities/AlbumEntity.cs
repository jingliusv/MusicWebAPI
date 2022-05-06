using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicClassLibrary.Entities
{
    public class AlbumEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int ArtistId { get; set; }
        public ArtistEntity Artist { get; set; } = null!;      
        public ICollection<SongEntity> Songs { get; set; } = new List<SongEntity>();
        [NotMapped]
        public int NumOfSongs { get { return Songs.Count; } }
    }
}
