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
        OrderLogic ML = new OrderLogic();


        //Get Order by id
        [Route("GetId")]
        [HttpGet]
        public OrderDto GetOrder(int id)
        {
            return (ML.GetOrderById(id));
        }

        //get AllOrders by customerId
        [Route("GetAllCO")]
        [HttpGet]
        public List<OrderDto> GetAllCusOrders(int id)
        {
            return ML.GetOrdersByCustomerId(id);
        }

        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult deletOrderbyId(int id)
        {
         
            try
            {
                ML.DeleteOrder(id);;
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
                ML.UpdateOrder(o);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

    }
}
