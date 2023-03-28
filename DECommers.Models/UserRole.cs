using DECommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommers.Models
{
    public class UserRole
    { [Key]
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        //------------------------------------Relazioni tra tabelle------------------------------------
        public  Users Users { get; set; }  //Relazione con la tabella Users
        public Roles Roles { get; set; }
    }
}
