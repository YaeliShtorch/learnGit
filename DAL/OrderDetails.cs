using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class OrderDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }
    
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
      
        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
       
        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        
        [Required]
        public int Amount { get; set; }
      
    }
}
