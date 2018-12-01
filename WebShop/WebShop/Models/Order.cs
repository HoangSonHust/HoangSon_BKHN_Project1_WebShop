namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        WebShopDbContext db = null;
        public Order()
        {
            db = new WebShopDbContext();

        }
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerTel { get; set; }

        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public bool Status { get; set; }
    }
}
