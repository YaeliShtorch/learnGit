using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderDto 
    {
        public int Id { get; set; }
   
        public int CustomerId { get; set; }

        public string SiteAdress { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime OrderDueDate { get; set; }
       
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDone { get; set; }
        public string Comment { get; set; }
     
    }
}

