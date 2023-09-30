namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News_image
    {
        [Key]
        [StringLength(10)]
        public string id_newsiamge { get; set; }

        [StringLength(255)]
        public string image_link { get; set; }

        [StringLength(255)]
        public string image_des { get; set; }

        [StringLength(10)]
        public string id_news { get; set; }

        public virtual News News { get; set; }
    }
}
