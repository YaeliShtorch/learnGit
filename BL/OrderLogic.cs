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

        public void UpdateOrder(OrderDto UpOrder)
        {
            Order Ezer = db.Orders.FirstOrDefault(o => o.Id == UpOrder.Id);

            Ezer.OrderDate = UpOrder.OrderDate;
            Ezer.CustomerId = UpOrder.CustomerId;
            Ezer.ConcreteCheck = UpOrder.ConcreteCheck;
            Ezer.Element = UpOrder.Element;
            Ezer.EndTime = UpOrder.EndTime;
            Ezer.IsIssue = UpOrder.IsIssue;
            Ezer.PumpNeeded = UpOrder.PumpNeeded;
            Ezer.PumpId = UpOrder.PumpId;
            Ezer.SiteAdress = UpOrder.SiteAdress;
            Ezer.StartTime = UpOrder.StartTime;
            Ezer.Status = UpOrder.Status;
            Ezer.Comments = UpOrder.Comments;
            db.SaveChanges();


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
                OrderDate = Odto.OrderDate,
                CustomerId = Odto.CustomerId,
                ConcreteCheck = Odto.ConcreteCheck,
                Element = Odto.Element,
                EndTime = Odto.EndTime,
                IsIssue = Odto.IsIssue,
                PumpNeeded = Odto.PumpNeeded,
                PumpId = Odto.PumpId,
                SiteAdress = Odto.SiteAdress,
                StartTime = Odto.StartTime,
                Status = Odto.Status,
                Comments=Odto.Comments
            };
        }
        public OrderDto OrderToDto(Order Odal)
        {

            return new OrderDto()
            {
                Id = Odal.Id,
                OrderDate = Odal.OrderDate,
                CustomerId = Odal.CustomerId,
                ConcreteCheck = Odal.ConcreteCheck,
                Element=Odal.Element,
                EndTime=Odal.EndTime,
                IsIssue=Odal.IsIssue,
                PumpNeeded=Odal.PumpNeeded,
                PumpId=Odal.PumpId,
                SiteAdress=Odal.SiteAdress,
                StartTime=Odal.StartTime,
                Status=Odal.Status,
                Comments=Odal.Comments
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
                    OrderDate = od.OrderDate,
                    CustomerId = od.CustomerId,
                    ConcreteCheck = od.ConcreteCheck,
                    Element = od.Element,
                    EndTime = od.EndTime,
                    IsIssue = od.IsIssue,
                    PumpNeeded = od.PumpNeeded,
                    PumpId = od.PumpId,
                    SiteAdress = od.SiteAdress,
                    StartTime = od.StartTime,
                    Status = od.Status,
                    Comments=od.Comments
                });

            }
            return oDto;



        }
    }
}
