using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebShop.Areas.User.Models;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class CartController : Controller
    {
        //biến session để lưu các kết quả
        private const string CartSession = "CartSession";
        // GET: User/CartItem
        public ActionResult Cart()
        {
            //lấy giá trị biến session cho vào cart
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            
            ViewBag.List = list;

            return View(list);
        }
        
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }


        // phương thức để thêm sản phẩm vào giỏ
        public ActionResult AddItem(int productID, int quantity)
        {
            // tạo 1 đối tượng product khi ta truyền ID vào
            var product = new ProductDao().TakeSingleProductID(productID);
          
            //lấy giá trị biến session truyền vào cart
            var cart = Session[CartSession];
            //nếu cart ko rỗng
            if (cart != null)
            {

                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity = item.Quantity + quantity;
                        }
                    }
                }
                else
                {
                    // tạo mới đối tượng sản phẩm trong cart Item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                  
                    list.Add(item);
                }
                //gán vào session
                Session[CartSession] = list;

            }
            //nếu có sản phẩm trong rồi
            else
            {
                // tạo mới đối tượng sản phẩm trong cart Item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
              
                var list = new List<CartItem>();
                list.Add(item);

                //gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Cart");
        }


        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}