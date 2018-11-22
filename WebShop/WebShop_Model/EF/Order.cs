namespace WebShop_Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public long? CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CustomerTel { get; set; }

        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public bool Status { get; set; }
    }
}
