using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class NewsDao
    {
        WebShop_Model_DB db = null;
        public NewsDao()
        {
            db = new WebShop_Model_DB();
        }
        //lấy tất cả các post để xem reviews
        public List<News> TakePost()
        {
            return db.News.Where(x => x.Status == true).ToList();

        }
        public News TakeContent(int ID)
        {
            return db.News.Find(ID);

        }
    }
}
