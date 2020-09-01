using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderLogic:BaseLogic
    {
        public OrderDto GetOrderById(int id)
        {
            return (OrderToDto(db.Orders.FirstOrDefault(o => o.Id == id)));
        }
        public List<OrderDto> GetOrdersByCustomerId(int Id)
        {
            List<Order> AllOrders = new List<Order>();
           
            AllOrders = db.Orders.Where(o1 => o1.CustomerId == Id).ToList();
            //foreach (var o in db.Orders)
            //{
               
            //}
            return OrdersToDto(AllOrders);
        }
        public List<OrderDto> GetOrders()
        {
            List<OrderDto> AllOrders = new List<OrderDto>();
            foreach (var o in db.Orders)
            {
                AllOrders.Add(OrderToDto(o));
            }
            return AllOrders;
        }
        public void AddOrder(OrderDto NewOrder)
        {
            if (IsExist(NewOrder) == false)
            {
                db.Orders.Add(OrderToDal(NewOrder));
                db.SaveChanges();
            }
        }


        public void DeleteOrder(int id)
        {
            db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();
        }

        //public void UpdateOrder(OrderDto UpOrder)
        //{
        //    Order Ezer = db.Orders.FirstOrDefault(o => o.Id == UpOrder.Id);

        //    Ezer.OrderDate = UpOrder.OrderDate;
        //    Ezer.CustomerId = UpOrder.CustomerId;
        //    Ezer.ConcreteCheck = UpOrder.ConcreteCheck;
        //    Ezer.Element = UpOrder.Element;
        //    Ezer.EndTime = UpOrder.EndTime;
        //    Ezer.IsIssue = UpOrder.IsIssue;
        //    Ezer.PumpNeeded = UpOrder.PumpNeeded;
        //    Ezer.PumpTypeId = UpOrder.PumpTypeId;
        //    Ezer.SiteAdress = UpOrder.SiteAdress;
        //    Ezer.StartTime = UpOrder.StartTime;
        //    Ezer.Status = UpOrder.Status;
        //    Ezer.Comments = UpOrder.Comments;
        //    db.SaveChanges();


        //}

        public List<Order> getAllOrders()
        {
            List<Order> AllOrderL = new List<Order>();
            AllOrderL = db.Orders.ToList();
            return AllOrderL;
        }

        public bool IsExist(OrderDto order)
        {

            foreach (var o in db.Orders)
            {
                if (o.Id == order.Id)
                    return true;
            }
            return false;
        }
        public Order OrderToDal(OrderDto Odto)
        {
            return new Order()
            {
                Id = Odto.Id,
                CustomerId = Odto.CustomerId,
                SiteAdress = Odto.SiteAdress,
                OrderDate = Odto.OrderDate,
                OrderDueDate =Odto.OrderDueDate,
                StartTime=Odto.StartTime,
                EndTime = Odto.EndTime,
                IsApproved = Odto.IsApproved,
                IsDone = Odto.IsDone,
                Comment=Odto.Comment
            };
        }

        public OrderDto OrderToDto(Order Odal)
        {

            return new OrderDto()
            {
                Id = Odal.Id,
                CustomerId = Odal.CustomerId,
                SiteAdress = Odal.SiteAdress,
                OrderDate = Odal.OrderDate,
                OrderDueDate = Odal.OrderDueDate,
                StartTime = Odal.StartTime,
                EndTime = Odal.EndTime,
                IsApproved = Odal.IsApproved,
                IsDone = Odal.IsDone,
                Comment = Odal.Comment
            };
        }
        public List<OrderDto> OrdersToDto(List<Order> Odal)
        {
            List<OrderDto> oDto = new List<OrderDto>();
            foreach (var od in Odal)
            {
                oDto.Add(new OrderDto()
                {
                    Id = od.Id,
                    CustomerId = od.CustomerId,
                    SiteAdress = od.SiteAdress,
                    OrderDate = od.OrderDate,
                    OrderDueDate = od.OrderDueDate,
                    StartTime = od.StartTime,
                    EndTime = od.EndTime,
                    IsApproved = od.IsApproved,
                    IsDone = od.IsDone,
                    Comment = od.Comment
                });

            }
            return oDto;
        }

        public MaterialTypeOrder MaterialTypeOrderToDal(MaterialTypeOrderDto Odto)
        {
            return new MaterialTypeOrder()
            {
                Id = Odto.Id,
                OrderId = Odto.OrderId,
                IsConcrete = Odto.IsConcrete,
                ConcreteTypeId = Odto.ConcreteTypeId,
                ConcDescId = Odto.ConcDescId,
                DeepId = Odto.DeepId,
                ExposureId = Odto.ExposureId,
                ExtensionId = Odto.ExtensionId,
                IsClay = Odto.IsClay,
                ClayTypeId = Odto.ClayTypeId,
                IsPump = Odto.IsPump,
                VehicleTypeId = Odto.VehicleTypeId,
                Element = Odto.Element,
                Amount = Odto.Amount

            };
        }
        public MaterialTypeOrderDto MaterialTypeOrderDto(MaterialTypeOrder Odal)
        {

            return new MaterialTypeOrderDto()
            {
                Id = Odal.Id,
                OrderId = Odal.OrderId,
                IsConcrete = Odal.IsConcrete,
                ConcreteTypeId = Odal.ConcreteTypeId,
                ConcDescId = Odal.ConcDescId,
                DeepId = Odal.DeepId,
                ExposureId = Odal.ExposureId,
                ExtensionId = Odal.ExtensionId,
                IsClay = Odal.IsClay,
                ClayTypeId = Odal.ClayTypeId,
                IsPump = Odal.IsPump,
                VehicleTypeId = Odal.VehicleTypeId,
                Element = Odal.Element,
                Amount = Odal.Amount



            };
        }
        public void AddVehicleType(MaterialDto NewMaterial)
        {
            if (IsExistVehicleType(NewMaterial) == false)
            {
                db.VehicleType.Add(VehicleTypeToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddClay(MaterialDto NewMaterial)
        {
            if (IsExistClay(NewMaterial) == false)
            {
                db.ClayType.Add(ClayToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddConcreteType(MaterialDto NewMaterial)
        {
            if (IsExistConcreteType(NewMaterial) == false)
            {
                db.ConcreteType.Add(ConcreteTypeToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddConcDesc(MaterialDto NewMaterial)
        {
            if (IsExistConcDesc(NewMaterial) == false)
            {
                db.ConcDesc.Add(ConcDescToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddDeep(MaterialDto NewMaterial)
        {
            if (IsExistDeep(NewMaterial) == false)
            {
                db.Deep.Add(DeepToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddExposure(MaterialDto NewMaterial)
        {
            if (IsExistExposure(NewMaterial) == false)
            {
                db.Exposure.Add(ExposureToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public void AddExtension(MaterialDto NewMaterial)
        {
            if (IsExistExtension(NewMaterial) == false)
            {
                db.Extension.Add(ExtensionToDal(NewMaterial));
                db.SaveChanges();
            }
        }
        public bool IsExistVehicleType(MaterialDto material)
        {

            foreach (var o in db.VehicleType)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistClay(MaterialDto material)
        {

            foreach (var o in db.ClayType)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistConcreteType(MaterialDto material)
        {

            foreach (var o in db.ConcreteType)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistConcDesc(MaterialDto material)
        {

            foreach (var o in db.ConcDesc)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistDeep(MaterialDto material)
        {

            foreach (var o in db.Deep)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistExposure(MaterialDto material)
        {

            foreach (var o in db.Exposure)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public bool IsExistExtension(MaterialDto material)
        {

            foreach (var o in db.Extension)
            {
                if (o.Id == material.Id)
                    return true;
            }
            return false;
        }
        public VehicleType VehicleTypeToDal(MaterialDto Mdto)
        {
            return new VehicleType()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public ClayType ClayToDal(MaterialDto Mdto)
        {
            return new ClayType()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public ConcreteType ConcreteTypeToDal(MaterialDto Mdto)
        {
            return new ConcreteType()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public ConcDesc ConcDescToDal(MaterialDto Mdto)
        {
            return new ConcDesc()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public Deep DeepToDal(MaterialDto Mdto)
        {
            return new Deep()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public Exposure ExposureToDal(MaterialDto Mdto)
        {
            return new Exposure()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }
        public Extension ExtensionToDal(MaterialDto Mdto)
        {
            return new Extension()
            {
                Id = Mdto.Id,
                Name = Mdto.Name
            };
        }



        public MaterialDto VehicleTypeToMaterialDto(VehicleType Vtomd)
        {
            return new MaterialDto()
            {
                Id = Vtomd.Id,
                Name = Vtomd.Name
            };
        }
        public MaterialDto ClayToMaterialDto(ClayType Ctomd)
        {
            return new MaterialDto()
            {
                Id = Ctomd.Id,
                Name = Ctomd.Name
            };
        }
        public MaterialDto ConcreteTypeToMaterialDto(ConcreteType Ctomd)
        {
            return new MaterialDto()
            {
                Id = Ctomd.Id,
                Name = Ctomd.Name
            };
        }
        public MaterialDto ConcDescToMaterialDto(ConcDesc Cdtomd)
        {
            return new MaterialDto()
            {
                Id = Cdtomd.Id,
                Name = Cdtomd.Name
            };
        }
        public MaterialDto DeepToMaterialDto(Deep Dtomd)
        {
            return new MaterialDto()
            {
                Id = Dtomd.Id,
                Name = Dtomd.Name
            };
        }
        public MaterialDto ExposureToMaterialDto(Exposure Etomd)
        {
            return new MaterialDto()
            {
                Id = Etomd.Id,
                Name = Etomd.Name
            };
        }
        public MaterialDto ExtensionToMaterialDto(Extension Etomd)
        {
            return new MaterialDto()
            {
                Id = Etomd.Id,
                Name = Etomd.Name
            };
        }
        //public MaterialDto MaterialToDto(VehicleType Mdal)
        //{

        //    return new MaterialDto()
        //    {
        //        Id = Mdal.Id,
        //        Name = Mdal.Name
        //    };
        //}
        //public List<MaterialDto> MaterialsToDto(List<VehicleType> Mdal)
        //{
        //    List<MaterialDto> mDto = new List<MaterialDto>();
        //    foreach (var od in Mdal)
        //    {
        //        mDto.Add(new MaterialDto()
        //        {
        //            Id = od.Id,
        //            Name = od.Name
        //        });

        //    }
        //    return mDto;



        //}
        public List<MaterialDto> GetVehicleType()
        {
            List<MaterialDto> GetVehicleType = new List<MaterialDto>();
            foreach (var v in db.VehicleType)
            {
                GetVehicleType.Add(VehicleTypeToMaterialDto(v));
            }
            return GetVehicleType;
        }
        public List<MaterialDto> GetClay()
        {
            List<MaterialDto> GetClay = new List<MaterialDto>();
            foreach (var c in db.ClayType)
            {
                GetClay.Add(ClayToMaterialDto(c));
            }
            return GetClay;
        }
        public List<MaterialDto> GetConcreteType()
        {
            List<MaterialDto> GetConcrete = new List<MaterialDto>();
            foreach (var v in db.ConcreteType)
            {
                GetConcrete.Add(ConcreteTypeToMaterialDto(v));
            }
            return GetConcrete;
        }
        public List<MaterialDto> GetConcDesc()
        {
            List<MaterialDto> GetConcDesc = new List<MaterialDto>();
            foreach (var c in db.ConcDesc)
            {
                GetConcDesc.Add(ConcDescToMaterialDto(c));
            }
            return GetConcDesc;
        }
        public List<MaterialDto> GetDeep()
        {
            List<MaterialDto> GetDeep = new List<MaterialDto>();
            foreach (var d in db.Deep)
            {
                GetDeep.Add(DeepToMaterialDto(d));
            }
            return GetDeep;
        }
        public List<MaterialDto> GetExposure()
        {
            List<MaterialDto> GetExposure = new List<MaterialDto>();
            foreach (var e in db.Exposure)
            {
                GetExposure.Add(ExposureToMaterialDto(e));
            }
            return GetExposure;
        }
        public List<MaterialDto> GetExtension()
        {
            List<MaterialDto> GetExtension = new List<MaterialDto>();
            foreach (var e in db.Extension)
            {
                GetExtension.Add(ExtensionToMaterialDto(e));
            }
            return GetExtension;
        }

    }
}
