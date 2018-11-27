using WebShop_Model.EF;

namespace WebShop_Model.Dao
{
   public class OrderDetailDao
    {
        WebShop_Model_DB db = null;
        public OrderDetailDao()
        {
            db = new WebShop_Model_DB();

        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
