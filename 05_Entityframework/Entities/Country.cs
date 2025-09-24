using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Entityframework.Entities
{
    internal class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
