using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace _05_Entityframework.Entities
{
    class Artist
    {
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Name { get; set; }
        
        [Required, MaxLength(15)]
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
