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

    [RoutePrefix("api/Order")]

    public class OrderController : ApiController
    {
       OrderLogic OM = new OrderLogic();


        //Get Order by id
        //[Route("GetId")]
        //[HttpGet]
        //public OrderDto GetOrder(int id)
        //{
            //return (OM.GetOrderById(id));
        //}

        //get AllOrders by customerId
        [Route("GetAllCO")]
        [HttpGet]
        public List<OrderDTO> GetAllCusOrders(int id)
        {
            return OM.GetOrdersByCustomerId(id);
        }

        //get all orders
        [Route("GetAll")]
        [HttpGet]
        public List<OrderDTO> GetAllOrders()
        {
            return OM.GetAllOrders();


        }
        //get orders by city 
        [Route("GetCityOrders")]
        [HttpGet]
        public List<OrderDTO> GetCityOrders(string city)
        {
            return OM.GetCityOrders(city);
        }

        //get orders by Order date
        [Route("GetOrdersByOrderDate")]
        [HttpGet]
        public List<OrderDTO> GetOrdersByDate(DateTime date)
        {
            return OM.GetOrdersByDate(date);

        }

        //delete whole order + its materials
        [Route("Delete")]
        [HttpGet]
        public IHttpActionResult DeletOrderbyId(int id)
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
        //delete material order
        [Route("DeleteOrderMat")]
        [HttpGet]
        public IHttpActionResult DeleteMaterialOrder(int id)
        {
            try
            {
                OM.DeleteOrderMat(id); ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateOrder(OrderDto o)
        {
            
            try
            {
                OM.UpdateOrder(o);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        //update a specific order material
        [Route("UpdateOrderMat")]
        [HttpPost]
        public IHttpActionResult UpdateOrderMat(MaterialTypeOrderDto m)
        {
            try
            {
                OM.UpdateOrderMaterial(m);
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
        //[AcceptVerbs("GET", "POST")]
        public IHttpActionResult AddOrder(OrderDto am)
        {

            try
            {
                OM.AddOrder(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("AddOrderMat")]
        [HttpPost]
        public IHttpActionResult AddOrderMat(MaterialTypeOrderDto m)
        {
            try
            {
                OM.AddOrderMat(m);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        //get materials
        [Route("GetAllM")]
        [HttpGet]
        public List<MaterialDto> GetAllMaterials()
        {
             return OM.GetAllMaterials();
        }

        [Route("getMaterialsByCategoryName")]
        [HttpGet]
        public List<MaterialDto> GetMaterialsByCategory(string name)
        {
            return OM.GetMaterialsByCategoryName(name);
        }

        [Route("getMaterialById")]
        [HttpGet]
        public MaterialDto GetMaterialbyId(int id)
        {
            return OM.GetMaterialbyId(id);

        }
        [Route ("getMaterialByName")]
        [HttpGet]
        public MaterialDto GetMaterialIdByName(string name)
        {
            return OM.GetMaterialIdByName(name);
        }


        [Route("DeleteMaterial")]
        [HttpGet]
        public IHttpActionResult DeleteMaterial(int id) {
            try
            {
                OM.DeleteMaterial(id); ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }


        [Route("AddMaterial")]
        [HttpPost]
        public IHttpActionResult AddMaterial(MaterialDto m)
        {
            try
            {
                OM.AddOrder(m); ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("UpdateMaterial")]
        [HttpPost]
        public IHttpActionResult UpdateMaterial(MaterialDto m)
        {
            try
            {
                OM.UpdateMaterial(m) ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("GetMaterialCategories")]
        [HttpGet]
        public List<MaterialCategoryDto> GetCategories()
        {
            return OM.GetCategories();
        }

        [Route("AddMaterialCategory")]
        [HttpPost]

        public IHttpActionResult AddMaterialCategory(MaterialCategoryDto m)
        {
            try
            {
                OM.AddMaterialCategory(m);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("DeleteMaterialCategory")]
        [HttpGet]

        public IHttpActionResult DeleteMaterialCategory(int id)
        {
            try
            {
                OM.DeleteMaterialCategory(id);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("UpdateMaterialCategory")]
        [HttpPost]

        public IHttpActionResult UpdateMaterialCat(MaterialCategoryDto m)
        {
            try
            {
                OM.UpdateMaterialCategory(m);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("GetStatusMaterials")]
        [HttpGet]
        public List<StatusDto> GetStatus()
        {
            return OM.StatusMaterials();
        }




    }






}
