﻿using MusicClassLibrary.Entities;
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
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public int NumOfAlbums { get; set; }
    }
}
