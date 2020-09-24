using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class Customer
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
        public string CompanyName { get; set; }
        [Required]
        public string BusinessCode { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [Phone]
        public string CellNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [CustomValidation(typeof(Validations), "BirthDateValid")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Order> CustOrders { get; set; }
    }
}

