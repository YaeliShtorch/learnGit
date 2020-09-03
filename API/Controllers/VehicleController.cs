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

    [RoutePrefix("api/Vehicle")]
    public class VehicleController : ApiController
    {
        VehicleLogic ML = new VehicleLogic();

        //get all vehicles
        [Route("GetAll")]
        [HttpGet]
        public List<VehicleDto> GetAllVehicles()
        {
            return ML.GetAllVehicles();
        }

        //    //get vehicle types types
        //    [Route("getAllPumpTypes")]
        //    [HttpGet]
        //    public List<VehicleTypeDto> GetPumpTypes()
        //    {

        //        return ML.GetAllPumpTypes();
        //    }

        //    //add vehicle type
        //    [Route("AddPumpType")]
        //    [HttpPost]
        //    public IHttpActionResult addVehicleType(PumpTypeDto pT)
        //    {
        //        try
        //        {
        //            ML.addPumpType(pT);
        //            Console.WriteLine("dfd");
        //            return Ok("pppp0");
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.ToString());
        //        }

        //    }

        //    //delete vehicle type
        //    [Route("DeletePumpType")]
        //    [HttpGet]
        //    public IHttpActionResult DeletePumpType(int id)
        //    {
        //        try
        //        {
        //            ML.deletePumpType(id);
        //            return Ok("pppp0");
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.ToString());
        //        }

        //    }
    }
}
