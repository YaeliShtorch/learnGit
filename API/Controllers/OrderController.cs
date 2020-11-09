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
        public List<OrderDTO> GetAllCusOrders(int id)
        {
            return OM.GetOrdersByCustomerId(id);
        }

        //get all orders
        [Route("GetAll")]
        [HttpGet]
        public List<OrderDto> GetAllOrders()
        {
            return OM.GetAllOrders();


        }

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

        [Route("DeleteMat")]
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
                //OM.UpdateOrder(o);
                Console.WriteLine("dfd");
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [Route("UpdateMat")]
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
                //OM.AddOrder(am);
                Console.WriteLine("dfd");
                return Ok("pppp0");
                //return Content(HttpStatusCode.Created, am);
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


        //[Route("AddVehicleType")]
        //[HttpPost]
        //public IHttpActionResult AddVehicleType(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddVehicleType(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
        //[Route("AddClay")]
        //[HttpPost]
        //public IHttpActionResult AddClay(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddClay(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
        //[Route("AddConcrete")]
        //[HttpPost]
        //public IHttpActionResult AddConcrete(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddConcreteType(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
        //[Route("AddConcDesc")]
        //[HttpPost]
        //public IHttpActionResult AddConcDesc(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddConcDesc(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}

        //[Route("AddDeep")]
        //[HttpPost]
        //public IHttpActionResult AddDeep(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddDeep(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
        //[Route("AddExposue")]
        //[HttpPost]
        //public IHttpActionResult AddExposue(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddExposure(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
        //[Route("AddExtension")]
        //[HttpPost]
        //public IHttpActionResult AddExtension(MaterialDto am)
        //{

        //    try
        //    {
        //        OM.AddExtension(am);
        //        Console.WriteLine("dfd");
        //        return Ok("pppp0");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}



        //[Route("GetVehicleType")]
        //[HttpGet]
        //public List<MaterialDto> GetVehicleType()
        //{


        //    return OM.GetVehicleType();

        //}
        //[Route("GetClay")]
        //[HttpGet]
        //public List<MaterialDto> GetClay()
        //{


        //    return OM.GetClay();

        //}
        //[Route("GetConcrete")]
        //[HttpGet]
        //public List<MaterialDto> GetConcrete()
        //{


        //    return OM.GetConcreteType();

        //}
        //[Route("GetConcDesc")]
        //[HttpGet]
        //public List<MaterialDto> GetConcDesc()
        //{

        //    return OM.GetConcDesc();

        //}

        //[Route("GetDeep")]
        //[HttpGet]
        //public List<MaterialDto> GetDeep()
        //{


        //    return OM.GetDeep();

        //}
        //[Route("GetExposue")]
        //[HttpGet]
        //public List<MaterialDto> GetExposue()
        //{


        //    return OM.GetExposure();

        //}
        //[Route("GetExtension")]
        //[HttpGet]
        //public List<MaterialDto> GetExtension()
        //{


        //    return OM.GetExtension();

        //}


    }






}
