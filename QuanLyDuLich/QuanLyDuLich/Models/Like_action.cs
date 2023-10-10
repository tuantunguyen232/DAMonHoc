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
        public int id_likeaction { get; set; }

        public bool? active { get; set; }

        public int? id_user { get; set; }

        public int? id_news { get; set; }

        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
