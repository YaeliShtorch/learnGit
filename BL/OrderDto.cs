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
       
        public DateTime OrderDate { get; set; }

        public string Element { get; set; }
        public string SiteAdress { get; set; }
        public bool ConcreteCheck { get; set; }
        public bool PumpNeeded { get; set; }
        public string PumpType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsIssue { get; set; }
        public bool Status { get; set; }
     
    }
}
