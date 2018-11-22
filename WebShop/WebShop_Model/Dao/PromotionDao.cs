using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class PromotionDao
    {
        WebShop_Model_DB db = null;
        public PromotionDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy tất cả các post để xem reviews
        public List<Promotion> TakePost()
        {
            return db.Promotions.Where(x => x.Status == true).ToList();

        }
        public Promotion TakeContent(int ID)
        {
            return db.Promotions.Find(ID);

        }
    }
}
