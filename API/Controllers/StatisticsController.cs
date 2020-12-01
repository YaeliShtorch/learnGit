using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using BL;
using System.Dynamic;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/Statistics")]
    public class StatisticsController
    {
        StatisticsLogic ST = new StatisticsLogic();

        //get order percentage by company
        [Route("GetOrderPCTByComp")]
        [HttpGet]
        public Dictionary<string, double> OrderPercentByCompany(DateTime date)
        {
                return ST.getOrderPercentByProvider(date);
        }

        //get average days of companies sending items
        [Route("GetAVGDayDelByComp")]
        [HttpGet]
        public Dictionary<string, double> avgMaterialProviding(DateTime date)
        {
            return ST.avgMaterialProviding(date);
        }

        //get amount and PCT of new customers by given date
        [Route("GetCountNewCustomers")]
        [HttpGet]
        public ExpandoObject customerCount(DateTime date)
        {
            return ST.customerCount(date);
        }

        //get amount and PCT of new orders by given date
        [Route("GetCountNewOrders")]
        [HttpGet]
        public ExpandoObject orderCount(DateTime date)
        {
            return ST.orderCount(date);
        }

        //get amount and PCT for each materials ordered
        [Route("GetCountOrderedMaterials")]
        [HttpGet]
        public Dictionary<string, ExpandoObject> MaterialsQuantityOrder(DateTime date)
        {
            return ST.MaterialsQuantityOrder(date);
        }

    }
}