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
        [Route("GetAllVehicles")]
        [HttpGet]
        public List<VehicleDto> GettAllVehicles()
        {
            return ML.GettAllVehicles();
        }
    }
}
