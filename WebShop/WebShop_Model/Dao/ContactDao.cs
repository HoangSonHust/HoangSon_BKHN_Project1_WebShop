using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Model.EF;
namespace WebShop_Model.Dao
{
    public class ContactDao
    {
        WebShop_Model_DB db = null;
        public ContactDao()
        {
            db = new WebShop_Model_DB();

        }
        //lấy chi tiết post
        public Contact TakeContent(int ID)
        {
            return db.Contacts.Find(ID);

        }
    }
}
