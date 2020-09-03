using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DAL
{
    public class ConcreteType
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<MaterialTypeOrder> MaterialTypeOrders { get; set; }
    }
}
