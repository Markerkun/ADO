using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"{FullName,50} {HireDate,15} {Gender,7} {Salary,10}";
        }
    }
}
