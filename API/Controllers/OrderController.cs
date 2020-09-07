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
        public List<OrderDto> getAllOrders()
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
        [AcceptVerbs("GET", "POST")]
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

        [Route("GetAllM")]
        [HttpGet]
        public List<MaterialDto> getAllMaterials()
        {
            return OM.getAllMaterials();
        }

        [Route("getMaterialsByCategoryName")]
        [HttpGet]
        public List<MaterialDto> getMaterialsByCategory(string name)
        {
            return OM.getMaterialsByCategoryName(name);
        }

        [Route("getMaterialById")]
        [HttpGet]
        public MaterialDto getMaterialbyId(int id)
        {
            return OM.getMaterialbyId(id);

        }
        [Route ("getMaterialIdByName")]
        [HttpGet]
        public MaterialDto getMaterialIdByName(string name)
        {
            return OM.getMaterialIdByName(name);
        }


        [Route("DeleteMaterial")]
        [HttpGet]
        public IHttpActionResult deleteMaterial(MaterialDto m) {
            try
            {
                OM.deleteMaterial(m); ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }


        [Route("AddMaterial")]
        [HttpPost]
        public IHttpActionResult addMaterial(MaterialDto m)
        {
            try
            {
                OM.addOrder(m); ;
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("UpdateMaterial")]
        [HttpPost]
        public IHttpActionResult updateMaterial(MaterialDto m)
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
        public List<MaterialCategoryDto> getCategories()
        {
            return OM.getCategories();
        }

        [Route("AddMaterialCategory")]
        [HttpPost]

        public IHttpActionResult addMaterialCategory(MaterialCategoryDto m)
        {
            try
            {
                OM.addMaterialCategory(m);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("DeleteMaterialCategory")]
        [HttpGet]

        public IHttpActionResult deleteMaterialCategory(MaterialCategoryDto m)
        {
            try
            {
                OM.deleteMaterialCategory(m);
                return Ok("pppp0");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        [Route("UpdateMaterialCategory")]
        [HttpPost]

        public IHttpActionResult updateMaterialCat(MaterialCategoryDto m)
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
