using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWork.Entities
{
    internal class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<Author>? FollowedAuthors { get; set; }
    }
}
