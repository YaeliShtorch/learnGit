using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaterialProvider
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int MaterialTypeOrderId { get; set; }
        public MaterialTypeOrder MaterialTypeOrder { get; set; }

        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        [Required]
        public int StatusProviderId { get; set; }
        public StatusProvider StatusProvider { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public bool ManagerApproval { get; set; }
        public double Price { get; set; }



    }
}




