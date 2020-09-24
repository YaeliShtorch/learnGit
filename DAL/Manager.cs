using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Manager
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        //[CustomValidation(typeof(Validations), "IdOK")]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string CellNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [CustomValidation(typeof(Validations), "BirthDateValid")]
        public DateTime BirthDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
