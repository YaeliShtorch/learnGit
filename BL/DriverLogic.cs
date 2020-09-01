﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class DriverLogic : BaseLogic
    {
        public DriverDto GetDriverId(int id)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.Id == id)));

        }

        public DriverDto GetDriverUP(string UserName, string Password)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.UserName == UserName && m.Password == Password)));

        }
        public DriverDto GetDriverUN(string UserName)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.UserName == UserName)));

        }

        public List<DriverDto> GetAllDrivers()
        {
            List<Driver> AllDrivers = new List<Driver>();
            AllDrivers = db.Drivers.ToList();
            return DriverListToDto(AllDrivers);
        }
        public DriverDto GetDriverIN(string identityNumber)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.IdentityNumber == identityNumber)));

        }

        public List<DriverDto> GetDriversFLN(string Name)
        {
            List<DriverDto> AllDrivers = new List<DriverDto>();
            foreach (var m in db.Drivers)
            {
                if (m.FirstName.Contains(Name) || m.LastName.Contains(Name))
                    AllDrivers.Add(DriverToDto(m));
            }
            return AllDrivers;
        }

        public DriverDto GetDriverE(string Email)
        {
            // ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.Email == Email)));

        }

        public DriverDto GetDriverP(string phone)
        {
            //    ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.PhoneNumber == phone || m.CellNumber == phone)));

        }

        public List<DriverDto> GetDriverA(string Address)
        {
            List<DriverDto> AllDrivers = new List<DriverDto>();
            foreach (var m in db.Drivers)
            {
                if (m.Address.Contains(Address))
                    AllDrivers.Add(DriverToDto(m));
            }
            return AllDrivers;


        }
        public DriverDto GetDriverBD(DateTime BirthDate)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (DriverToDto(db.Drivers.FirstOrDefault(m => m.BirthDate == BirthDate)));

        }
        public void AddDriver(DriverDto NewDriver)
        {
            //   ShachlavDB db = new ShachlavDB();
            if (IsExist(NewDriver) == false)
            {
                db.Drivers.Add(DriverToDal(NewDriver));
                db.SaveChanges();
            }
        }


        public void DeleteDriver(int id)
        {
            //   ShachlavDB db = new ShachlavDB();
            db.Drivers.Remove(db.Drivers.FirstOrDefault(m => m.Id == id));
            db.SaveChanges();
        }

        public void UpdateDriver(DriverDto UpDriver)
        {
            //  ShachlavDB db = new ShachlavDB();
            Driver Ezer = db.Drivers.FirstOrDefault(m => m.Id == UpDriver.Id);
            Ezer.IdentityNumber = UpDriver.IdentityNumber;
            Ezer.FirstName = UpDriver.FirstName;
            Ezer.LastName = UpDriver.LastName;
            Ezer.Address = UpDriver.Address;
            Ezer.PhoneNumber = UpDriver.PhoneNumber;
            Ezer.CellNumber = UpDriver.CellNumber;
            Ezer.Email = UpDriver.Email;
            Ezer.BirthDate = UpDriver.BirthDate;
            Ezer.UserName = UpDriver.UserName;
            Ezer.Password = UpDriver.Password;
            db.SaveChanges();
        }

        private bool IsExist(DriverDto Driver)
        {
            //  ShachlavDB db = new ShachlavDB();
            foreach (var m in db.Drivers)
            {
                if (m.Id == Driver.Id || m.IdentityNumber ==Driver.IdentityNumber)
                    return true;
            }
            return false;
        }


        private Driver DriverToDal(DriverDto Mdto)
        {
            if (Mdto != null)
                return new Driver()
                {

                    //Id = Mdto.Id,
                    IdentityNumber = Mdto.IdentityNumber,
                    FirstName = Mdto.FirstName,
                    LastName = Mdto.LastName,
                    Address = Mdto.Address,
                    PhoneNumber = Mdto.PhoneNumber,
                    CellNumber = Mdto.CellNumber,
                    Email = Mdto.Email,
                    BirthDate = Mdto.BirthDate,
                    UserName = Mdto.UserName,
                    Password = Mdto.Password
                };
            else
                return null;
        }
        private DriverDto DriverToDto(Driver Mdal)
        {
            if (Mdal != null)
                return new DriverDto()
                {
                    Id = Mdal.Id,
                    IdentityNumber = Mdal.IdentityNumber,
                    FirstName = Mdal.FirstName,
                    LastName = Mdal.LastName,
                    Address = Mdal.Address,
                    PhoneNumber = Mdal.PhoneNumber,
                    CellNumber = Mdal.CellNumber,
                    Email = Mdal.Email,
                    BirthDate = Mdal.BirthDate,
                    UserName = Mdal.UserName,
                    Password = Mdal.Password,
                    IsActive=Mdal.IsActive,
                    EntryToWorkDate=Mdal.EntryToWorkDate
                };
            else return null;
        }
        private List<DriverDto> DriverListToDto(List<Driver> Mdal)
        {
            List<DriverDto> DriverDtoList = new List<DriverDto>();
            if (Mdal != null)
            {
                foreach (var m in Mdal)
                    DriverDtoList.Add(DriverToDto(m));
            }
            return DriverDtoList;
        }
        //private bool IsExist(int id)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Driver)
        //    {
        //        if (m.Id == id)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string UserName, string Password)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Driver)
        //    {
        //        if (m.UserName == UserName && m.Password == Password)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string identityNumber)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Driver)
        //    {
        //        if (m.IdentityNumber == identityNumber)
        //            return true;
        //    }
        //    return false;
        //} 
        //public List<DriverDto> SerachDriver(SearchDto s)
        //{
        //    List<Driver> Drivers = db.Driver.ToList();
        //    if (s.Name != null && s.Name != "")
        //        Drivers = Drivers.Where(t => t.FirstName.Contains(s.Name)).ToList();
        //    if (s.FromDate != null && s.FromDate != default(DateTime))
        //        Drivers = Drivers.Where(t => t.BirthDate >= s.FromDate).ToList();
        //    if (s.ToDate != null && s.ToDate != default(DateTime))
        //        Drivers = Drivers.Where(t => t.BirthDate <= s.ToDate).ToList();
        //    return DriverListToDto(Drivers);

        //}
        public void O()
        {
            Console.WriteLine("ll");
        }

       
        private bool IsExist(DriverWorkDto DriverWork)
        {
            //  ShachlavDB db = new ShachlavDB();
            foreach (var m in db.DriverWork)
            {
                if (m.Id == DriverWork.Id)
                    return true;
            }
            return false;
        }
        private DriverWork DriverWorkToDal(DriverWorkDto Mdto)
        {
            if (Mdto != null)
                return new DriverWork()
                {
                    DriverId = Mdto.DriverId,
                    StartTime = Mdto.StartTime,
                    EndTime = Mdto.EndTime,
                    Date = Mdto.Date,
                    Amount = Mdto.Amount,
                    OrderId = Mdto.OrderId,
                    VehicleId = Mdto.VehicleId

                };
            else
                return null;
        }
        private DriverWorkDto DriverWorkToDto(DriverWork Mdal)
        {
            if (Mdal != null)
                return new DriverWorkDto()
                {

                    DriverId = Mdal.DriverId,
                    StartTime = Mdal.StartTime,
                    EndTime = Mdal.EndTime,
                    Date = Mdal.Date,
                    Amount = Mdal.Amount,
                    OrderId = Mdal.OrderId,
                    VehicleId = Mdal.VehicleId
                };
            else return null;
        }

        public List<DriverWorkDto> GetAllDriverWork()
        {
            List<DriverWorkDto> AllDriverWork = new List<DriverWorkDto>();
            foreach (var m in db.DriverWork)
            {
                AllDriverWork.Add(DriverWorkToDto(m));
            }
            return AllDriverWork;
        }
        public void AddDriverWork(DriverWorkDto NewDriverWork)
        {
            //   ShachlavDB db = new ShachlavDB();
            if (IsExist(NewDriverWork) == false)
            {
                db.DriverWork.Add(DriverWorkToDal(NewDriverWork));
                db.SaveChanges();
            }
        }


    }
}
