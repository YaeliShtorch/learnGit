using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("dbo.OrderDTO")]
    public class OrderViewDTO
    {  
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string SiteAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDueDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDone { get; set; }
        public string ManagerComment { get; set; }
        public string Comment { get; set; }
        public bool ConcreteTest { get; set; }

        public List<MaterialTypeOrderView> MaterialOrderL { get; set; }

    }
}
