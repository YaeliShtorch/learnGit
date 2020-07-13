using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class ManagerLogic : BaseLogic
    {
        //Gets

        public ManagerDto GetManagerId(int id)
        {
          //  ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.Id == id)));

        }
      
        public ManagerDto GetManagerUP(string UserName, string Password)
        {
          //  ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.UserName == UserName && m.Password == Password)));

        }
        public ManagerDto GetManagerUN(string UserName)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.UserName == UserName)));

        }
        
        public List<ManagerDto> GetAllManagers()
        {
            List<ManagerDto> AllManagers = new List<ManagerDto>();
            foreach (var m in db.Manager)
            {
                AllManagers.Add(ManagerToDto(m));
            }
            return AllManagers;
        }
        public ManagerDto GetManagerIN(string identityNumber)
        {
          //  ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.IdentityNumber == identityNumber)));

        }
      
        public List<ManagerDto> GetManagersFLN(string Name)
        {
            List<ManagerDto> AllManagers = new List<ManagerDto>();
            foreach (var m in db.Manager)
            {
                if (m.FirstName.Contains(Name) || m.LastName.Contains(Name))
                    AllManagers.Add(ManagerToDto(m));
            }
            return AllManagers;
        }

        public ManagerDto GetManagerE(string Email)
        {
           // ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.Email == Email)));

        }

        public ManagerDto GetManagerP(string phone)
        {
        //    ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.PhoneNumber == phone || m.CellNumber == phone)));

        }

        public List<ManagerDto> GetManagerA(string Address)
        {
            List<ManagerDto> AllManagers = new List<ManagerDto>();
            foreach (var m in db.Manager)
            {
                if (m.Address.Contains(Address))
                    AllManagers.Add(ManagerToDto(m));
            }
            return AllManagers;


        }
        public ManagerDto GetManagerBD(DateTime BirthDate)
        {
          //  ShachlavDB db = new ShachlavDB();

            return (ManagerToDto(db.Manager.FirstOrDefault(m => m.BirthDate == BirthDate)));

        }
        public void AddManager(ManagerDto NewManager)
        {
         //   ShachlavDB db = new ShachlavDB();
            if (IsExist(NewManager) == false)
            {
                db.Manager.Add(ManagerToDal(NewManager));
                db.SaveChanges();
            }
        }


        public void DeleteManager(int id)
        {
         //   ShachlavDB db = new ShachlavDB();
            db.Manager.Remove(db.Manager.FirstOrDefault(m => m.Id == id));
            db.SaveChanges();
        }

        public void UpdateManager(ManagerDto UpManager)
        {
          //  ShachlavDB db = new ShachlavDB();
            Manager Ezer = db.Manager.FirstOrDefault(m => m.Id == UpManager.Id);
            Ezer.IdentityNumber = UpManager.IdentityNumber;
            Ezer.FirstName = UpManager.FirstName;
            Ezer.LastName = UpManager.LastName;
            Ezer.Address = UpManager.Address;
            Ezer.PhoneNumber = UpManager.PhoneNumber;
            Ezer.CellNumber = UpManager.CellNumber;
            Ezer.Email = UpManager.Email;
            Ezer.BirthDate = UpManager.BirthDate;
            Ezer.UserName = UpManager.UserName;
            Ezer.Password = UpManager.Password;
            db.SaveChanges();
        }
       
        private bool IsExist(ManagerDto manager)
        {
          //  ShachlavDB db = new ShachlavDB();
            foreach (var m in db.Manager)
            {
                if (m.Id == manager.Id)
                    return true;
            }
            return false;
        }


        private Manager ManagerToDal(ManagerDto Mdto)
        {
            if (Mdto != null)
                return new Manager()
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
        private ManagerDto ManagerToDto(Manager Mdal)
        {
            if(Mdal!=null)
            return new ManagerDto()
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
                Password = Mdal.Password
            };
            else return null;
        }
        private List<ManagerDto> ManagerListToDto(List<Manager> Mdal)
        {
            List<ManagerDto> ManagerDtoList = new List<ManagerDto>();
            if (Mdal != null)
            {
                foreach (var m in Mdal)
                    ManagerDtoList.Add(ManagerToDto(m));
            }
            return ManagerDtoList;
        }
        //private bool IsExist(int id)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Manager)
        //    {
        //        if (m.Id == id)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string UserName, string Password)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Manager)
        //    {
        //        if (m.UserName == UserName && m.Password == Password)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string identityNumber)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Manager)
        //    {
        //        if (m.IdentityNumber == identityNumber)
        //            return true;
        //    }
        //    return false;
        //} 
        public List<ManagerDto> SerachManager(SearchDto s)
        {
            List<Manager> managers = db.Manager.ToList();
            if (s.Name != null && s.Name != "")
                managers = managers.Where(t => t.FirstName.Contains(s.Name)).ToList();
            if (s.FromDate != null && s.FromDate != default(DateTime))
                managers = managers.Where(t => t.BirthDate >= s.FromDate).ToList();
            if (s.ToDate != null && s.ToDate != default(DateTime))
                managers = managers.Where(t => t.BirthDate <= s.ToDate).ToList();
            return ManagerListToDto(managers);

        }
    }
}
