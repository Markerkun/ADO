using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesShop.Entities;

namespace DataAccesShop.Entities
{
    public class ReservedBooks
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservedAt { get; set; }

    }
}
