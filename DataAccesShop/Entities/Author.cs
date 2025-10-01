using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWork.Entities
{
    internal class Author
    {
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Name { get; set; }

        [Required, MaxLength(15)]
        public string Surname { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Client> Followers { get; set; }

    }
}
