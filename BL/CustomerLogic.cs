using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class CustomerLogic:BaseLogic
    {

        public CustomerDto GetCustomerId(int id)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.Id == id)));

        }

        public CustomerDto GetCustomerUP(string UserName, string Password)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.UserName == UserName && m.Password == Password)));

        }
        public CustomerDto GetCustomerUN(string UserName)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.UserName == UserName)));

        }

        public List<CustomerDto> GetAllCustomers()
        {
            List<CustomerDto> AllCustomers = new List<CustomerDto>();
            foreach (var m in db.Customers)
            {
                AllCustomers.Add(CustomerToDto(m));
            }
            return AllCustomers;
        }
        public CustomerDto GetCustomerIN(string identityNumber)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.IdentityNumber == identityNumber)));

        }

        public List<CustomerDto> GetCustomersFLN(string Name)
        {
            List<CustomerDto> AllCustomers = new List<CustomerDto>();
            foreach (var m in db.Customers)
            {
                if (m.FirstName.Contains(Name) || m.LastName.Contains(Name))
                    AllCustomers.Add(CustomerToDto(m));
            }
            return AllCustomers;
        }

        public CustomerDto GetCustomerE(string Email)
        {
            // ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.Email == Email)));

        }

        public CustomerDto GetCustomerP(string phone)
        {
            //    ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.PhoneNumber == phone || m.CellNumber == phone)));

        }

        public List<CustomerDto> GetCustomerA(string Address)
        {
            List<CustomerDto> AllCustomers = new List<CustomerDto>();
            foreach (var m in db.Customers)
            {
                if (m.Address.Contains(Address))
                    AllCustomers.Add(CustomerToDto(m));
            }
            return AllCustomers;


        }
        public CustomerDto GetCustomerBD(DateTime BirthDate)
        {
            //  ShachlavDB db = new ShachlavDB();

            return (CustomerToDto(db.Customers.FirstOrDefault(m => m.BirthDate == BirthDate)));

        }
        public void AddCustomer(CustomerDto NewCustomer)
        {
            //   ShachlavDB db = new ShachlavDB();
            if (IsExist(NewCustomer) == false)
            {
                db.Customers.Add(CustomerToDal(NewCustomer));
                db.SaveChanges();
            }
        }


        public void DeleteCustomer(int id)
        {
            //   ShachlavDB db = new ShachlavDB();
            db.Customers.Remove(db.Customers.FirstOrDefault(m => m.Id == id));
            db.SaveChanges();
        }

        public void UpdateCustomer(CustomerDto UpCustomer)
        {
            //  ShachlavDB db = new ShachlavDB();
            Customer Ezer = db.Customers.FirstOrDefault(m => m.Id == UpCustomer.Id);
            Ezer.IdentityNumber = UpCustomer.IdentityNumber;
            Ezer.FirstName = UpCustomer.FirstName;
            Ezer.LastName = UpCustomer.LastName;
            Ezer.Address = UpCustomer.Address;
            Ezer.PhoneNumber = UpCustomer.PhoneNumber;
            Ezer.CellNumber = UpCustomer.CellNumber;
            Ezer.Email = UpCustomer.Email;
            Ezer.BirthDate = UpCustomer.BirthDate;
            Ezer.UserName = UpCustomer.UserName;
            Ezer.Password = UpCustomer.Password;
            db.SaveChanges();
        }

        private bool IsExist(CustomerDto Customer)
        {
            //  ShachlavDB db = new ShachlavDB();
            foreach (var m in db.Customers)
            {
                if (m.Id == Customer.Id)
                    return true;
            }
            return false;
        }


        private Customer CustomerToDal(CustomerDto Mdto)
        {
            if (Mdto != null)
                return new Customer()
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
        private CustomerDto CustomerToDto(Customer Mdal)
        {
            if (Mdal != null)
                return new CustomerDto()
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
        private List<CustomerDto> CustomerListToDto(List<Customer> Mdal)
        {
            List<CustomerDto> CustomerDtoList = new List<CustomerDto>();
            if (Mdal != null)
            {
                foreach (var m in Mdal)
                    CustomerDtoList.Add(CustomerToDto(m));
            }
            return CustomerDtoList;
        }
        //private bool IsExist(int id)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Customer)
        //    {
        //        if (m.Id == id)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string UserName, string Password)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Customer)
        //    {
        //        if (m.UserName == UserName && m.Password == Password)
        //            return true;
        //    }
        //    return false;
        //}
        //private bool IsExist(string identityNumber)
        //{
        //    ShachlavDB db = new ShachlavDB();
        //    foreach (var m in db.Customer)
        //    {
        //        if (m.IdentityNumber == identityNumber)
        //            return true;
        //    }
        //    return false;
        //} 
        public List<CustomerDto> SearchCustomer(SearchDto s)
        {
            List<Customer> Customers = db.Customers.ToList();
            if (s.Name != null && s.Name != "")
                Customers = Customers.Where(t => t.FirstName.Contains(s.Name)).ToList();
            if (s.FromDate != null && s.FromDate != default(DateTime))
                Customers = Customers.Where(t => t.BirthDate >= s.FromDate).ToList();
            if (s.ToDate != null && s.ToDate != default(DateTime))
                Customers = Customers.Where(t => t.BirthDate <= s.ToDate).ToList();
            return CustomerListToDto(Customers);

        }
    }
}
