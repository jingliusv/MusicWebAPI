using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClassLibrary.Dto
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        public string AlbumName { get; set; } = string.Empty;
    }
}
