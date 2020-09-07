using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MaterialTypeOrderDto
    {

        public int Id { get; set; }        
        public int ?OrderId { get; set; }       
        public string Element { get; set; }
        public int ?Amount { get; set; }
        public int? StatusMaterialId { get; set; }
        public int ?MaterialId { get; set; }



    }
}