using System;
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
            List<Driver> ActiveDrivers = new List<Driver>();
            foreach(Driver d in db.Drivers.ToList())
            {
                if (d.IsActive == true)
                    ActiveDrivers.Add(d);
            }
            return DriverListToDto(ActiveDrivers);
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
            Driver d= db.Drivers.Find(db.Drivers.FirstOrDefault(m => m.Id == id));
            //   ShachlavDB db = new ShachlavDB();
            if (d != null) d.IsActive = false;
            db.SaveChanges();
        }

        public void UpdateDriver(DriverDto UpDriver)
        {
            //  ShachlavDB db = new ShachlavDB();
            Driver Ezer = db.Drivers.FirstOrDefault(m => m.Id == UpDriver.Id);
            if (Ezer != null) { 
            Ezer.IdentityNumber = UpDriver.IdentityNumber;
            Ezer.FirstName = UpDriver.FirstName;
            Ezer.LastName = UpDriver.LastName;
            Ezer.Email = UpDriver.Email;
            Ezer.PhoneNumber = UpDriver.PhoneNumber;
            Ezer.CellNumber = UpDriver.CellNumber;
            Ezer.Address = UpDriver.Address;
            Ezer.BirthDate = UpDriver.BirthDate;
            Ezer.EntryToWorkDate = UpDriver.EntryToWorkDate;
            Ezer.UserName = UpDriver.UserName;
            Ezer.Password = UpDriver.Password;
            Ezer.IsActive = UpDriver.IsActive;
            db.SaveChanges();
            } 
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
                    Email = Mdto.Email,
                    PhoneNumber = Mdto.PhoneNumber,
                    CellNumber = Mdto.CellNumber,
                    Address = Mdto.Address,
                    BirthDate = Mdto.BirthDate,
                    EntryToWorkDate=Mdto.EntryToWorkDate,
                    UserName = Mdto.UserName,
                    Password = Mdto.Password,
                    IsActive=Mdto.IsActive
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
                    Email = Mdal.Email,
                    PhoneNumber = Mdal.PhoneNumber,
                    CellNumber = Mdal.CellNumber,
                    Address = Mdal.Address,
                    BirthDate = Mdal.BirthDate,
                    EntryToWorkDate = Mdal.EntryToWorkDate,
                    UserName = Mdal.UserName,
                    Password = Mdal.Password,
                    IsActive = Mdal.IsActive
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
            foreach (var m in db.DriverWorks)
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
            foreach (var m in db.DriverWorks)
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
                db.DriverWorks.Add(DriverWorkToDal(NewDriverWork));
                db.SaveChanges();
            }
        }


    }
}
