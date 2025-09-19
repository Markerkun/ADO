using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PercentSale { get; set; }
        public string Gender { get; set; }
        public byte Subscribe { get; set; }
        public override string ToString()
        {
            return $"{FullName,50} {Email,20} {Phone,15} {PercentSale,5} {Gender,7} {Subscribe,10}";
        }
    }
}
