using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderDtoCreate
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string SiteAdress { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime OrderDueDate { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaterialTypeOrderId  { get; set; }
        public bool ConcreteTest { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDone { get; set; }
        public string ManagerComment { get; set; }
        public string Comment { get; set; }

    }
}

