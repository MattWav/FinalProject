using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommers.Models
{
    public class OrderDetails
    {    [Key]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Field1 { get; set; }
        public string? Field2 { get; set; }

        //------------------------------------Relazioni tra tabelle------------------------------------

        public Orders Orders { get; set; } //Relazione con la tabella Orders
        public Products Products { get; set; }  //Relazione con la tabella Products
    }
}
