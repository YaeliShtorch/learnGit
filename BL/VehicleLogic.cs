using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class VehicleLogic: BaseLogic
    {

        public List<VehicleDto> GettAllVehicles()
        {
            List<VehicleDto> VehicleDtoL = new List<VehicleDto>();
            foreach(Vehicle v in db.Vehicle.ToList())
            {
                VehicleDtoL.Add(VehicleToDto(v));
            }
            return VehicleDtoL;
        }

        public Vehicle VehicletoDal (VehicleDto VDto)
        {
            if (VDto != null)
            {
                return new Vehicle()
                {
                    Id = VDto.Id,
                    Description = VDto.Description,
                    PipesLength = VDto.PipesLength,
                    LicenseNumber = VDto.LicenseNumber,
                    DriverId = VDto.DriverId,
                    MixerNumber = VDto.MixerNumber,
                    PumpTypeId = VDto.PumpTypeId,
                };
            } else return null;
        }


        public VehicleDto VehicleToDto(Vehicle VDal)
        {
            if (VDal != null)
            {
                return new VehicleDto()
                {
                    Id = VDal.Id,
                    Description = VDal.Description,
                    PipesLength = VDal.PipesLength,
                    LicenseNumber = VDal.LicenseNumber,
                    DriverId = VDal.DriverId,
                    MixerNumber=VDal.MixerNumber,
                    PumpTypeId=VDal.PumpTypeId,


                };
            }
            else return null;
        }
    }
}
