using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWork.Entities
{
    internal class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal PriceForSale { get; set; }
        public Book NextChapter { get; set; }
        public int? NextChapterId { get; set; }




    }
}
