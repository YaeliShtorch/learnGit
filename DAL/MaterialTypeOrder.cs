using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaterialTypeOrder
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string Element { get; set; }
        public int ? Amount { get; set; }
        public int? StatusMaterialId { get; set; }
        public StatusMaterial StatusMaterial { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }
        public virtual ICollection<MaterialProvider> MaterialProviders { get; set; }


    }
}
