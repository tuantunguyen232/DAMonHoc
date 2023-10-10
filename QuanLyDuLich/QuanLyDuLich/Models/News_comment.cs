namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News_comment
    {
        [Key]
        public int id_newscomment { get; set; }

        public DateTime? created_date { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        public int? id_news { get; set; }

        public int? id_user { get; set; }

        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
