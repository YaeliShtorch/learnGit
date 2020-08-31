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
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public bool IsConcrete { get; set; }
        public int ConcreteTypeId { get; set; }
        public ConcreteType ConcreteType { get; set; }
        public int ConcDescId { get; set; }
        public ConcDesc ConcDesc { get; set; }
        public int DeepId { get; set; }
        public Deep Deep { get; set; }
        public int ExposureId { get; set; }
        public Exposure Exposure { get; set; }
        public int ExtensionId { get; set; }
        public Extension Extension { get; set; }
        public bool IsClay { get; set; }
        public int ClayTypeId { get; set; }
        public ClayType ClayType { get; set; }
        public bool IsPump { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        [Required]
        public string Element { get; set; }
        [Required]
        public int Amount { get; set; }


    }
}
