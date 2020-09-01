using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using BL;
namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Provider")]
    public class ProviderController : ApiController
    {


        ProviderLogic ML = new ProviderLogic();
        //[Route("GetExample")]
        //[HttpGet]
        //public string GetProviderExample(int id)
        //{
        //    return ("hhhh");
        //}
        //GETS
        //Get Provider by Id
        [Route("GetId")]
        [HttpGet]
        public ProviderDto GetProvider(int id)
        {
            return (ML.GetProviderId(id));
        }
        //Get Provider by user name ans password

        [Route("GetUP")]
        [HttpGet]
        public ProviderDto GetProviderUP(string UserName, string Password)
        {
            return ML.GetProviderUP(UserName, Password);
        }
        //Get Provider by user name
        [Route("GetUN")]
        [HttpGet]
        public ProviderDto GetProviderUN(string UserName)
        {
            return ML.GetProviderUN(UserName);
        }
        //Get all Providers

        [Route("GetAll")]
        [HttpGet]
        public List<ProviderDto> GetAllProviders()
        {
            return ML.GetAllProviders();
        }
        //Get Provider by Identity number

        [Route("GetIN")]
        [HttpGet]
        public ProviderDto GetProviderIN(string identityNumber)
        {
            return ML.GetProviderIN(identityNumber);
        }
        //Get Provider by string that his name or last name contains it

        [Route("GetFLN")]
        [HttpGet]
        public List<ProviderDto> GetProvidersFLN(string Name)
        {
            return ML.GetProvidersFLN(Name);
        }
        //Get Provider by email

        [Route("GetE")]
        [HttpGet]
        public ProviderDto GetProviderE(string Email)
        {
            return ML.GetProviderE(Email);
        }
        //Get Provider by phone or cellphone

        [Route("GetP")]
        [HttpGet]
        public ProviderDto GetProviderP(string phone)
        {
            return ML.GetProviderP(phone);
        }
        //Get Provider by string that his adress contain it

        [Route("GetA")]
        [HttpGet]
        public List<ProviderDto> GetProviderUP(string Address)
        {
            return ML.GetProviderA(Address);
        }
        //Get Provider by his birthdate

        //[Route("GetBD")]
        //[HttpGet]
        //public ProviderDto GetProviderBD(DateTime BirthDate)
        //{
        //    return ML.GetProviderBD(BirthDate);
        //}
        //Add Provider

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddProvider(ProviderDto am)
        {
            try
            {
                ML.AddProvider(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //delete Provider
        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult DeleteProvider(int id)
        {
            try
            {
                ML.DeleteProvider(id);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //update Provider
        [Route("UpDate")]
        [HttpPost]
        public IHttpActionResult UpDateProvider(ProviderDto um)
        {
            try
            {
                ML.UpdateProvider(um);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //[Route("SearchProvider")]
        //[HttpPost]
        //public List<ProviderDto> SearchProvider(SearchDto um)
        //{
        //    try
        //    {

        //        return ML.SerachProvider(um);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

    }
}
