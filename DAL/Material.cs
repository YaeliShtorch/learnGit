using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaterialCategoryId { get; set; }

        public int ? PipeLength { get; set; }
        public MaterialCategory MaterialCategory { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
