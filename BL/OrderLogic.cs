using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderLogic : BaseLogic
    {
        private object Odto;

        public OrderDto GetOrderById(int id)
        {
            return (OrderToDto(db.Orders.FirstOrDefault(o => o.Id == id)));
        }
        public List<OrderDto> GetOrdersByCustomerId(int Id)
        {
            List<Order> AllOrders = new List<Order>();
            List<OrderDto> CustOrders = new List<OrderDto>();
            AllOrders = db.Orders.Where(o1 => o1.CustomerId == Id).ToList();
            foreach(Order o in AllOrders)
            {
                CustOrders.Add(OrderToDto(o));
            }
            return CustOrders;
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
            foreach(MaterialTypeOrder m in db.MaterialTypeOrder)
            {
                if (m.OrderId == id)
                    db.MaterialTypeOrder.Remove(m);
            }
            db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();
        }

        public void UpdateOrder(OrderDto UpOrder)
        {
            Order Ezer = db.Orders.FirstOrDefault(o => o.Id == UpOrder.Id);
            List<MaterialTypeOrder> EzerL = new List<MaterialTypeOrder>();

            if (Ezer != null) { 
            Ezer.CustomerId = UpOrder.CustomerId;
            Ezer.SiteAdress = UpOrder.SiteAdress;
            Ezer.OrderDate = UpOrder.OrderDate;
            Ezer.OrderDueDate = UpOrder.OrderDueDate;
            Ezer.StartTime = UpOrder.StartTime;
            Ezer.EndTime = UpOrder.EndTime;
            Ezer.IsApproved = UpOrder.IsApproved;
            Ezer.IsDone = UpOrder.IsDone;
            Ezer.ManagerComment = UpOrder.ManagerComment;
            Ezer.Comment = UpOrder.Comment;
            Ezer.ConcreteTest = UpOrder.ConcreteTest;

            foreach(MaterialTypeOrderDto mDto in UpOrder.MaterialTypeOrderDtoL)
            {   
                foreach(MaterialTypeOrder mDal in db.MaterialTypeOrder)
                  if(mDto.OrderId==mDal.OrderId)
                    {

                        mDal.Element = mDto.Element;
                        mDal.Amount = mDto.Amount;
                        mDal.StatusMaterialId = mDto.StatusMaterialId;
                        mDal.MaterialId = mDto.MaterialId;
                    }
            }
            db.SaveChanges();
            }
        }

        public List<OrderDto> getAllOrders()
        {
            List<OrderDto> AllOrderL = new List<OrderDto>();
             foreach(Order o in db.Orders)
            {
                AllOrderL.Add(OrderToDto(o));
            }
         
            return AllOrderL;
        }

        public bool IsExist(OrderDto order)
        {

            foreach (var o in db.Orders)
            {
                if (o.CustomerId == order.CustomerId && o.OrderDate == order.OrderDate && o.SiteAdress == o.SiteAdress)
                    return true;
            }
            return false;
        }
        public Order OrderToDal(OrderDto Odto)
        {
            Order order = new Order()
            {
                CustomerId = Odto.CustomerId,
                SiteAdress = Odto.SiteAdress,
                OrderDate = Odto.OrderDate,
                OrderDueDate = Odto.OrderDueDate,
                StartTime = Odto.StartTime,
                EndTime = Odto.EndTime,
                IsApproved = Odto.IsApproved,
                IsDone = Odto.IsDone,
                ManagerComment = Odto.ManagerComment,
                Comment = Odto.Comment,
                ConcreteTest = Odto.ConcreteTest,
            };
            Odto.MaterialTypeOrderDtoL.ForEach(x =>
            {

                order.MaterialTypeOrder.Add(new MaterialTypeOrder()
                {
                    Element = x.Element,
                    Amount = x.Amount,
                    StatusMaterialId = 0,
                    MaterialId = x.MaterialId,

                });
            });
            return order;
        }

        public OrderDto OrderToDto(Order Odal)
        {

            OrderDto order = new OrderDto()
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
                ManagerComment = Odal.ManagerComment,
                Comment = Odal.Comment,
                ConcreteTest = Odal.ConcreteTest,
            };
            foreach (MaterialTypeOrder m in db.MaterialTypeOrder)
            {
                if (m.OrderId == order.Id)
                {
                    order.MaterialTypeOrderDtoL.Add(MaterialTypeOrderToDto(m));
                }
            }
            return order;
        }

        public List<MaterialDto> getAllMaterials()
        {
            List<MaterialDto> MaterialL = new List<MaterialDto>();
            foreach (Material m in db.Material)
                MaterialL.Add(MaterialToDto(m));
            return MaterialL;
        }

        public List<MaterialDto> getMaterialsByCategoryName(string name)
        {
            MaterialCategory mCat = db.MaterialCategory.FirstOrDefault(x => x.Name.Equals(name));
            List<MaterialDto> MaterialL = new List<MaterialDto>();
            foreach (Material m in db.Material)
            {
                if (m.MaterialCategoryId == mCat.Id)
                    MaterialL.Add(MaterialToDto(m));
            }
            return MaterialL;
        }

        public MaterialDto getMaterialbyId(int id)
        {
            return MaterialToDto(db.Material.FirstOrDefault(x => x.Id == id));
        }

        public MaterialDto getMaterialIdByName(string name)
        {
            return MaterialToDto(db.Material.FirstOrDefault(x => x.Name.Equals(name)));
        }
        public Material MaterialToDal(MaterialDto mDto)
        {
            return new Material()
            {
                Id = mDto.Id,
                MaterialCategoryId = mDto.MaterialCategoryId,
                Name = mDto.Name,
            };

        }

        public void deleteMaterial(MaterialDto m)
        {
            db.Material.Remove(db.Material.FirstOrDefault(x => x.Id == m.Id));
            db.SaveChanges();
        }

        public void addOrder(MaterialDto m)
        { 
            if(IsExist(m)==false)
            {
                db.Material.Add(MaterialToDal(m));
                db.SaveChanges();
            }
            
        }

        public void UpdateMaterial(MaterialDto m)
        {
            Material Ezer = db.Material.FirstOrDefault(x => x.Id == m.Id);
            if (Ezer != null)
            {
                Ezer.MaterialCategoryId = m.MaterialCategoryId;
                Ezer.Name = m.Name;
                db.SaveChanges();
            }
        }

        bool IsExist(MaterialDto m)
        {
            foreach(Material mat in db.Material)
            {
                if (m.MaterialCategoryId == mat.MaterialCategoryId && m.Name.Equals(mat.MaterialCategoryId))
                    return true;

            }
               return false;

        }

        public MaterialDto MaterialToDto(Material mDal)
        {
            return new MaterialDto()
            {
                Id = mDal.Id,
                MaterialCategoryId = mDal.MaterialCategoryId,
                Name = mDal.Name,
            };
        }

        public MaterialTypeOrderDto MaterialTypeOrderToDto(MaterialTypeOrder Odal)
        {
            return new MaterialTypeOrderDto()
            {
                Id = Odal.Id,
                OrderId = Odal.OrderId,
                Element = Odal.Element,
                Amount = Odal.Amount,
                StatusMaterialId = Odal.StatusMaterialId,
                MaterialId = Odal.MaterialId,

            };
        }
        public MaterialTypeOrder MaterialTypeOrderToDal(MaterialTypeOrderDto Odto)
        {
            return new MaterialTypeOrder()
            {
                //?
                OrderId = Odto.OrderId,
                Element = Odto.Element,
                Amount = Odto.Amount,
                StatusMaterialId = Odto.StatusMaterialId,
                MaterialId = Odto.MaterialId,

            };
        }

        public List<MaterialCategoryDto> getCategories()
        {
            List<MaterialCategoryDto> MaterialCatL = new List<MaterialCategoryDto>();
            foreach(MaterialCategory mCat in db.MaterialCategory)
                MaterialCatL.Add(MaterialCategorytoDto(mCat));
            return MaterialCatL;

        }

        public void deleteMaterialCategory(MaterialCategoryDto mCat)
        {
            db.MaterialCategory.Remove(db.MaterialCategory.FirstOrDefault(x => x.Id == mCat.Id));
            db.SaveChanges();
        }

        public void UpdateMaterialCategory(MaterialCategoryDto mCat)
        {
            MaterialCategory Ezer = db.MaterialCategory.FirstOrDefault(x => x.Id == mCat.Id);
            if (Ezer != null)
            {
                Ezer.Name = mCat.Name;
                db.SaveChanges();
            }
        }

        public void addMaterialCategory(MaterialCategoryDto mCat)
        {
            if (IsExist(mCat) == false)
            {
                db.MaterialCategory.Add(MaterialCategoryDtoToDal(mCat));
                db.SaveChanges();
            }

        }

        bool IsExist(MaterialCategoryDto mCat)
        {
            foreach(MaterialCategory m in db.MaterialCategory)
            {
                if (m.Name.Equals(mCat.Name))
                    return true;
            }
            return false;
        }

        public MaterialCategory MaterialCategoryDtoToDal(MaterialCategoryDto mCatDto)
        {
            return new MaterialCategory(){
                Id=mCatDto.Id,
                Name=mCatDto.Name,
            };

        }

        public MaterialCategoryDto MaterialCategorytoDto(MaterialCategory mCatDal)
        {
            return new MaterialCategoryDto()
            {
                Id = mCatDal.Id,
                Name=mCatDal.Name,
            };
        }


        //public MaterialTypeOrderDto MaterialTypeOrderDto(MaterialTypeOrder Odal)
        //{

        //    return new MaterialTypeOrderDto()
        //    {
        //        Id = Odal.Id,
        //        IsConcrete = Odal.IsConcrete,
        //        ConcreteTypeId = Odal.ConcreteTypeId,
        //        ConcDescId = Odal.ConcDescId,
        //        DeepId = Odal.DeepId,
        //        ExposureId = Odal.ExposureId,
        //        ExtensionId = Odal.ExtensionId,
        //        IsClay = Odal.IsClay,
        //        ClayTypeId = Odal.ClayTypeId,
        //        IsPump = Odal.IsPump,
        //        VehicleTypeId = Odal.VehicleTypeId,
        //        Element = Odal.Element,
        //        Amount = Odal.Amount



        //    };
        //}
        //public void AddVehicleType(MaterialDto NewMaterial)
        //{
        //    if (IsExistVehicleType(NewMaterial) == false)
        //    {
        //        db.VehicleType.Add(VehicleTypeToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddClay(MaterialDto NewMaterial)
        //{
        //    if (IsExistClay(NewMaterial) == false)
        //    {
        //        db.ClayType.Add(ClayToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddConcreteType(MaterialDto NewMaterial)
        //{
        //    if (IsExistConcreteType(NewMaterial) == false)
        //    {
        //        db.ConcreteType.Add(ConcreteTypeToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddConcDesc(MaterialDto NewMaterial)
        //{
        //    if (IsExistConcDesc(NewMaterial) == false)
        //    {
        //        db.ConcDesc.Add(ConcDescToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddDeep(MaterialDto NewMaterial)
        //{
        //    if (IsExistDeep(NewMaterial) == false)
        //    {
        //        db.Deep.Add(DeepToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddExposure(MaterialDto NewMaterial)
        //{
        //    if (IsExistExposure(NewMaterial) == false)
        //    {
        //        db.Exposure.Add(ExposureToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public void AddExtension(MaterialDto NewMaterial)
        //{
        //    if (IsExistExtension(NewMaterial) == false)
        //    {
        //        db.Extension.Add(ExtensionToDal(NewMaterial));
        //        db.SaveChanges();
        //    }
        //}
        //public bool IsExistVehicleType(MaterialDto material)
        //{

        //    foreach (var o in db.VehicleType)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistClay(MaterialDto material)
        //{

        //    foreach (var o in db.ClayType)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistConcreteType(MaterialDto material)
        //{

        //    foreach (var o in db.ConcreteType)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistConcDesc(MaterialDto material)
        //{

        //    foreach (var o in db.ConcDesc)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistDeep(MaterialDto material)
        //{

        //    foreach (var o in db.Deep)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistExposure(MaterialDto material)
        //{

        //    foreach (var o in db.Exposure)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool IsExistExtension(MaterialDto material)
        //{

        //    foreach (var o in db.Extension)
        //    {
        //        if (o.Id == material.Id)
        //            return true;
        //    }
        //    return false;
        //}
        //public Material VehicleTypeToDal(MaterialDto Mdto)
        //{
        //    return new VehicleType()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public ClayType ClayToDal(MaterialDto Mdto)
        //{
        //    return new ClayType()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public ConcreteType ConcreteTypeToDal(MaterialDto Mdto)
        //{
        //    return new ConcreteType()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public ConcDesc ConcDescToDal(MaterialDto Mdto)
        //{
        //    return new ConcDesc()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public Deep DeepToDal(MaterialDto Mdto)
        //{
        //    return new Deep()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public Exposure ExposureToDal(MaterialDto Mdto)
        //{
        //    return new Exposure()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}
        //public Extension ExtensionToDal(MaterialDto Mdto)
        //{
        //    return new Extension()
        //    {
        //        Id = Mdto.Id,
        //        Name = Mdto.Name
        //    };
        //}



        //public MaterialDto VehicleTypeToMaterialDto(VehicleType Vtomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Vtomd.Id,
        //        Name = Vtomd.Name
        //    };
        //}
        //public MaterialDto ClayToMaterialDto(ClayType Ctomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Ctomd.Id,
        //        Name = Ctomd.Name
        //    };
        //}
        //public MaterialDto ConcreteTypeToMaterialDto(ConcreteType Ctomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Ctomd.Id,
        //        Name = Ctomd.Name
        //    };
        //}
        //public MaterialDto ConcDescToMaterialDto(ConcDesc Cdtomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Cdtomd.Id,
        //        Name = Cdtomd.Name
        //    };
        //}
        //public MaterialDto DeepToMaterialDto(Deep Dtomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Dtomd.Id,
        //        Name = Dtomd.Name
        //    };
        //}
        //public MaterialDto ExposureToMaterialDto(Exposure Etomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Etomd.Id,
        //        Name = Etomd.Name
        //    };
        //}
        //public MaterialDto ExtensionToMaterialDto(Extension Etomd)
        //{
        //    return new MaterialDto()
        //    {
        //        Id = Etomd.Id,
        //        Name = Etomd.Name
        //    };
        //}
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
        //public List<MaterialDto> GetVehicleType()
        //{
        //    List<MaterialDto> GetVehicleType = new List<MaterialDto>();
        //    foreach (var v in db.VehicleType)
        //    {
        //        GetVehicleType.Add(VehicleTypeToMaterialDto(v));
        //    }
        //    return GetVehicleType;
        //}
        //public List<MaterialDto> GetClay()
        //{
        //    List<MaterialDto> GetClay = new List<MaterialDto>();
        //    foreach (var c in db.ClayType)
        //    {
        //        GetClay.Add(ClayToMaterialDto(c));
        //    }
        //    return GetClay;
        //}
        //public List<MaterialDto> GetConcreteType()
        //{
        //    List<MaterialDto> GetConcrete = new List<MaterialDto>();
        //    foreach (var v in db.ConcreteType)
        //    {
        //        GetConcrete.Add(ConcreteTypeToMaterialDto(v));
        //    }
        //    return GetConcrete;
        //}
        //public List<MaterialDto> GetConcDesc()
        //{
        //    List<MaterialDto> GetConcDesc = new List<MaterialDto>();
        //    foreach (var c in db.ConcDesc)
        //    {
        //        GetConcDesc.Add(ConcDescToMaterialDto(c));
        //    }
        //    return GetConcDesc;
        //}
        //public List<MaterialDto> GetDeep()
        //{
        //    List<MaterialDto> GetDeep = new List<MaterialDto>();
        //    foreach (var d in db.Deep)
        //    {
        //        GetDeep.Add(DeepToMaterialDto(d));
        //    }
        //    return GetDeep;
        //}
        //public List<MaterialDto> GetExposure()
        //{
        //    List<MaterialDto> GetExposure = new List<MaterialDto>();
        //    foreach (var e in db.Exposure)
        //    {
        //        GetExposure.Add(ExposureToMaterialDto(e));
        //    }
        //    return GetExposure;
        //}
        //public List<MaterialDto> GetExtension()
        //{
        //    List<MaterialDto> GetExtension = new List<MaterialDto>();
        //    foreach (var e in db.Extension)
        //    {
        //        GetExtension.Add(ExtensionToMaterialDto(e));
        //    }
        //    return GetExtension;
        //}

    }
}
