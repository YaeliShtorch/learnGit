using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProviderLogic : BaseLogic
    {
        public ProviderDto GetProviderId(int id)
        {
            return (ProviderToDto(db.Providers.FirstOrDefault(m => m.Id == id)));
        }

        public ProviderDto GetProviderUP(string UserName, string Password)
        {
            return ProviderToDto(db.Providers.FirstOrDefault(m => m.UserName == UserName && m.Password == Password));
        }
        public ProviderDto GetProviderUN(string UserName)
        {


            return (ProviderToDto(db.Providers.FirstOrDefault(m => m.UserName == UserName)));

        }

        public List<ProviderDto> GetAllProviders()
        {
            List<ProviderDto> ActiveProvidersL = new List<ProviderDto>();

            db.Providers.ToList().ForEach(x =>
            {
                if (x.IsActive == true)
                {
                    ActiveProvidersL.Add(ProviderToDto(x));
                }
            });

            return ActiveProvidersL;
        }
        public ProviderDto GetProviderIN(string companyCode)
        {
            return ProviderToDto(db.Providers.FirstOrDefault(m => m.CompanyCode == companyCode));

        }

        public List<ProviderDto> GetProvidersFLN(string Name)
        {
            List<ProviderDto> AllProviders = new List<ProviderDto>();
            foreach (var m in db.Providers)
            {
                if (m.CompanyName.Contains(Name))
                    AllProviders.Add(ProviderToDto(m));
            }
            return AllProviders;
        }

        public ProviderDto GetProviderE(string Email)
        {
            // ShachlavDB db = new ShachlavDB();

            return (ProviderToDto(db.Providers.FirstOrDefault(m => m.Email == Email)));

        }

        public ProviderDto GetProviderP(string phone)
        {
            //    ShachlavDB db = new ShachlavDB();

            return (ProviderToDto(db.Providers.FirstOrDefault(m => m.PhoneNumber == phone || m.CellNumber == phone)));

        }

        public List<ProviderDto> GetProviderA(string Address)
        {
            List<ProviderDto> AllProviders = new List<ProviderDto>();
            foreach (var m in db.Providers)
            {
                if (m.Address.Contains(Address))
                    AllProviders.Add(ProviderToDto(m));
            }
            return AllProviders;


        }

        public void AddProvider(ProviderDto NewProvider)
        {
            if (IsExist(NewProvider) == false)
            {
                db.Providers.Add(ProviderToDal(NewProvider));
                db.SaveChanges();
            }
        }


        public void DeleteProvider(int id)
        {
            Provider p = db.Providers.Find(db.Drivers.FirstOrDefault(m => m.Id == id));
            if (p != null) p.IsActive = false;
            db.SaveChanges();
        }

        public void UpdateProvider(ProviderDto UpProvider)
        {
            Provider Ezer = db.Providers.FirstOrDefault(m => m.Id == UpProvider.Id);
            if (Ezer != null) {
            Ezer.CompanyCode = UpProvider.CompanyCode;
            Ezer.CompanyName = UpProvider.CompanyName;
            Ezer.Address = UpProvider.Address;
            Ezer.PhoneNumber = UpProvider.PhoneNumber;
            Ezer.CellNumber = UpProvider.CellNumber;
            Ezer.Email = UpProvider.Email;
            Ezer.UserName = UpProvider.UserName;
            Ezer.Password = UpProvider.Password;
            db.SaveChanges();
            }
        }

        private bool IsExist(ProviderDto provider)
        {
            Boolean exist = false;
            db.Providers.ToList().ForEach(x =>
            {
                if (x.CompanyCode == provider.CompanyCode && x.CompanyName == provider.CompanyName)
                    exist = true;
            });
            return exist;
        }


        private Provider ProviderToDal(ProviderDto Mdto)
        {
            if (Mdto != null)
                return new Provider()
                {
                    //Id = Mdto.Id,
                    CompanyCode = Mdto.CompanyCode,
                    CompanyName = Mdto.CompanyName,
                    Address = Mdto.Address,
                    PhoneNumber = Mdto.PhoneNumber,
                    CellNumber = Mdto.CellNumber,
                    Email = Mdto.Email,
                    UserName = Mdto.UserName,
                    Password = Mdto.Password
                };
            else
                return null;
        }
        private ProviderDto ProviderToDto(Provider Mdal)
        {
            if (Mdal != null)
                return new ProviderDto()
                {
                    Id = Mdal.Id,
                    CompanyCode = Mdal.CompanyCode,
                    CompanyName = Mdal.CompanyName,

                    Address = Mdal.Address,
                    PhoneNumber = Mdal.PhoneNumber,
                    CellNumber = Mdal.CellNumber,
                    Email = Mdal.Email,

                    UserName = Mdal.UserName,
                    Password = Mdal.Password
                };
            else return null;
        }
        private List<ProviderDto> ProviderListToDto(List<Provider> Mdal)
        {
            List<ProviderDto> ProviderDtoList = new List<ProviderDto>();
            if (Mdal != null)
            {
                foreach (var m in Mdal)
                    ProviderDtoList.Add(ProviderToDto(m));
            }
            return ProviderDtoList;
        }
        //private bool IsExist(int id)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Provider)
        //    {
        //        if (m.Id == id)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string UserName, string Password)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Provider)
        //    {
        //        if (m.UserName == UserName && m.Password == Password)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string identityNumber)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Provider)
        //    {
        //        if (m.IdentityNumber == identityNumber)
        //            return true;
        //    }
        //    return false;
        //} 
        //public List<ProviderDto> SerachProvider(SearchDto s)
        //{
        //    List<Provider> Providers = db.Provider.ToList();
        //    if (s.Name != null && s.Name != "")
        //        Providers = Providers.Where(t => t.CompanyName.Contains(s.Name)).ToList();

        //    return ProviderListToDto(Providers);

        //}
        //public ProviderDto GetProvider(int id)
        //{
        //    return (ProviderToDto(db.Provider.FirstOrDefault(p=> p.Id == id)));
        //}
        //public List<ProviderDto> GetProviders()
        //{
        //    List<ProviderDto> AllProviders= new List<ProviderDto>();
        //    foreach (var p in db.Provider)
        //    {
        //        AllProviders.Add(ProviderToDto(p));
        //    }
        //    return AllProviders;
        //}
        //public void AddProvider(ProviderDto NewProvider)
        //{
        //    if (IsExist(NewProvider) == false)
        //    {
        //        db.Provider.Add(ProviderToDal(NewProvider));
        //        db.SaveChanges();
        //    }
        //}


        //public void DeleteProvider(int id)
        //{
        //    db.Provider.Remove(db.Provider.FirstOrDefault(p => p.Id == id));
        //}

        //public void UpdateProvider(ProviderDto UpProvider)
        //{
        //    Provider Ezer = db.Provider.FirstOrDefault(m => m.Id == UpProvider.Id);
        //    Ezer.CompanyName = UpProvider.CompanyName;
        //    Ezer.CompanyCode = UpProvider.CompanyCode;         
        //    Ezer.Address = UpProvider.Address;
        //    Ezer.PhoneNumber = UpProvider.PhoneNumber;
        //    Ezer.CellNumber = UpProvider.CellNumber;
        //    Ezer.Email = UpProvider.Email;          
        //    Ezer.UserName = UpProvider.UserName;
        //    Ezer.Password = UpProvider.Password;
        //    Ezer.Comments = UpProvider.Comments,


        //}

        //public bool IsExist(ProviderDto provider)
        //{

        //    foreach (var p in db.Provider)
        //    {
        //        if (p.Id == provider.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public Provider ProviderToDal(ProviderDto Pdto)
        //{
        //    return new Provider()
        //    {
        //        Id=Pdto.Id,
        //        CompanyName=Pdto.CompanyName,
        //        CompanyCode= Pdto.CompanyCode,
        //        Address=Pdto.Address,
        //        PhoneNumber=Pdto.PhoneNumber,
        //        CellNumber=Pdto.CellNumber,
        //        Email=Pdto.Email,
        //        UserName=Pdto.UserName,
        //        Password=Pdto.Password,
        //        Comments=Pdto.Comments,
        //    };
        //}
        //public ProviderDto ProviderToDto(Provider Pdal)
        //{
        //    return new ProviderDto()
        //    {
        //        Id = Pdal.Id,
        //        CompanyName = Pdal.CompanyName,
        //        CompanyCode = Pdal.CompanyCode,
        //        Address = Pdal.Address,
        //        PhoneNumber = Pdal.PhoneNumber,
        //        CellNumber = Pdal.CellNumber,
        //        Email = Pdal.Email,
        //        UserName = Pdal.UserName,
        //        Password = Pdal.Password,
        //        Comments=Pdal.Comments,
        //    };
        //}
    }
}
