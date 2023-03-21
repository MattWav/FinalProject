using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommers.Models
{
    public class Orders
    { [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public string? Field3 { get; set; }
        public string? Field4 { get; set; }
        public string? Field5 { get; set; }
        public string? Field6 { get; set; }
        public int? Field7 { get; set; }
        public int? Field8 { get; set; }

        //------------------------------------Relazioni tra tabelle------------------------------------
        public List<OrderDetails> OrderDetails { get; set; } //Relazione con la tabella OrderDetails
        public Users Users { get; set; } //Relazione con la tabella Users
       
    }
}
