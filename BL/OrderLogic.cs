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
        public List<OrderDTO> GetOrdersByCustomerId(int Id)
        {
            OrderDTO o;
            List<Order> orders = new List<Order>();
            List<MaterialDTO> AllMaterials = new List<MaterialDTO>();
            List<OrderDTO> CustOrders = new List<OrderDTO>();

            //test

            orders= db.Orders.ToList();
            //CustOrders = db.OrderDTO.ToList();
           // AllMaterials = db.MaterialDTO.ToList();
            var sql = @"SELECT * FROM dbo.OrderDTO WHERE ID > {0} ";
            var peopleViaCommand =
             db.Database.SqlQuery<OrderDTO>(
               sql, 0);
            CustOrders= peopleViaCommand.ToList();
            //look for customer order
            db.Orders.Where(o1 => o1.CustomerId == Id).ToList().ForEach(x =>
            {
            db.MaterialDTO.ToList().ForEach(m => { if (x.Id == m.OrderId)
                    AllMaterials.Add(m);
                    });
                o=db.OrderDTO.FirstOrDefault(or => x.Id == or.Id);
                if (o != null) { 
                o.MaterialOrderL = AllMaterials;
                CustOrders.Add(o);
                }
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
            NewOrder.OrderDate = DateTime.UtcNow.ToLocalTime();
            NewOrder.IsApproved = false;
            NewOrder.IsDone = false;
            NewOrder.MaterialOrderL.ForEach(x =>
            {
                x.StatusMaterialId = 1;
            });
            if (IsExist(NewOrder) == false)
            {
                db.Orders.Add(OrderToDal(NewOrder));
                db.SaveChanges();
            }
        }


        public void DeleteOrder(int id)
        {
            db.MaterialTypeOrders.ToList().ForEach(x =>
            {
                if (x.OrderId == id) db.MaterialTypeOrders.Remove(x);
            });
            db.Orders.Remove(db.Orders.FirstOrDefault(o => o.Id == id));
            db.SaveChanges();
        }

        public void UpdateOrder(OrderDto UpOrder)
        {
            //storing the existing order in a tmp variable that referenced to the same one in DB
            Order Ezer = db.Orders.FirstOrDefault(o => o.Id == UpOrder.Id);

       
            if (Ezer != null)
            {//updating the new values
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
                //security check that there is actually materials to the order
                if (UpOrder.MaterialOrderL != null)
                {
                    Ezer.MaterialTypeOrder = new List<MaterialTypeOrder>();

                    //adding materials of order from db
                    db.MaterialTypeOrders.ToList().ForEach(x =>
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
                                if(x.PipeLength!=null)
                                m.PipeLength = x.PipeLength;
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
                if (o.Id==order.Id)
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
                        PipeLength=x.PipeLength,

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
                        PipeLength = x.PipeLength,

                });
                });
            }
            return order;
        }

        public List<MaterialDto> getAllMaterials()
        {
            List<MaterialDto> MaterialL = new List<MaterialDto>();
            db.Materials.ToList().ForEach(x =>
            {
                MaterialL.Add(MaterialToDto(x));
            });
            return MaterialL;
        }

        public List<MaterialDto> getMaterialsByCategoryName(string name)
        {
            MaterialCategory mCat = db.MaterialCategorys.FirstOrDefault(x => x.Name.Equals(name));
            List<MaterialDto> MaterialL = new List<MaterialDto>();
            foreach (Material m in db.Materials)
            {
                if (m.MaterialCategoryId == mCat.Id)
                    MaterialL.Add(MaterialToDto(m));
            }
            return MaterialL;
        }

        public MaterialDto getMaterialbyId(int id)
        {
            return MaterialToDto(db.Materials.FirstOrDefault(x => x.Id == id));
        }

        public MaterialDto getMaterialIdByName(string name)
        {
            return MaterialToDto(db.Materials.FirstOrDefault(x => x.Name.Equals(name)));
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
            db.Materials.Remove(db.Materials.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void addOrder(MaterialDto m)
        {
            if (IsExist(m) == false)
            {
                db.Materials.Add(MaterialToDal(m));
                db.SaveChanges();
            }

        }

        public void UpdateMaterial(MaterialDto m)
        {
            Material Ezer = db.Materials.FirstOrDefault(x => x.Id == m.Id);
            if (Ezer != null)
            {
                Ezer.MaterialCategoryId = m.MaterialCategoryId;
                Ezer.Name = m.Name;
                db.SaveChanges();
            }
        }

        bool IsExist(MaterialDto m)
        {
            foreach (Material mat in db.Materials)
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
            foreach (MaterialCategory mCat in db.MaterialCategorys.ToList())
                MaterialCatL.Add(MaterialCategorytoDto(mCat));
            return MaterialCatL;

        }

        public void deleteMaterialCategory(int id)
        {
            db.MaterialCategorys.Remove(db.MaterialCategorys.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }

        public void UpdateMaterialCategory(MaterialCategoryDto mCat)
        {
            MaterialCategory Ezer = db.MaterialCategorys.FirstOrDefault(x => x.Id == mCat.Id);
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
                db.MaterialCategorys.Add(MaterialCategoryDtoToDal(mCat));
                db.SaveChanges();
            }

        }

        bool IsExist(MaterialCategoryDto mCat)
        {
            foreach (MaterialCategory m in db.MaterialCategorys)
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
