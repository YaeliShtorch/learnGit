using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Provider
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyCode { get; set; }
        public string Address { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [Phone]
        public string CellNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Comment { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

