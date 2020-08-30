using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VehicleForRequestDto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int PipesLength { get; set; }
        public string LicenseNumber { get; set; }
        public Driver Driver { get; set; }
        public int MixerNumber { get; set; }
        public PumpType PumpType { get; set; }
    }
}
