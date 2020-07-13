using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   
 public  class Vehicle
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int PipesLengh { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
      
        public int DriverId { get; set; }
        [Required]
        public Driver Driver { get; set; }
        public int MixerNumber { get; set; }
        public virtual ICollection<DriverWork> DriverWork { get; set; }
    }
}
