using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    //[Table("dbo.MaterialDTO")]
    [NotMapped]
    public class MaterialDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Element { get; set; }
        public int Amount { get; set; }
        public string StatusMaterial { get; set; }
        public string MaterialName { get; set; }
        public string ManagerComment { get; set; }
        public int? PipeLength { get; set; }
    }
}
