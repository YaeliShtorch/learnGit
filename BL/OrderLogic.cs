﻿using DAL;
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
            db.Orders.Where(o1 => o1.CustomerId == Id).ToList().ForEach(x =>
            {
                CustOrders.Add(OrderToDto(x));
            });
            return CustOrders;
        }
        //public List<OrderDto> GetOrders()
        //{
        //    List<OrderDto> AllOrders = new List<OrderDto>();
        //    db.Orders.ToList().ForEach(x =>
        //    {
        //        AllOrders.Add(OrderToDto(x));
        //    });
        //    return AllOrders;
        //}

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
            db.MaterialTypeOrder.ToList().ForEach(x =>
            {
                if (x.OrderId == id) db.MaterialTypeOrder.Remove(x);
            });
            db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();
        }

        public void UpdateOrder(OrderDto UpOrder)
        {
            Order Ezer = db.Orders.FirstOrDefault(o => o.Id == UpOrder.Id);

            if (Ezer != null)
            {
                Ezer.CustomerId = UpOrder.CustomerId;
                Ezer.SiteAdress = UpOrder.SiteAdress;
                Ezer.OrderDate = UpOrder.OrderDate;
                Ezer.OrderDueDate = UpOrder.OrderDueDate;
                Ezer.StartTime = UpOrder.StartTime.TimeOfDay;
                Ezer.EndTime = UpOrder.EndTime.TimeOfDay;
                Ezer.IsApproved = UpOrder.IsApproved;
                Ezer.IsDone = UpOrder.IsDone;
                Ezer.ManagerComment = UpOrder.ManagerComment;
                Ezer.Comment = UpOrder.Comment;
                Ezer.ConcreteTest = UpOrder.ConcreteTest;
                if (UpOrder.MaterialOrderL != null)
                {
                    Ezer.MaterialTypeOrder = new List<MaterialTypeOrder>();

                    //adding materials of order from db
                    db.MaterialTypeOrder.ToList().ForEach(x =>
                    {
                        if (x.OrderId == UpOrder.Id) Ezer.MaterialTypeOrder.Add(x);
                    });

                    //updating dal list from dto list
                    UpOrder.MaterialOrderL.ForEach(x =>
                    {
                        Ezer.MaterialTypeOrder.ToList().ForEach(m =>
                        {
                            if (m.Id == x.Id)
                            {
                                m.Amount = x.Amount;
                                m.StatusMaterialId = x.StatusMaterialId;
                                m.MaterialId = x.MaterialId;
                            }
                        });

                    });
                    db.SaveChanges();
                }          

            }
        }



        public List<OrderDto> getAllOrders()
        {
            List<OrderDto> AllOrderL = new List<OrderDto>();
            foreach (Order o in db.Orders)
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
                StartTime = Odto.StartTime.TimeOfDay,
                EndTime = Odto.EndTime.TimeOfDay,
                IsApproved = Odto.IsApproved,
                IsDone = Odto.IsDone,
                ManagerComment = Odto.ManagerComment,
                Comment = Odto.Comment,
                ConcreteTest = Odto.ConcreteTest,
            };
            if (Odto.MaterialOrderL != null)
            {
                order.MaterialTypeOrder = new List<MaterialTypeOrder>();
                Odto.MaterialOrderL.ForEach(x =>
                {

                    order.MaterialTypeOrder.Add(new MaterialTypeOrder()
                    {
                        Element = x.Element,
                        Amount = x.Amount,
                        StatusMaterialId = x.StatusMaterialId,
                        MaterialId = x.MaterialId,

                    });
                });
            }
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
                StartTime = Odal.OrderDueDate + Odal.StartTime,
                EndTime = Odal.OrderDueDate + Odal.EndTime,
                IsApproved = Odal.IsApproved,
                IsDone = Odal.IsDone,
                ManagerComment = Odal.ManagerComment,
                Comment = Odal.Comment,
                ConcreteTest = Odal.ConcreteTest,
            };

            if (Odal.MaterialTypeOrder != null)
            {
                order.MaterialOrderL = new List<MaterialTypeOrderDto>();
                Odal.MaterialTypeOrder.ToList().ForEach(x =>
                {

                    order.MaterialOrderL.Add(new MaterialTypeOrderDto()
                    {
                        Element = x.Element,
                        Amount = x.Amount,
                        StatusMaterialId = x.StatusMaterialId,
                        MaterialId = x.MaterialId,

                    });
                });
            }
            return order;
        }

        public List<MaterialDto> getAllMaterials()
        {
            List<MaterialDto> MaterialL = new List<MaterialDto>();
            db.Material.ToList().ForEach(x =>
            {
                MaterialL.Add(MaterialToDto(x));
            });
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

        public void deleteMaterial(int id)
        {
            db.Material.Remove(db.Material.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void addOrder(MaterialDto m)
        {
            if (IsExist(m) == false)
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
            foreach (Material mat in db.Material)
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
                PipeLength = mDal.PipeLength,
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
            foreach (MaterialCategory mCat in db.MaterialCategory.ToList())
                MaterialCatL.Add(MaterialCategorytoDto(mCat));
            return MaterialCatL;

        }

        public void deleteMaterialCategory(int id)
        {
            db.MaterialCategory.Remove(db.MaterialCategory.FirstOrDefault(x => x.Id == id));
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
            foreach (MaterialCategory m in db.MaterialCategory)
            {
                if (m.Name.Equals(mCat.Name))
                    return true;
            }
            return false;
        }

        public MaterialCategory MaterialCategoryDtoToDal(MaterialCategoryDto mCatDto)
        {
            return new MaterialCategory()
            {
                Id = mCatDto.Id,
                Name = mCatDto.Name,
            };

        }

        public MaterialCategoryDto MaterialCategorytoDto(MaterialCategory mCatDal)
        {
            return new MaterialCategoryDto()
            {
                Id = mCatDal.Id,
                Name = mCatDal.Name,
            };

        }
    }
}
