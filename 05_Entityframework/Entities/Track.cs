using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Entityframework.Entities
{
    internal class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }

    }
}
