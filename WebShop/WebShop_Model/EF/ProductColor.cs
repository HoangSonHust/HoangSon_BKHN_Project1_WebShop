namespace WebShop_Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductColor")]
    public partial class ProductColor
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string Color { get; set; }

        public int? Quantity { get; set; }

        public string ColorBackgroud { get; set; }

        public virtual Product Product { get; set; }
    }
}
