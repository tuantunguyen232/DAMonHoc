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
        [StringLength(10)]
        public string id_newscomment { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        [StringLength(10)]
        public string id_news { get; set; }

        [StringLength(10)]
        public string id_user { get; set; }

        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
