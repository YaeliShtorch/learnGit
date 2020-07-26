using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        CustomerLogic ML = new CustomerLogic();


        //[Route("GetExample")]
        //[HttpGet]
        //public string GetCustomerExample(int id)
        //{
        //    return ("hhhh");
        //}
        //GETS
        //Get Customer by Id
        [Route("GetId")]
        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            return (ML.GetCustomerId(id));
        }
        //Get Customer by user name ans password

        [Route("GetUP")]
        [HttpGet]
        public CustomerDto GetCustomerUP(string UserName, string Password)
        {
            return ML.GetCustomerUP(UserName, Password);
        }
        //Get Customer by user name
        [Route("GetUN")]
        [HttpGet]
        public CustomerDto GetCustomerUN(string UserName)
        {
            return ML.GetCustomerUN(UserName);
        }
        //Get all Customers

        [Route("GetAll")]
        [HttpGet]
        public List<CustomerDto> GetAllCustomers()
        {
            return ML.GetAllCustomers();
        }
        //Get Customer by Identity number

        [Route("GetIN")]
        [HttpGet]
        public CustomerDto GetCustomerIN(string identityNumber)
        {
            return ML.GetCustomerIN(identityNumber);
        }
        //Get Customer by string that his name or last name contains it

        [Route("GetFLN")]
        [HttpGet]
        public List<CustomerDto> GetCustomersFLN(string Name)
        {
            return ML.GetCustomersFLN(Name);
        }
        //Get Customer by email

        [Route("GetE")]
        [HttpGet]
        public CustomerDto GetCustomerE(string Email)
        {
            return ML.GetCustomerE(Email);
        }
        //Get Customer by phone or cellphone

        [Route("GetP")]
        [HttpGet]
        public CustomerDto GetCustomerP(string phone)
        {
            return ML.GetCustomerP(phone);
        }
        //Get Customer by string that his adress contain it

        [Route("GetA")]
        [HttpGet]
        public List<CustomerDto> GetCustomerUP(string Address)
        {
            return ML.GetCustomerA(Address);
        }
        //Get Customer by his birthdate

        [Route("GetBD")]
        [HttpGet]
        public CustomerDto GetCustomerBD(DateTime BirthDate)
        {
            return ML.GetCustomerBD(BirthDate);
        }
        //Add Customer

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto am)
        {
            try
            {
                ML.AddCustomer(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //delete Customer
        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                ML.DeleteCustomer(id);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //update Customer
        [Route("UpDate")]
        [HttpPost]
        public IHttpActionResult UpDateCustomer(CustomerDto um)
        {
            try
            {
                ML.UpdateCustomer(um);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("SearchCustomer")]
        [HttpPost]
        public List<CustomerDto> SearchCustomer(SearchDto um)
        {
            try
            {

                return ML.SerachCustomer(um);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
