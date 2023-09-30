namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tour_image
    {
        [Key]
        [StringLength(10)]
        public string id_tourimage { get; set; }

        [StringLength(255)]
        public string image_link { get; set; }

        [StringLength(255)]
        public string image_des { get; set; }

        [StringLength(10)]
        public string id_tour { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
