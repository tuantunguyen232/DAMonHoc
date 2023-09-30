namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_details
    {
        [Key]
        [StringLength(10)]
        public string id_orderdetail { get; set; }

        [StringLength(10)]
        public string id_orders { get; set; }

        [StringLength(10)]
        public string id_tour { get; set; }

        public int? quantity { get; set; }

        public decimal? price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
