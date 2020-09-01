using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DriverWorkDto 
    {
        public int Id { get; set; }
        public int DriverId { get; set; }     
        public int OrderId { get; set; }    
        public int VehicleId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

    }
}

