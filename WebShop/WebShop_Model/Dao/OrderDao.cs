using System.Collections.Generic;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class OrderDao
    {
        WebShop_Model_DB db = null;
        public OrderDao()
        {
            db = new WebShop_Model_DB();

        }
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
