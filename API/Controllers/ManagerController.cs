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
    //overcome cores policy
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Manager")]
    public class ManagerController : ApiController

    {
        ManagerLogic ML = new ManagerLogic();
        //[Route("GetExample")]
        //[HttpGet]
        //public string GetManagerExample(int id)
        //{
        //    return ("hhhh");
        //}
        //GETS
        //Get manager by Id
        [Route("GetId")]
        [HttpGet]
        public ManagerDto GetManager(int id)
        {
            return (ML.GetManagerId(id));
        }
        //Get manager by user name ans password

        [Route("GetUP")]
        [HttpGet]
        public ManagerDto GetManagerUP(string UserName, string Password)
        {
            return ML.GetManagerUP(UserName, Password);
        }
        //Get manager by user name
        [Route("GetUN")]
        [HttpGet]
        public ManagerDto GetManagerUN(string UserName)
        {
            return ML.GetManagerUN(UserName);
        }
        //Get all managers

        [Route("GetAll")]
        [HttpGet]
        public List<ManagerDto> GetAllManagers()
        {
            return ML.GetAllManagers();
        }
        //Get manager by Identity number

        [Route("GetIN")]
        [HttpGet]
        public ManagerDto GetManagerIN(string identityNumber)
        {
            return ML.GetManagerIN(identityNumber);
        }
        //Get manager by string that his name or last name contains it

        [Route("GetFLN")]
        [HttpGet]
        public List<ManagerDto> GetManagersFLN(string Name)
        {
            return ML.GetManagersFLN(Name);
        }
        //Get manager by email

        [Route("GetE")]
        [HttpGet]
        public ManagerDto GetManagerE(string Email)
        {
            return ML.GetManagerE(Email);
        }
        //Get manager by phone or cellphone

        [Route("GetP")]
        [HttpGet]
        public ManagerDto GetManagerP(string phone)
        {
            return ML.GetManagerP(phone);
        }
        //Get manager by string that his adress contain it

        [Route("GetA")]
        [HttpGet]
        public List<ManagerDto> GetManagerUP(string Address)
        {
            return ML.GetManagerA(Address);
        }
        //Get manager by his birthdate

        [Route("GetBD")]
        [HttpGet]
        public ManagerDto GetManagerBD(DateTime BirthDate)
        {
            return ML.GetManagerBD(BirthDate);
        }
        //Add manager

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddManager(ManagerDto am)
        {
            try
            {
                ML.AddManager(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //delete manager
        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult DeleteManager(int id)
        {
            try
            {
                ML.DeleteManager(id);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //update manager
        [Route("UpDate")]
        [HttpPost]
        public IHttpActionResult UpDateManager(ManagerDto um)
        {
            try
            {
                ML.UpdateManager(um);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("SearchManager")]
        [HttpPost]
        public List<ManagerDto> SearchManager(SearchDto um)
        {
            try {

                return ML.SerachManager(um);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
