using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebShop.Areas.User.Models;
using WebShop_Model.Dao;
using WebShop_Model.EF;
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

        [HttpGet]
        public ActionResult Payment()
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

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var productDao = new ProductDao();
            var cart = (List<CartItem>)Session[CartSession];
            if (shipName == null)
            {
                return Redirect("/User/Cart/NoSuccess/2");
            }
            if (mobile == null)
            {
                return Redirect("/User/Cart/NoSuccess/3");
            }
            if (address == null)
            {
                return Redirect("/User/Cart/NoSuccess/4");
            }
            if (email == null)
            {
                return Redirect("/User/Cart/NoSuccess/5");
            }
            foreach(var item in cart)
            {
                if (productDao.TakeProductQuantity(item.Product.ID) < item.Quantity)
                {
                    return Redirect("/User/Cart/NoSuccess/1");
                }
              
            }

            try
            {
                var order = new Order();
                order.CreatedDate = DateTime.Now;
                order.CustomerAddress = address;
                order.CustomerTel = mobile;
                order.CustomerName = shipName;
                order.CustomerEmail = email;


                var id = new OrderDao().Insert(order);
               
                var detailDao = new OrderDetailDao();
                
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.PromotionPrice * item.Quantity;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    productDao.DecreaseProductQuantity(item.Product.ID, item.Quantity);


                }
                // string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

                //     content = content.Replace("{{CustomerName}}", shipName);
                //     content = content.Replace("{{Phone}}", mobile);
                //     content = content.Replace("{{Email}}", email);
                //     content = content.Replace("{{Address}}", address);
                //    content = content.Replace("{{Total}}", total.ToString("N0"));
                //   var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                // new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                // new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/User/Cart/NoSuccess");
            }
            Session[CartSession] = null;
            return Redirect("/User/Cart/Success");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult NoSuccess(int ID)
        {
            if (ID == 1)
            {
                string error = "không thể mua hàng vì số hàng bạn mua quá số lượng chúng tôi có";
                ViewBag.error = error;
            }
            if (ID == 2)
            {
                string error = "không thể mua hàng vì bạn chưa nhập tên của mình";
                ViewBag.error = error;
            }
            if (ID == 3)
            {
                string error = "không thể mua hàng vì bạn chưa nhập số điện thoại";
                ViewBag.error = error;
            }
            if (ID == 4)
            {
                string error = "không thể mua hàng vì bạn chưa nhập địa chỉ";
                ViewBag.error = error;

            }
            if (ID == 5)
            {
                string error = "không thể mua hàng vì bạn chưa nhập email";
                ViewBag.error = error;
            }

            return View();
        }
        
    }
}
