namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public About()
        {
            db = new WebShopDbContext();

        }
        public About TakeContent(int ID)
        {
            return db.Abouts.Find(ID);

        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool Status { get; set; }

        WebShopDbContext db = null;
       
        //lấy chi tiết post
       
    }
}
