using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommers.Models
{
    public class ProductCategories
    {
        [Key]
        public int ProductCategoriesID { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public string? Field3 { get; set; }

        //------------------------------------Relazioni tra tabelle------------------------------------
        public List<Products> Products { get; set; } //Relazione con la tabella Products
    }
}
