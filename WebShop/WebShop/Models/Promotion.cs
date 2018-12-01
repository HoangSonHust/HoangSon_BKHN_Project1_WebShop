namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Promotion")]
    public partial class Promotion
    {
        WebShopDbContext db = null;
        public Promotion()
        {
            db = new WebShopDbContext();
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
        public int ID { get; set; }

        [StringLength(50)]
        public string PromotionName { get; set; }

        public string Content { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        public string Detail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public bool Status { get; set; }
    }
}
