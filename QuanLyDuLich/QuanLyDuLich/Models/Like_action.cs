namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Like_action
    {
        [Key]
        [StringLength(10)]
        public string id_likeaction { get; set; }

        public bool? active { get; set; }

        [StringLength(10)]
        public string id_user { get; set; }

        [StringLength(10)]
        public string id_news { get; set; }

        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
