using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using DAL;
using System.Dynamic;

namespace BL
{
    public class StatisticsLogic : BaseLogic
    {
        //returns name of companies and their order percentage from a certain date to current date
        public Dictionary<String, double> getOrderPercentByProvider(string date)
        {
            DateTime parseDate = DateTime.Parse(date);
            Dictionary<String, double> results = new Dictionary<string, double>();
            string company;
            double count = 0;
            var orderP = db.MaterialProviders.Where(i => i.datePApproved >= parseDate).GroupBy(p => p.ProviderId).ToList();

            if (orderP != null)
            {
                //for each key-Provider
                orderP.ToList().ForEach(pID =>
                {
                    //percentage
                    count = 100 * pID.Count() / orderP.Count();
                    company = db.Providers.FirstOrDefault(p => p.Id == pID.Key).CompanyName;
                    results.Add(company, count);
                    count = 0;

                });


            }
            return results;
        }

        //returns avg days from time provider approved order to sending it to client
        public Dictionary<String, double> avgMaterialProviding(DateTime date)
        {

            Dictionary<String, double> results = new Dictionary<string, double>();
            double avgDay = 0;
            string company;
            var orderP = db.MaterialProviders.Where(i => i.datePApproved >= date).GroupBy(p => p.ProviderId).ToList();
            if (orderP != null)
            {
                //for each key-Provider
                orderP.ToList().ForEach(pID =>
                {
                    //sending order avg days
                    avgDay = pID.Average(item => (item.datePSend - item.datePApproved).TotalDays);

                    //אותו דבר כמו השורה של הממוצע בקצרה
                    //iterate it's orders
                    //pID.ToList().ForEach(item => {
                    //    avgDay += (item.datePSend - item.datePApproved).TotalDays;
                    //});
                    //avgDay /= pID.Count();
                    company = db.Providers.FirstOrDefault(p => p.Id == pID.Key).CompanyName;
                    results.Add(company, avgDay);
                    avgDay = 0;

                });


            }

            return results;
        }

        //returns # of new customers and it's percentage from a certain date 
        public ExpandoObject customerCount(DateTime date)
        {
            dynamic result = new ExpandoObject();
            double cNum;
            double totalCust;
            double percentage;
            var customers = db.Customers.Where(d => d.registeredDate >= date);
            totalCust = db.Customers.Count();
            cNum = customers.Count();
            percentage = 100 * cNum / totalCust;
            //number of new customers
            result.custNum = cNum;
            //percentage of new customers
            result.custPercent = percentage;
            return result;
        }

        public ExpandoObject orderCount(DateTime date)
        {
            dynamic result = new ExpandoObject();
            double oNum;
            double percentage;
            double totalOrders;
            var orders = db.Orders.Where(d => d.OrderDate >= date);
            totalOrders = db.Orders.Count();
            oNum = orders.Count();
            percentage = 100 * oNum / totalOrders;
            //number of new customers
            result.orderNum = oNum;
            //percentage of new customers
            result.orderPercent = percentage;
            return result;
        }

        //returns for each material name quantities ordered and percentage
        public Dictionary<string, ExpandoObject> MaterialsQuantityOrder(DateTime date)
        {
            Dictionary<string, ExpandoObject> results = new Dictionary<string, ExpandoObject>();
            dynamic resNum = new ExpandoObject();
            string materialName="";
            double quantity = 0;
            double totalOrdered = 0;
            bool IsMat = false;
            List<Order> orders = new List<Order>();
            List<MaterialTypeOrder> materials = new List<MaterialTypeOrder>();

            var materialNames = db.Materials.ToList();

            orders = db.Orders.Where(o => o.OrderDate >= date).ToList();

            orders.ToList().ForEach(o =>
            {
                materials = db.MaterialTypeOrders.Where(m => m.OrderId == o.Id).ToList();
            });
            //sum of all items ordered
            materials.ForEach(m => { totalOrdered += m.Amount; });
            //looping through material names tbl
            materialNames.ForEach(m =>
            {
                //looping through materials ordered
                materials.ForEach(mo =>
                {
                    if (mo.MaterialId == m.Id)
                    { 
                        materialName = m.Name;
                    quantity += mo.Amount;
                        IsMat = true;
                    }
                });

                if (IsMat == true) { 
                resNum.matQuantity=quantity ;
                resNum.matPercent = 100 * quantity / totalOrdered;
                results.Add(materialName, resNum);
                }
                quantity = 0;
                resNum.matmatQuantity = 0;
                resNum.matPercent = 0;


            });
            
            return results;
        }
    }
}
