using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderDetailsDto 
    {
        public int Id;
        public int OrderId { get; set; }
       
        public int ProviderId { get; set; }
      
       // public int MaterialId { get; set; }
      
        public int Amount { get; set; }
    }
}

