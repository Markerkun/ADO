using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CRUD_Interface
{
    internal class Sale
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string EmployeeId { get; set; }

        public int ClientId { get; set; }

        public int SaleDate { get; set; }

        public override string ToString()
        {
            return $"{ProductId,3}  {Price,15} {Quantity,7} {EmployeeId,3} {ClientId,3} {SaleDate,12}";
        }
    }
}
