using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Order")]

    public class OrderController : ApiController
    {
        OrderLogic OM = new OrderLogic();


        //Get Order by id
        [Route("GetId")]
        [HttpGet]
        public OrderDto GetOrder(int id)
        {
            return (OM.GetOrderById(id));
        }

        //get AllOrders by customerId
        [Route("GetAllCO")]
        [HttpGet]
        public List<OrderDto> GetAllCusOrders(int id)
        {
            return OM.GetOrdersByCustomerId(id);
        }

        //get all orders
        [Route("GetAll")]
        [HttpGet]
        public List<Order> getAllOrders()
        {
            return OM.getAllOrders();


        }

        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult deletOrderbyId(int id)
        {
         
            try
            {
                OM.DeleteOrder(id);;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult updateOrder(OrderDto o)
        {
            
            try
            {
                //OM.UpdateOrder(o);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("AddOrder")]
        [HttpPost]
        public IHttpActionResult AddOrder(OrderDto am, List<MaterialTypeOrderDto> mto)
        {

            try
            {
                //OM.AddOrder(am, mto);
                OM.AddOrder(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddVehicleType")]
        [HttpPost]
        public IHttpActionResult AddVehicleType(MaterialDto am)
        {

            try
            {
                OM.AddVehicleType(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddClay")]
        [HttpPost]
        public IHttpActionResult AddClay(MaterialDto am)
        {

            try
            {
                OM.AddClay(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddConcrete")]
        [HttpPost]
        public IHttpActionResult AddConcrete(MaterialDto am)
        {

            try
            {
                OM.AddConcreteType(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddConcDesc")]
        [HttpPost]
        public IHttpActionResult AddConcDesc(MaterialDto am)
        {

            try
            {
                OM.AddConcDesc(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("AddDeep")]
        [HttpPost]
        public IHttpActionResult AddDeep(MaterialDto am)
        {

            try
            {
                OM.AddDeep(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddExposue")]
        [HttpPost]
        public IHttpActionResult AddExposue(MaterialDto am)
        {

            try
            {
                OM.AddExposure(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [Route("AddExtension")]
        [HttpPost]
        public IHttpActionResult AddExtension(MaterialDto am)
        {

            try
            {
                OM.AddExtension(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }



        [Route("GetVehicleType")]
        [HttpGet]
        public List<MaterialDto> GetVehicleType()
        {


            return OM.GetVehicleType();

        }
        [Route("GetClay")]
        [HttpGet]
        public List<MaterialDto> GetClay()
        {


            return OM.GetClay();

        }
        [Route("GetConcrete")]
        [HttpGet]
        public List<MaterialDto> GetConcrete()
        {


            return OM.GetConcreteType();

        }
        [Route("GetConcDesc")]
        [HttpGet]
        public List<MaterialDto> GetConcDesc()
        {

            return OM.GetConcDesc();

        }

        [Route("GetDeep")]
        [HttpGet]
        public List<MaterialDto> GetDeep()
        {


            return OM.GetDeep();

        }
        [Route("GetExposue")]
        [HttpGet]
        public List<MaterialDto> GetExposue()
        {


            return OM.GetExposure();

        }
        [Route("GetExtension")]
        [HttpGet]
        public List<MaterialDto> GetExtension()
        {


            return OM.GetExtension();

        }


    }






}
