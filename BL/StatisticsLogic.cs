using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using DAL;
namespace BL
{
    class StatisticsLogic : BaseLogic
    {
        //returns name of companies and their order percentage from a certain date to current date
        public Dictionary<String, double> getOrderPercentByProvider(DateTime date)
        {
            Dictionary<String, double> results = new Dictionary<string, double>();
            string company;
            double count=0;
            var orderP = db.MaterialProviders.Where(i => i.datePApproved >= date).GroupBy(p => p.ProviderId).ToList();

            if (orderP != null)
            {
                //for each key-Provider
                orderP.ToList().ForEach(pID=>
                {
                    //percentage
                    count = 100*pID.Count()/orderP.Count();
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
            double avgDay=0;
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
        public List<double> customerCount(DateTime date)
        {
            double cNum;
            double totalCust;
            double percentage;
            List<double> custNum=new List<double>();
            var customers = db.Customers.Where(d => d.registeredDate >= date);
            totalCust = db.Customers.Count();
            cNum = customers.Count();
            percentage = 100 * cNum / totalCust;
            //number of new customers
            custNum.Add(cNum);
            //percentage of new customers
            custNum.Add(percentage);
            return custNum;
        }

        public List<double> orderCount(DateTime date)
        {
            double oNum;
            double percentage;
            double totalOrders;
            List<double> orderNum = new List<double>();
            var orders = db.Orders.Where(d => d.OrderDate >= date);
            totalOrders = db.Orders.Count();
            oNum = orders.Count();
            percentage = 100 * oNum /totalOrders;
            //number of new customers
            orderNum.Add(oNum);
            //percentage of new customers
            orderNum.Add(percentage);
            return orderNum;
        }

        //returns for each material name quantities ordered and percentage
        public Dictionary<string, List<double>> MaterialsQuantityOrder(DateTime date)
        {
            Dictionary<string, List<double>> results = new Dictionary<string, List<double>>();
            string materialName;
            double quantity;
            double percentage;
            var orders = db.Orders.Where(o => o.OrderDate >= date);
            orders.ToList().ForEach(o => {
                var materials = db.MaterialTypeOrders.Where(m => m.OrderId == o.Id);
            });
            
            //materials.

            return results;
        }
    }
}
