using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
   public class Driver
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string CellNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime EntryToWorkDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsActive { get; set; }
        
        //public Vehicle Vehicle { get; set; }
        public virtual ICollection<DriverWork> DriverWork { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }


    }
}
