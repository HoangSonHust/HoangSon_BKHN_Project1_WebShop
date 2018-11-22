namespace WebShop_Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promotion")]
    public partial class Promotion
    {
        public int ID { get; set; }

        public string PromotionName { get; set; }

        [StringLength(300)]
        public string MetaTitle { get; set; }

        public string Content { get; set; }

        public string Detail { get; set; }

        public bool? Status { get; set; }
    }
}
