using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class OrderDtoRead
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SiteAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDueDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaterialTypeOrderId { get; set; }
        public bool ConcreteTest { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDone { get; set; }
        public string ManagerComment { get; set; }
        public string Comment { get; set; }
        public bool IsConcrete { get; set; }
        public int ConcreteTypeId { get; set; }
        public string ConcreteName { get; set; }
        public int ConcDescId { get; set; }
        public string ConcDescName { get; set; }
        public int DeepId { get; set; }
        public string DeepName { get; set; }
        public int ExposureId { get; set; }
        public string ExposureName { get; set; }
        public int ExtensionId { get; set; }
        public string ExtensionName { get; set; }
        public bool IsClay { get; set; }
        public int ClayTypeId { get; set; }
        public bool IsPump { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleTypeName { get; set; }
        public string Element { get; set; }
        public int Amount { get; set; }

    }
}
