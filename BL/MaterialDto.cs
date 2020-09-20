using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
        public int MaterialCategoryId { get; set; }
        //public int? PipeLength { get; set; }
    }
}
