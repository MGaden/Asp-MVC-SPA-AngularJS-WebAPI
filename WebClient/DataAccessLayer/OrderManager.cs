using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class OrderManager
    {
        OrderEntities entity;
        public OrderManager()
        {
            entity = new OrderEntities();
        }

        public ICollection<Order> GetOrders()
        {
            return entity.Orders.ToList();
        }

        public Order GetOrder(int orderID)
        {
            return entity.Orders.FirstOrDefault(r => r.ID == orderID);
        }

        public bool AddOrder(Order order)
        {
            try
            {
                entity.Orders.Add(order);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool UpdateOrder(Order order)
        {
            try
            {
                Order oldorder = entity.Orders.FirstOrDefault(r => r.ID == order.ID);
                if (oldorder != null)
                {
                    oldorder.Price = order.Price;
                    oldorder.Name = order.Name;
                    entity.Entry(oldorder).State = System.Data.Entity.EntityState.Modified;
                    entity.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteOrder(int orderID)
        {
            try
            {
                Order oldorder = entity.Orders.FirstOrDefault(r => r.ID == orderID);
                if (oldorder != null)
                {
                    entity.Orders.Remove(oldorder);
                    entity.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public ICollection<Order> GetFilteredData(string Name, double Price)
        {
            try
            {
                if (Name != null && Name != "" && Price != null && Price > 0)
                {
                   return entity.Orders.Where(r => r.Name == Name && r.Price == Price).ToList();
                }
                else if (Name != null && Name != "")
                {
                    return entity.Orders.Where(r => r.Name == Name).ToList();
                }
                else if (Price != null && Price > 0)
                {
                    return entity.Orders.Where(r => r.Price == Price).ToList();
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
