namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
            Tour_image = new HashSet<Tour_image>();
            TourManagement = new HashSet<TourManagement>();
        }

        [Key]
        public int id_tour { get; set; }

        [StringLength(100)]
        public string tour_name { get; set; }

        [StringLength(255)]
        public string tour_description { get; set; }

        [StringLength(255)]
        public string tour_schedule { get; set; }

        public decimal? price { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? departure_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime? return_time { get; set; }

        [StringLength(60)]
        public string departure_location { get; set; }

        [StringLength(60)]
        public string arrival_location { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? rating { get; set; }

        public int? quantity { get; set; }

        public bool? is_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_image> Tour_image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourManagement> TourManagement { get; set; }
    }
}
