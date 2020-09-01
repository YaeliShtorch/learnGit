using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Vehicle
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int PipeLength { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public int DriverId { get; set; }

        public Driver Driver { get; set; }
        [Required]
        public int VehicleTypeId { get; set; }
        //[Required]
        public VehicleType VehicleType { get; set; }
        public int MixerNumber { get; set; }
        public virtual ICollection<DriverWork> DriverWork { get; set; }

    }
}

