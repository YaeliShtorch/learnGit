using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PipeLength { get; set; }
        public string LicenseNumber { get; set; }
        public int DriverId { get; set; }
        public int MixerNumber { get; set; }
        public int MaterialId { get; set; }

    }
}
