namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int id_comment { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public int? rate { get; set; }

        [StringLength(255)]
        public string id_tour { get; set; }

        public int? id_user { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual User User { get; set; }
    }
}
