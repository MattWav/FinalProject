using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommers.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public int ProductCategoriesID { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; } 
        public string? imageValue { get; set; }
        public int? Field3 { get; set; }
        public int? Field4 { get; set; }

  

        //------------------------------------Relazioni tra tabelle------------------------------------

        public ProductCategories ProductCategories { get; set; } //Relazione con la tabella ProductCategories
        public List<OrderDetails> OrderDetails { get; set; } //Relazione con la tabella Orders


    }
}
