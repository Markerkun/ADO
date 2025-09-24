using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Entityframework.Entities
{
    internal class Album
    {
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public Artist Artist { get; set; }
        public int ArtistId  { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
