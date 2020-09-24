using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class StatusMaterial
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MaterialTypeOrder> MaterialTypeOrder { get; set; }

    }
}
