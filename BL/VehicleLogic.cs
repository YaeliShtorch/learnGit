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

        // get all vehicles with full FK objects
        public List<VehicleForRequestDto> GetAllVehicles()
        {
            List<Vehicle> VehicleDalL = new List<Vehicle>();
            VehicleDalL = db.Vehicle.ToList();
            List<VehicleForRequestDto> VehicleReqL = new List<VehicleForRequestDto>();

            if (VehicleDalL != null) { 
             foreach (Vehicle v in VehicleDalL)
            {
               
                VehicleReqL.Add(VehicletoVReqDto(v));
            }
            }
            return VehicleReqL;
        }
         
        public VehicleForRequestDto VehicletoVReqDto(Vehicle vDal)
        {
            if (vDal != null)
            {
                return new VehicleForRequestDto()
                {
                    Id = vDal.Id,
                    Description = vDal.Description,
                    PipeLength = vDal.PipeLength,
                    LicenseNumber = vDal.LicenseNumber,
                    Driver = db.Drivers.FirstOrDefault(d => d.Id == vDal.DriverId),
                    MixerNumber = vDal.MixerNumber,
                    VehicleType = db.VehicleType.FirstOrDefault(p => p.Id == vDal.VehicleTypeId),

                };

                }
            else return null;
        }

        public Vehicle VehicleReqDtotoDal(VehicleForRequestDto vReqDto)
        {
            if (vReqDto != null)
            {
                return new Vehicle()
                {
                    Id = vReqDto.Id,
                    Description = vReqDto.Description,
                    PipeLength = vReqDto.PipeLength,
                    LicenseNumber = vReqDto.LicenseNumber,
                    DriverId = vReqDto.Driver.Id,
                    MixerNumber = vReqDto.MixerNumber,
                    VehicleTypeId = vReqDto.VehicleType.Id,
                    
                };

            }
            else return null;
        }

        public Vehicle VehicletoDal(VehicleDto VDto)
        {
            if (VDto != null)
            {
                return new Vehicle()
                {
                    Id = VDto.Id,
                    Description = VDto.Description,
                    PipeLength = VDto.PipeLength,
                    LicenseNumber = VDto.LicenseNumber,
                    DriverId = VDto.DriverId,
                    MixerNumber = VDto.MixerNumber,
                    VehicleTypeId = VDto.VehicleTypeId,
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
                    PipeLength = VDal.PipeLength,
                    LicenseNumber = VDal.LicenseNumber,
                    DriverId = VDal.DriverId,
                    MixerNumber = VDal.MixerNumber,
                    VehicleTypeId = VDal.VehicleTypeId,


                };
            }
            else return null;
        }

        //public List<PumpTypeDto> GetAllPumpTypes()
        //{
        //    List<PumpTypeDto> pumpTypesDtoList = new List<PumpTypeDto>();
        //    List<PumpType> pupmTypeDalList = new List<PumpType>();
        //    pupmTypeDalList = db.PumpType.ToList();
        //    foreach (PumpType vT in pupmTypeDalList)
        //    {
        //        pumpTypesDtoList.Add(PumpTypeToDto(vT));
        //    }
        //    return pumpTypesDtoList;
        //}



        //public void addPumpType(PumpTypeDto p)
        //{
        //    //check there is no such instance;
        //    PumpType ezer = db.PumpType.FirstOrDefault(x => x.PType == p.PType);
        //    if (ezer == null)
        //    {
        //        db.PumpType.Add(PumpTypetoDal(p));
        //        db.SaveChanges();
        //    }

        //}

        ////delete vehicle type
        //public void deletePumpType(int id)
        //{
        //    db.PumpType.Remove(db.PumpType.FirstOrDefault(o => o.Id == id));
        //    db.SaveChanges();

        //}

        //public PumpTypeDto PumpTypeToDto(PumpType Ptdal)
        //{
        //    if (Ptdal != null)
        //        return new PumpTypeDto()
        //        {
        //            Id = Ptdal.Id,
        //            PType = Ptdal.PType
        //        };
        //    else return null;
        //}

        //public PumpType PumpTypetoDal(PumpTypeDto PtDto)
        //{
        //    if (PtDto != null)
        //        return new PumpType()
        //        {
        //            //Id = v.Id,
        //            PType = PtDto.PType
        //        };
        //    else return null;

        //}



    }
}

