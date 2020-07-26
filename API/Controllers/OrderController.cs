using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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



    }
}
