using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public string SiteAdress { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime OrderDueDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDone { get; set; }
        public string ManagerComment { get; set; }
        public string Comment { get; set; }
        public bool ConcreteTest { get; set; }
        public virtual ICollection<DriverWork> DriverWorks { get; set; }
        public virtual ICollection<MaterialTypeOrder> MaterialTypeOrder { get; set; }


    }
}
