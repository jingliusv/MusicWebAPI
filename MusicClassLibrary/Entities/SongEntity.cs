using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClassLibrary.Entities
{
    public class SongEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Length { get; set; } = string.Empty;
        [Required]
        public int AlbumId { get; set; }
        public AlbumEntity Album { get; set; } = null!;
        [Required]
        public int ArtistId { get; set; }
        public ArtistEntity Artist { get; set; } = null!;
    }
}
