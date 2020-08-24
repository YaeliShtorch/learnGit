using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class PumpType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string PType { get; set; }
        //public virtual ICollection<Vehicle> DriverWork { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }

    }
}
