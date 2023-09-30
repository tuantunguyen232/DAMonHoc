namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            Like_action = new HashSet<Like_action>();
            News_image = new HashSet<News_image>();
            News_comment = new HashSet<News_comment>();
        }

        [Key]
        [StringLength(10)]
        public string id_news { get; set; }

        [StringLength(100)]
        public string news_name { get; set; }

        [StringLength(255)]
        public string news_description { get; set; }

        [StringLength(60)]
        public string address { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? like_count { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like_action> Like_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News_image> News_image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News_comment> News_comment { get; set; }
    }
}
