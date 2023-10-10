namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DateSch")]
    public partial class DateSch
    {
        [Key]
        public int id_day { get; set; }

        public int? id_schedule { get; set; }

        [StringLength(100)]
        public string day_description { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
