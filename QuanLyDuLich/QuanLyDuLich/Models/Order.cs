namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int id_orders { get; set; }

        public DateTime? created_date { get; set; }

        public decimal? price { get; set; }

        public int? id_user { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        public int? id_tour { get; set; }

        public int? quantity { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual User User { get; set; }
    }
}
