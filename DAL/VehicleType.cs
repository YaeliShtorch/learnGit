using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public string VType { get; set; }
        public virtual ICollection<Vehicle> DriverWork { get; set; }

    }
}
