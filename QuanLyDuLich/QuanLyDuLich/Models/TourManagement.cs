namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourManagement")]
    public partial class TourManagement
    {
        [Key]
        [StringLength(10)]
        public string id_tour_manamegement { get; set; }

        [StringLength(10)]
        public string id_tour { get; set; }

        [StringLength(10)]
        public string id_user { get; set; }

        public DateTime? createDate { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual User User { get; set; }
    }
}
