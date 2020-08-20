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

    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {
        DriverLogic ML = new DriverLogic();
        //[Route("GetExample")]
        //[HttpGet]
        //public string GetDriverExample(int id)
        //{
        //    return ("hhhh");
        //}
        //GETS
        //Get Driver by Id
        [Route("GetId")]
        [HttpGet]
        public DriverDto GetDriver(int id)
        {
            return (ML.GetDriverId(id));
        }
        //Get Driver by user name ans password

        [Route("GetUP")]
        [HttpGet]
        public DriverDto GetDriverUP(string UserName, string Password)
        {
            return ML.GetDriverUP(UserName, Password);
        }
        //Get Driver by user name
        [Route("GetUN")]
        [HttpGet]
        public DriverDto GetDriverUN(string UserName)
        {
            return ML.GetDriverUN(UserName);
        }
        //Get all Drivers

        [Route("GetAll")]
        [HttpGet]
        public List<DriverDto> GetAllDrivers()
        {
            return ML.GetAllDrivers();
        }
        //Get Driver by Identity number

        [Route("GetIN")]
        [HttpGet]
        public DriverDto GetDriverIN(string identityNumber)
        {
            return ML.GetDriverIN(identityNumber);
        }
        //Get Driver by string that his name or last name contains it

        [Route("GetFLN")]
        [HttpGet]
        public List<DriverDto> GetDriversFLN(string Name)
        {
            return ML.GetDriversFLN(Name);
        }
        //Get Driver by email

        [Route("GetE")]
        [HttpGet]
        public DriverDto GetDriverE(string Email)
        {
            return ML.GetDriverE(Email);
        }
        //Get Driver by phone or cellphone

        [Route("GetP")]
        [HttpGet]
        public DriverDto GetDriverP(string phone)
        {
            return ML.GetDriverP(phone);
        }
        //Get Driver by string that his adress contain it

        [Route("GetA")]
        [HttpGet]
        public List<DriverDto> GetDriverUP(string Address)
        {
            return ML.GetDriverA(Address);
        }
        //Get Driver by his birthdate

        [Route("GetBD")]
        [HttpGet]
        public DriverDto GetDriverBD(DateTime BirthDate)
        {
            return ML.GetDriverBD(BirthDate);
        }
        //Add Driver

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddDriver(DriverDto am)
        {
            try
            {
                ML.AddDriver(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //delete Driver
        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult DeleteDriver(int id)
        {
            try
            {
                ML.DeleteDriver(id);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //update Driver
        [Route("UpDate")]
        [HttpPost]
        public IHttpActionResult UpDateDriver(DriverDto um)
        {
            try
            {
                ML.UpdateDriver(um);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("SearchDriver")]
        [HttpPost]
        public List<DriverDto> SearchDriver(SearchDto um)
        {
            try
            {

                return ML.SerachDriver(um);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //get vehicle types
        [Route("getAllPumpTypes")]
        [HttpGet]
        public List<PumpTypeDto> GetVehicleTypes()
        {

            return ML.GetAllPumpTypes();
        }

        //add vehicle type
        [Route("AddPumpType")]
        [HttpPost]
        public IHttpActionResult addVehicleType(PumpTypeDto pT)
        {
            try
            {
                ML.addPumpType(pT);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }

        //delete vehicle type
        [Route("DeletePumpType")]
        [HttpGet]
        public IHttpActionResult DeletePumpType(int id)
        {
            try
            {
                ML.deletePumpType(id);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

    }
}
