using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DriverWork
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }


        [Required]
        [CustomValidation(typeof(Validations), "BeforeDateValid")]
        public DateTime Date { get; set; }
        [Required]
        public int Amount { get; set; }


    }
}



