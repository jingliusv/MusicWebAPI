using MusicClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClassLibrary.Dto
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();
        public int NumOfAlbums { get { return Albums.Count; } }
    }
}
