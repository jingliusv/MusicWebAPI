using System.ComponentModel.DataAnnotations;

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
    }
}
