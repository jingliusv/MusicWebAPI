using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClassLibrary.Entities
{
    public class ArtistEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();
        [NotMapped]
        public int NumOfAlbums { get { return Albums.Count; } }
    }
}
