using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MaterialTypeOrderDto
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool IsConcrete { get; set; }
        public int ConcreteTypeId { get; set; }

        public int ConcDescId { get; set; }

        public int DeepId { get; set; }

        public int ExposureId { get; set; }

        public int ExtensionId { get; set; }

        public bool IsClay { get; set; }
        public int ClayTypeId { get; set; }

        public bool IsPump { get; set; }
        public int VehicleTypeId { get; set; }
        public string Element { get; set; }
        public int Amount { get; set; }



    }
}