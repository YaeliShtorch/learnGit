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
        public DateTime OrderDate { get; set; }
        [Required]
        public string Element { get; set; }
        [Required]
        public string SiteAdress { get; set; }
        [Required]
        public bool ConcreteCheck { get; set; }

        [Required]
        public bool PumpNeeded { get; set; }
        public int PumpId { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public bool IsIssue { get; set; }
        [Required]
        public bool Status { get; set; }
        public bool IsDone { get; set; }

        public string Comments { get; set; }

        public virtual ICollection<MaterialTypeOrder> MaterialTypeOrders { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<DriverWork> DriverWorks { get; set; }

    }
}
