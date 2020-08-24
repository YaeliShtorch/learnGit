using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class VehicleLogic : BaseLogic
    {

        public List<VehicleDto> GetAllVehicles()
        {
            List<Vehicle> VehicleDalL = new List<Vehicle>();
            VehicleDalL = db.Vehicle.ToList();
            List<VehicleDto> VehicleDtoL = new List<VehicleDto>();
            if (VehicleDalL != null)
            {
                foreach (Vehicle v in VehicleDalL)
                {
                    VehicleDtoL.Add(VehicleToDto(v));
                }
            }
            return VehicleDtoL;
        }

        public Vehicle VehicletoDal(VehicleDto VDto)
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
            }
            else return null;
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
                    MixerNumber = VDal.MixerNumber,
                    PumpTypeId = VDal.PumpTypeId,


                };
            }
            else return null;
        }

        public List<PumpTypeDto> GetAllPumpTypes()
        {
            List<PumpTypeDto> pumpTypesDtoList = new List<PumpTypeDto>();
            List<PumpType> pupmTypeDalList = new List<PumpType>();
            pupmTypeDalList = db.PumpType.ToList();
            foreach (PumpType vT in pupmTypeDalList)
            {
                pumpTypesDtoList.Add(PumpTypeToDto(vT));
            }
            return pumpTypesDtoList;
        }



        public void addPumpType(PumpTypeDto p)
        {
            //check there is no such instance;
            PumpType ezer = db.PumpType.FirstOrDefault(x => x.PType == p.PType);
            if (ezer == null)
            {
                db.PumpType.Add(PumpTypetoDal(p));
                db.SaveChanges();
            }

        }

        //delete vehicle type
        public void deletePumpType(int id)
        {
            db.PumpType.Remove(db.PumpType.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();

        }

        public PumpTypeDto PumpTypeToDto(PumpType Ptdal)
        {
            if (Ptdal != null)
                return new PumpTypeDto()
                {
                    Id = Ptdal.Id,
                    PType = Ptdal.PType
                };
            else return null;
        }

        public PumpType PumpTypetoDal(PumpTypeDto PtDto)
        {
            if (PtDto != null)
                return new PumpType()
                {
                    //Id = v.Id,
                    PType = PtDto.PType
                };
            else return null;

        }



    }
}

