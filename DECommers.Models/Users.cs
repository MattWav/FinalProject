using System.ComponentModel.DataAnnotations;

namespace DECommers.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public DateTime? Field3 { get; set; }
        public int? Field4 { get; set; }
        public int? Field5 { get; set; }
        public int? Field6 { get; set; }
          
        //------------------------------------Relazioni tra tabelle------------------------------------
        public List<UserRole> UserRole { get; set; }    //Relazione con la tabella UserRole   
        public List <Orders> Orders { get; set; }       //Relazione con la tabella Orders 
    }
}